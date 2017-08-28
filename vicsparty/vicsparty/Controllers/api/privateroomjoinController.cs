using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MacPortafolio.Utilities;
using vicsparty.Utilities;
using Microsoft.Web.WebSockets;

namespace vicsparty.Controllers.api
{
    public class privateroomjoinController : ApiController
    {
        public HttpResponseMessage Get(int id)
        {


            if (System.Web.HttpContext.Current.IsWebSocketRequest)
            {

                System.Web.HttpContext.Current.AcceptWebSocketRequest(findwebsockethandler(id));
                return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        private mywebsocket findwebsockethandler(int id)
        {
            
            foreach (var element in singletonlistofwebsocketcollections._listofwebsocketcollections)
            {
                if (element.collectionID == id)
                {
                    mywebsocket newwebsocket = new mywebsocket(element);
                    //element.Add(newwebsocket);
                    Debug.WriteLine("#####PASSED####");
                    return newwebsocket;
                }
            }
            Debug.WriteLine("#####FAILED####");
            return null;
        }
    }
}
