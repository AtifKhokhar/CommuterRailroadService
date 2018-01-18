using System;
using System.Collections.Generic;
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

        private int CalculateDistanceBetweenTwoStations(string stationNameA, string stationNameB)
        {

            var routeOrigin = routeGraph.stations.Find(o => o.name == stationNameA);

            var routeDestination = routeGraph.stations.Find(d => d.name == stationNameB);

            var routeDistances = routeOrigin.railLinks.Where(rl => rl.destination == routeDestination)
                                       .Select(rl => rl.distance);


            return routeDistances.Sum();
        }


        public int CalculateDistanceOfRoute(List<string> route)
        {
            var totalDistance = 0;
            foreach (var stop in route)
            {  

                var adjacentStop = route.SkipWhile(element => element != stop).Skip(1).FirstOrDefault();

                if (adjacentStop != null)
                {
                    var distance = this.CalculateDistanceBetweenTwoStations(stop, adjacentStop);
                    if (distance == 0)
                    {
                        totalDistance = 0;
                    }
                    totalDistance += distance;
                }

            }     
            return totalDistance;
        }
    }
}
