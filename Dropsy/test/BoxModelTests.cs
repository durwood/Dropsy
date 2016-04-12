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
    }
}   