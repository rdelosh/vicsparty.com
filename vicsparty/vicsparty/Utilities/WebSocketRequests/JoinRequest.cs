using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vicsparty.Utilities.WebSocketRequests
{
    public class JoinTeamRequest
    {
        public string team { get; set; }
        public string player { get; set; }
    }
}