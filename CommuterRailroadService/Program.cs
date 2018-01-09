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

            var listOfRoutes = new List<List<string>>
            {
                new List<string>(){"A","B","C"},
                new List<string>(){"A","D"},
                new List<string>(){"A","D","C"},
                new List<string>(){"A","E","B","C","D"},
                new List<string>(){"A","E","D"},
            };
            foreach (var route in listOfRoutes)
            {

             var calculatedDistance = graphCalculator.CalculateDistanceOfRoute(route);

                if (calculatedDistance == 0)
                {
                  Console.WriteLine("Distance for Route {0} : NO SUCH ROUTE", String.Join("-",route));
                }
                else
                {
                  Console.WriteLine($"Distance for Route {String.Join("-", route)} : {calculatedDistance}");
                }
               

            }

            Console.ReadLine();




        }
    }
}
