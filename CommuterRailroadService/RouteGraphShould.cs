using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommuterRailroadService
{
    [TestFixture]
    public class RouteGraphShould
    {
        [Test]
        public void CreateRailLinkFromOneStationToAnother()
        {
            var station1 = new Station("A");
            var station2 = new Station("B");
            var sut = new RouteGraph();
            var expectedRailLink = new RailLink()
            {
                origin = station1,
                destination = station2,
                distance = 5
            };


            sut.CreateRailLinkForStation(station1, station2, 5);

            Assert.That(station1.railLinks[0].origin.Equals(expectedRailLink.origin));
            Assert.That(station1.railLinks[0].destination.Equals(expectedRailLink.destination));
            Assert.That(station1.railLinks[0].distance.Equals(expectedRailLink.distance));
        }


        [Test]
        public void CreateMultipleRailLinksForOneStation()
        {
            var station1 = new Station("A");
            var station2 = new Station("B");
            var station3 = new Station("C");
            var sut = new RouteGraph();

            sut.CreateRailLinkForStation(station1,station2,5);
            sut.CreateRailLinkForStation(station1,station3,4);


            Assert.That(station1.railLinks[0].origin.Equals(station1));
            Assert.That(station1.railLinks[1].origin.Equals(station1));
            Assert.That(station1.railLinks[0].destination.Equals(station2));
            Assert.That(station1.railLinks[1].destination.Equals(station3));
            Assert.That(station1.railLinks[0].distance.Equals(5));
            Assert.That(station1.railLinks[1].distance.Equals(4));
        }

    }
}
