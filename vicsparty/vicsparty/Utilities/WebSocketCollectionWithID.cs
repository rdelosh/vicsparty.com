using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;

namespace vicsparty.Utilities
{
    public class WebSocketCollectionWithID: WebSocketCollection
    {
        public int collectionID;

        public WebSocketCollectionWithID(int id)
        {
            collectionID = id;
        }
    }
}