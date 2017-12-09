using System;
using NUnit.Framework;

namespace CommuterRailroadService
{    
    [TestFixture]
    public class StationShould
    {
       
        [Test]
        public void ContainARailLink()
        {
            var testStation = new Station("A");
            var testDestinationStation = new Station("B");
            var expectedRailLink = new RailLink(){
                origin = testStation,
                destination = testDestinationStation,
                distance = 5
            };

            testStation.railLinks.Add(expectedRailLink);

            Assert.That(testStation.railLinks.Contains(expectedRailLink));
        }
    }
}
