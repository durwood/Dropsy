using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Dropsy.test
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void GetColumnGetTheColumnOfChips()
        {
            var testObj = new Board(2);
            testObj.PlaceChip(0,0, new Chip(1));
            var chip = new Chip(2);
            testObj.PlaceChip(0, 1, chip);
            testObj.PlaceChip(1, 0, new Chip(3));
            var chip1 = new Chip(4);
            testObj.PlaceChip(1, 1, chip1);

            Assert.That(testObj.GetColumn(1), Is.EqualTo(new List<IChip>{chip, chip1}));
        }
    }
}