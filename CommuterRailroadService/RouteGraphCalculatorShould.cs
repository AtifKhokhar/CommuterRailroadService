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
        
        [Test]
        public void CalculateDistanceBetweenTwoLinkedStations()
        {
            sut = new RouteGraphCalculator(graph); 

            var actualResult = this.sut.CalculateDistance("A", "B");

            Assert.That(actualResult.Equals(5)); 

        }


    }

}
