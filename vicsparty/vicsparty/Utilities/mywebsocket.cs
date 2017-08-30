using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Microsoft.Web.WebSockets;
using Newtonsoft.Json;
using vicsparty.Utilities;
using vicsparty.Utilities.GameObjects;

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

        public override void OnOpen()
        {
            name = this.WebSocketContext.QueryString["name"];
            clients.Broadcast(name + " has connected to room "+ clients.collectionID);
            //broadcast json object with player who just connected
            
           
            foreach (var element in clients)
            {
                joinalertmessage newjoinalert = new joinalertmessage();
                newjoinalert.sender = ((mywebsocket)element).name;
                newjoinalert.type = "joinalert";
                clients.Broadcast(JsonConvert.SerializeObject(newjoinalert));
            }

            
        }

        public override void OnMessage(string message)
        {
            clients.Broadcast( name + " has said "+message);
            
        }

        public override void OnClose()
        {
            clients.Remove(this);
            clients.Broadcast(string.Format("{0} has gone away ", name));

        }

        
    }
}