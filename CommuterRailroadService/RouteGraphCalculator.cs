using System;
using System.Linq;

namespace CommuterRailroadService
{
    public class RouteGraphCalculator
    {

        private RouteGraph routeGraph;

        public RouteGraphCalculator(RouteGraph routeGraph)
        {
            this.routeGraph = routeGraph;
        }

        public int CalculateDistance(string stationNameA, string stationNameB)
        {

            var routeOrigin = routeGraph.stations.Find(o => o.name == stationNameA);

            var routeDestination = routeGraph.stations.Find(d => d.name == stationNameB);

            var routeDistances = routeOrigin.railLinks.Where(rl => rl.destination == routeDestination)
                                       .Select(rl => rl.distance).Distinct();


            return routeDistances.Sum();
        }

        public int CalculateDistanceBetweenMultipleLegs(string origin, string stop1,string destination)
        {
            var routeLegOneDistance = this.CalculateDistance(origin,stop1);
            var routeLegTwoDistance = this.CalculateDistance(stop1, destination);

            return routeLegOneDistance += routeLegTwoDistance;

        }
    }
}
