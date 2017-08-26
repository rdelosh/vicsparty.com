using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;

namespace vicsparty.Utilities
{
    public class singletonlistofwebsockets
    {
        public static ICollection<WebSocketHandler> _listofwebsockets;

        private static singletonlistofwebsockets instance = new singletonlistofwebsockets();

        public static singletonlistofwebsockets Instance => instance;

        private singletonlistofwebsockets()
        {
            _listofwebsockets = new List<WebSocketHandler>();
        }
    }
}