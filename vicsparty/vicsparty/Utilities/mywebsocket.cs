using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;

namespace MacPortafolio.Utilities
{
    public class mywebsocket : WebSocketHandler
    {
        private int wsid;
        private WebSocketCollection clients = new WebSocketCollection();
        private string name;

        public mywebsocket(int id)
        {
            wsid = id;
        }

        public override void OnOpen()
        {
            name = this.WebSocketContext.QueryString["chatName"];
            clients.Add(this);
            clients.Broadcast(name + "Se ha conectado"+ "a weboscket con id "+wsid);
            

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