using System.Collections.Generic;

namespace CommuterRailroadService
{
    public class RouteGraph
    {
        public List<Station> stations; 

        public RouteGraph()
        {
            stations = new List<Station>();
        }

        public void CreateRailLinkForStation(Station origin,Station destination,int distance)
        {
            stations.Add(origin);
            stations.Add(destination);
            origin.railLinks.Add(new RailLink()
            {
                origin = origin,
                destination = destination,
                distance = distance
            });
        }
    }
}