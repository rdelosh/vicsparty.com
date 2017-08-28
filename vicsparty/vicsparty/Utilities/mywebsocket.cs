using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Microsoft.Web.WebSockets;
using vicsparty.Utilities;

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
            //clients.Add(this);
            clients.Broadcast(name + "Se ha conectado"+ "a weboscket con id "+ clients.collectionID);
            clients.Broadcast(BitConverter.GetBytes(clients.collectionID));
  
        }

        public override void OnMessage(string message)
        {
            clients.Broadcast(message);

        }

        public override void OnClose()
        {
            clients.Remove(this);
            clients.Broadcast(string.Format("{0} se ha ido", name));

        }

    }
}