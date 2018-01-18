using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommuterRailroadService
{
    [TestFixture]
    public class RouteGraphCalculatorShould
    {
        private Station stationA;
        private Station stationB;
        private Station stationC;
        private Station stationD;
        private Station stationE;

        private RouteGraph graph;
        private RouteGraphCalculator sut;


        [SetUp]
        public void Setup()
        {
            stationA = new Station("A");
            stationB = new Station("B");
            stationC = new Station("C");
            stationD = new Station("D");
            stationE = new Station("E");


            graph = new RouteGraph();

            graph.CreateRailLinkForStation(stationA, stationB, 5);
            graph.CreateRailLinkForStation(stationA, stationE, 7);
            graph.CreateRailLinkForStation(stationE, stationB, 3);
            graph.CreateRailLinkForStation(stationB, stationC, 4);
            graph.CreateRailLinkForStation(stationC, stationD, 8);
            graph.CreateRailLinkForStation(stationA, stationD, 5);
            graph.CreateRailLinkForStation(stationD, stationC, 8);


        }

        [TestCase("A,B", 5)]
        [TestCase("A,D", 5)]
        [TestCase("B,C", 4)]
        [TestCase("A,B,C", 9)]
        [TestCase("A,B,C,D", 17)]
        [TestCase("A,D,C", 13)]
        [TestCase("A,E,B,C,D", 22)]
        [TestCase("A,E,D", 0)]
        public void CalculateRouteDistance(string inputRoute,int expectedDistance)
        {
            sut = new RouteGraphCalculator(graph);
            var route = inputRoute.Split(',').ToList();
            var actualResult = this.sut.CalculateDistanceOfRoute(route);
            
            Assert.That(actualResult.Equals(expectedDistance));

        }

    }

}
