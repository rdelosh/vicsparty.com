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
        

        

        public WebSocketHandler createnewroom()
        {
            WebSocketHandler newwebsocket = new mywebsocket(singletonlistofwebsockets._listofwebsockets.Count+1);
            singletonlistofwebsockets._listofwebsockets.Add(newwebsocket);
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
