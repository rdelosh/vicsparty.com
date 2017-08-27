using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MacPortafolio.Utilities;
using Microsoft.Web.WebSockets;

namespace vicsparty.Utilities
{
    public class singletonlistofwebsocketcollections
    {
        public static ICollection<WebSocketCollectionWithID> _listofwebsocketcollections;

        private static singletonlistofwebsocketcollections instance = new singletonlistofwebsocketcollections();

        public static singletonlistofwebsocketcollections Instance => instance;

        private singletonlistofwebsocketcollections()
        {
            _listofwebsocketcollections = new List<WebSocketCollectionWithID>();
        }
    }
}