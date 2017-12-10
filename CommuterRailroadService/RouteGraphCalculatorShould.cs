using System;
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
        private RouteGraph graph;
        private RouteGraphCalculator sut;


        [SetUp]
        public void Setup()
        {
            stationA = new Station("A");
            stationB = new Station("B");
            stationC = new Station("C");
            stationD = new Station("D");

            graph = new RouteGraph();

            graph.CreateRailLinkForStation(stationA, stationB, 5);
            graph.CreateRailLinkForStation(stationB, stationC, 4);

        }
        
        [TestCase("A","B",5)]
        [TestCase("B", "C", 4)]
        public void CalculateDistanceBetweenTwoLinkedStations(string origin,string destination,int expectedDistance)
        {
            sut = new RouteGraphCalculator(graph); 

            var actualResult = this.sut.CalculateDistance(origin, destination);

            Assert.That(actualResult.Equals(expectedDistance)); 

        }

        [TestCase("A", "B","C", 9)]
        public void CalculateDistanceBetweenThreeLinkedStations(string origin,string stop1,string destination,int expectedDistance)
        {
            sut = new RouteGraphCalculator(graph);

            var actualResult = this.sut.CalculateDistanceBetweenMultipleLegs(origin,stop1,destination);

            Assert.That(actualResult.Equals(expectedDistance));

        }

    }

}
