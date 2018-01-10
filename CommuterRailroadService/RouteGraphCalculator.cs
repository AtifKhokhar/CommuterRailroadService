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

        public int CalculateDistanceBetweenTwoStations(string stationNameA, string stationNameB)
        {

            var routeOrigin = routeGraph.stations.Find(o => o.name == stationNameA);

            var routeDestination = routeGraph.stations.Find(d => d.name == stationNameB);

            var routeDistances = routeOrigin.railLinks.Where(rl => rl.destination == routeDestination)
                                       .Select(rl => rl.distance).Distinct();


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

        public int CalculateNumberOfRoutesBetweenTwoStations(string origin, string destination)
        {

            var routeOrigin = routeGraph.stations.Find(o => o.name == origin);

            var routeDestination = routeGraph.stations.Find(d => d.name == destination);

            var numberOfRoutes = routeOrigin.railLinks.Count(rl => rl.destination == routeDestination);

            routeOrigin.railLinks.Where(rl => rl.destination == routeDestination).ToList().ForEach(s => s.destination.isVisited = true);
               

            var originRailLinks = routeOrigin.railLinks;

            var originLinkedStations = originRailLinks.Select(rl => rl.destination).Where(s => s.isVisited == false);


            foreach (var linkedStationRailLink in originLinkedStations.Select(s => s.railLinks))
            {
                numberOfRoutes += linkedStationRailLink.Count(rl => rl.destination == routeDestination);
                linkedStationRailLink.Where(rl => rl.destination == routeDestination).ToList().ForEach(s => s.destination.isVisited = true);


                var linkedStationRailLinkStations =
                    linkedStationRailLink.Select(rl => rl.destination).Where(s => s.isVisited == false);

                foreach (var stationRailLink in linkedStationRailLinkStations.Select(s => s.railLinks))
                {
                    numberOfRoutes += stationRailLink.Count(rl => rl.destination == routeDestination);
                    stationRailLink.Where(rl => rl.destination == routeDestination).ToList().ForEach(s => s.destination.isVisited = true);

                    var stationRailLinkStations = linkedStationRailLink.Select(rl => rl.destination).Where(s => s.isVisited == false);

                    foreach (var railLink in stationRailLinkStations.Select(s => s.railLinks))
                    {
                        numberOfRoutes += railLink.Count(rl => rl.destination == routeDestination);
                        railLink.Where(rl => rl.destination == routeDestination).ToList().ForEach(s => s.destination.isVisited = true);
                    }
                }
            }

            return numberOfRoutes;
        }
    }
}
