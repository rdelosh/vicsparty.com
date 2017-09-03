using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vicsparty.Utilities.WebSocketRequests
{
    public class StartTheGameRequest
    {
        public ICollection<string> teamA { get; set; }
        public ICollection<string> teamB { get; set; }

        public StartTheGameRequest()
        {
            teamA = new List<string>();
            teamB = new List<string>();
        }
    }
}