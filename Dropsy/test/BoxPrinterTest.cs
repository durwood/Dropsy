using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    internal class BoxPrinterTest
    {
        [Test]
        public void OneByOnePrintsCorrectly()
        {
            var testObject = new BoxPrinter();
            var model = new BoxModel(1);

            var expected = "";
            expected += "┌───┐\n";
            expected += "│   │\n";
            expected += "└───┘\n";

            Assert.That(testObject.Print(model), Is.EqualTo(expected));
        }

        [Test]
        public void TwoByTwoPrintsCorrectly()
        {
            var testObject = new BoxPrinter();
            var model = new BoxModel(2);

            var expected = "";
            expected += "┌──────┐\n";
            expected += "│      │\n";
            expected += "│      │\n";
            expected += "└──────┘\n";

            Assert.That(testObject.Print(model), Is.EqualTo(expected));
        }
    }

    public class BoxModel
    {
        public readonly int EdgeLength;

        public BoxModel(int edgeLength)
        {
            EdgeLength = edgeLength;
        }
    }
}