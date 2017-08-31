using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Microsoft.Web.WebSockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using vicsparty.Utilities;
using vicsparty.Utilities.GameObjects;
using vicsparty.Utilities.WebSocketRequests;

namespace MacPortafolio.Utilities
{
    public class mywebsocket : WebSocketHandler
    {
        
        private WebSocketCollectionWithID clients;
        private string name;

        public mywebsocket(WebSocketCollectionWithID mywebsocketcollection)
        {
            clients = mywebsocketcollection;
            mywebsocketcollection.Add(this);
        }

        private void updatewebsocketcollection(string typeofalert)
        {
            JArray listofplayers = new JArray();

            foreach (var element in clients)
            {
                listofplayers.Add(((mywebsocket)element).name);
            }
            JObject o =new JObject();
            o["listofplayers"] = listofplayers;
            o["typeofalert"] = typeofalert;
            o["room"] = clients.collectionID;
            clients.Broadcast(o.ToString());
        }
        public override void OnOpen()
        {
            name = this.WebSocketContext.QueryString["name"];
            clients.Broadcast(name + " has connected to room "+ clients.collectionID);
            //broadcast json object with player who just connected
            updatewebsocketcollection("joinalert");





        }

        private bool isvalidupdateteamrequest(JoinTeamRequest jointeamrequest)
        {

            
            if (jointeamrequest.team.Equals(clients.teamA.name))
            { 
                if (clients.teamA.players.Contains(jointeamrequest.player))
                {
                    return false;
                }
                clients.teamA.players.Add(jointeamrequest.player);
                try
                {
                    clients.teamB.players.Remove(jointeamrequest.player);
                }
                catch (Exception ex)
                {

                }
            }

            if (jointeamrequest.team.Equals(clients.teamB.name))
            {
                if (clients.teamB.players.Contains(jointeamrequest.player))
                {
                    return false;
                }
                clients.teamB.players.Add((jointeamrequest.player));
                try
                {
                    clients.teamA.players.Remove(jointeamrequest.player);
                }
                catch (Exception ex)
                {

                }
            }
            return true;

        }
        public override void OnMessage(string message)
        {
            try
            {

                WebSocketRequest mywebsocketrequest = JsonConvert.DeserializeObject<WebSocketRequest>(message);
                //TAKE JSON JOINTEAMREQUEST,VALIDATE AND IF VALID SEND THE SAME MESSAGE BACK, AND UPDATE SERVERSIDED TEAMS
                if (mywebsocketrequest.typeofalert.Equals("jointeamrequest"))
                {

                    string data = JsonConvert.SerializeObject(mywebsocketrequest.data);
                    JoinTeamRequest jointeamrequest = JsonConvert.DeserializeObject<JoinTeamRequest>(data);
                    if (isvalidupdateteamrequest(jointeamrequest))
                    {
                        clients.Broadcast(message);
                    }
                }
                //TAKE JSON REQUEST TO GET TEAMS AND GENERATE A NEW JSONRESPONSE WIH THE CURRENT STATE OF TEAMS
                if (mywebsocketrequest.typeofalert.Equals("getstateofteams"))
                {
                    

                    JObject o = new JObject();

                    JArray serializedteams = new JArray();
                    JObject teamAjJObject = new JObject();
                    teamAjJObject["team"] = JToken.Parse(JsonConvert.SerializeObject(clients.teamA));
                    JObject teamBjJObject = new JObject();
                    teamBjJObject["team"] = JToken.Parse(JsonConvert.SerializeObject(clients.teamB));
                    serializedteams.Add(teamAjJObject);
                    serializedteams.Add(teamBjJObject);




                    o["teams"] = serializedteams;
                    o["typeofalert"] = "getstateofteams";
                    clients.Broadcast(o.ToString());
                }

            }
            catch (Exception e)
            {
                //IF DESERIALIZING DOES NOT WORK, THEN TREAT MESSAGE AS CHAT MESSAGE
                clients.Broadcast(name + " has said " + message);
            }
            
            
        }

        public override void OnClose()
        {
            clients.Remove(this);
            clients.Broadcast(string.Format("{0} has gone away ", name));
            updatewebsocketcollection("leavealert");
        }

        
    }
}