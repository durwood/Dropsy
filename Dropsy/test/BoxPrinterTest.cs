using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    internal class BoxPrinterTest
    {
        private static void AssertSizeIsCorrect(int edgeLength, string expected)
        {
            var testObject = new BoxPrinter();
            var model = new BoxModel(edgeLength);
            Assert.That(testObject.Print(model), Is.EqualTo(expected));
        }

        [Test]
        public void OneByOnePrintsCorrectly()
        {
            var expected = "";
            expected += "┌───┐\n";
            expected += "│   │\n";
            expected += "└───┘\n";
            expected += "  1  \n";

            AssertSizeIsCorrect(1, expected);
        }

        [Test]
        public void TwoByTwoPrintsCorrectly()
        {
            var expected = "";
            expected += "┌──────┐\n";
            expected += "│      │\n";
            expected += "│      │\n";
            expected += "└──────┘\n";
            expected += "  1  2  \n";

            AssertSizeIsCorrect(2, expected);
        }
    }
}