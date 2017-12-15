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

        [TestCase("A", "B", 5)]
        [TestCase("A", "D", 5)]
        [TestCase("B", "C", 4)]
        [TestCase("A" ,"C", 9,"B")]
        [TestCase("A", "D", 17,"B","C")]
        [TestCase("A", "C", 13,"D")]
        [TestCase("A","D", 22,"E", "B","C")]
        [TestCase("A","D",0,"E")]

        public void CalculateDistanceBetweenTwoOrMoreLinkedStations(string origin,string destination,int expectedDistance,string stop1=null,string stop2=null,string stop3=null)
        {
            sut = new RouteGraphCalculator(graph);

            var actualResult = this.sut.CalculateDistanceBetweenLinkedStations(origin,destination,stop1,stop2,stop3);

            Assert.That(actualResult.Equals(expectedDistance));

        }

    }

}
