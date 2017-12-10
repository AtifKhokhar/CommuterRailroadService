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
        
        [TestCase("A","B",5)]
        [TestCase("A", "D", 5)]
        [TestCase("B", "C", 4)]
        public void CalculateDistanceBetweenTwoLinkedStations(string origin,string destination,int expectedDistance)
        {
            sut = new RouteGraphCalculator(graph); 

            var actualResult = this.sut.CalculateDistanceBetweenTwoStations(origin, destination);

            Assert.That(actualResult.Equals(expectedDistance)); 

        }

        [TestCase("A", "B","C", 9)]
        [TestCase("A", "B", "D", 17,"C")]
        [TestCase("A", "D", "C", 13)]
        [TestCase("A", "E", "D", 22, "B","C")]

        public void CalculateDistanceBetweenThreeOrMoreLinkedStations(string origin,string stop1,string destination,int expectedDistance,string stop2=null,string stop3=null)
        {
            sut = new RouteGraphCalculator(graph);

            var actualResult = this.sut.CalculateDistanceBetweenMultipleLegs(origin,stop1,destination,stop2,stop3);

            Assert.That(actualResult.Equals(expectedDistance));

        }

    }

}
