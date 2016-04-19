using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    public class BoxModelTests
    {
        private BoxModel _testObj;

        [SetUp]
        public void Setup()
        {
            _testObj = new BoxModel(3);
        }

        [Test]
        public void HasNoChipTrueByDefault()
        {
            Assert.True(_testObj.HasNoChip());
        }

        [Test]
        public void HasChipInAndPutChipInEndToEnd()
        {
            _testObj.AddChip();
            _testObj.PutChipInColumn(2);
            Assert.True(_testObj.HasChipIn(2));
        }

        [Test]
        public void TwoChipsCanGoInSameColumn()
        {
            _testObj = new BoxModel(2);
            _testObj.AddChip();
            _testObj.PutChipInColumn(1);
            _testObj.AddChip();
            _testObj.PutChipInColumn(1);

            Assert.That(_testObj.GetRow(1).Count(n => n.print() != " "), Is.EqualTo(1));
            Assert.That(_testObj.GetRow(0).Count(n => n.print() != " "), Is.EqualTo(1));
        }
    }
}   