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

        public int CalculateDistanceBetweenTwoStations(string stationNameA, string stationNameB)
        {

            var routeOrigin = routeGraph.stations.Find(o => o.name == stationNameA);

            var routeDestination = routeGraph.stations.Find(d => d.name == stationNameB);

            var routeDistances = routeOrigin.railLinks.Where(rl => rl.destination == routeDestination)
                                       .Select(rl => rl.distance).Distinct();


            return routeDistances.Sum();
        }

        public int CalculateDistanceBetweenMultipleLegs(string origin, string stop1,string destination,string stop2=null,string stop3=null)
        {
            var routeLegOneDistance = this.CalculateDistanceBetweenTwoStations(origin,stop1);
            var routeLegTwoDistance = 0;
            var routeLegThreeDistance = 0;
            var routeFinalLegDistance = 0;

            if (stop2 != null)
            {
                routeLegTwoDistance = this.CalculateDistanceBetweenTwoStations(stop1, stop2);

                if (stop3 != null)
                {
                    routeLegThreeDistance = this.CalculateDistanceBetweenTwoStations(stop2, stop3);
                    routeFinalLegDistance = this.CalculateDistanceBetweenTwoStations(stop3, destination);

                }
                else
                {
                    routeFinalLegDistance = this.CalculateDistanceBetweenTwoStations(stop2, destination);
                }
            }
            else
            {
                routeFinalLegDistance = this.CalculateDistanceBetweenTwoStations(stop1, destination);
            }

            return routeLegOneDistance += routeLegTwoDistance + routeLegThreeDistance + routeFinalLegDistance;
        }
    }
}
