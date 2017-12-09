using System;
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


            sut.CreateRailLinkForStation(station1,station2,5);

            Assert.That(station1.railLinks[0].origin.Equals(expectedRailLink.origin));
            Assert.That(station1.railLinks[0].destination.Equals(expectedRailLink.destination));
            Assert.That(station1.railLinks[0].distance.Equals(expectedRailLink.distance));
        }
    }
}
