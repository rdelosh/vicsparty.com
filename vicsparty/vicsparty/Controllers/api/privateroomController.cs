using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MacPortafolio.Utilities;
using Microsoft.Web.WebSockets;
using vicsparty.Utilities;

namespace vicsparty.Controllers.api
{
    public class privateroomController : ApiController
    {
        

        

        private WebSocketHandler createnewroom()
        {
            WebSocketCollectionWithID new_websocket_collection = new WebSocketCollectionWithID(singletonlistofwebsocketcollections._listofwebsocketcollections.Count+1);
            mywebsocket newwebsocket = new mywebsocket(new_websocket_collection);
            singletonlistofwebsocketcollections._listofwebsocketcollections.Add(new_websocket_collection);
            return newwebsocket;
        }

        public HttpResponseMessage Get()
        {
            if (System.Web.HttpContext.Current.IsWebSocketRequest)
            {

                System.Web.HttpContext.Current.AcceptWebSocketRequest(createnewroom());
                return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        


    }
}
