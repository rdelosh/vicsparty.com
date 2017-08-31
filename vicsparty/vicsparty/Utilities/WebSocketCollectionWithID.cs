using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;
using vicsparty.Utilities.WebSocketRequests;

namespace vicsparty.Utilities
{
    public class WebSocketCollectionWithID: WebSocketCollection
    {
        public int collectionID;
        
        public teamEntity teamA { get; set; }
        public teamEntity teamB { get; set; }
        

        public WebSocketCollectionWithID(int id)
        {
            teamA=new teamEntity("A");
            teamB = new teamEntity("B");
            collectionID = id;
        }
    }
}