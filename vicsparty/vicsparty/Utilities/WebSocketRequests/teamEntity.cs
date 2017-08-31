using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vicsparty.Utilities.WebSocketRequests
{
    public class teamEntity
    {
        public string name { get; set; }
        public ICollection<String> players { get; set; }

        public teamEntity(string name)
        {
            players = new List<string>();
            this.name = name;
        }
    }
}