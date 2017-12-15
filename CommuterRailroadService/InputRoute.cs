using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuterRailroadService
{
    public class InputRoute
    {
        public string origin;
        public string stop1;
        public string stop2;
        public string stop3;
        public string destination;

        public InputRoute(string origin,string destination, string stop1=null, string stop2=null, string stop3=null)
        {
            this.origin = origin;
            this.stop1 = stop1;
            this.stop2 = stop2;
            this.stop3 = stop3;
            this.destination = destination;
        }
    }
}
