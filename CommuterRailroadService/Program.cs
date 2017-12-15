using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommuterRailroadService
{
    class Program
    {

        static void Main(string[] args)
        {
            var graph = new RouteGraph();
            var graphCalculator = new RouteGraphCalculator(graph);

            var stationA = new Station("A");
            var stationB = new Station("B");
            var stationC = new Station("C");
            var stationD = new Station("D");
            var stationE = new Station("E");


            graph.CreateRailLinkForStation(stationA, stationB, 5); //AB5

            graph.CreateRailLinkForStation(stationB, stationC, 4); //BC4

            graph.CreateRailLinkForStation(stationC, stationD, 8); //CD8
            graph.CreateRailLinkForStation(stationD, stationC, 8); //DC8

            graph.CreateRailLinkForStation(stationD, stationE, 6); //DE6
            graph.CreateRailLinkForStation(stationA, stationD, 5); //AD5

            graph.CreateRailLinkForStation(stationC, stationE, 2); //CE2
            graph.CreateRailLinkForStation(stationE, stationB, 3); //EB3
            graph.CreateRailLinkForStation(stationA, stationE, 7); //AE7

            var listOfRoutes = new List<InputRoute>
            {
                new InputRoute("A","C","B"),
                new InputRoute("A","D"),
                new InputRoute("A","C","D"),
                new InputRoute("A","D","E","B","C"),
                new InputRoute("A","D","E"),
            };
            foreach (var route in listOfRoutes)
            {

             var calculatedDistance = graphCalculator.CalculateDistanceBetweenLinkedStations(route.origin, route.destination, route.stop1,
                    route.stop2, route.stop3);

                if (calculatedDistance == 0)
                {
                  Console.WriteLine("Distance for Route {0}-{1}-{2}-{3}-{4} : NO SUCH ROUTE",route.origin,route.stop1,route.stop2,route.stop3,route.destination);
                }
                else
                {
                  Console.WriteLine($"Distance for Route {route.origin}-{route.stop1}-{route.stop2}-{route.stop3}-{route.destination} : {calculatedDistance}");
                }
               

            }

            Console.ReadLine();




        }
    }
}
