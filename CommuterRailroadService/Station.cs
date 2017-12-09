using System.Collections.Generic;

namespace CommuterRailroadService
{
    public class Station
    {
        public string name;
        public List<RailLink> railLinks = new List<RailLink>(); 

        public Station(string name)
        {
            this.name = name;
        }
    }
}