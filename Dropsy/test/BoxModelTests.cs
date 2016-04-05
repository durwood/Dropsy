using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    public class BoxModelTests
    {
        [Test]
        public void HasNoChipTrueByDefault()
        {
            var _testObj = new BoxModel(3);
            Assert.True(_testObj.HasNoChip());
        }
        
    }
}   