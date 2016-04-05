using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    internal class BoxPrinterTest
    {
        private static void AssertSizeIsCorrect(int edgeLength, string expected)
        {
            IChip chip = new TestChip(edgeLength);
            var testObject = new BoxPrinter(chip);
            var model = new BoxModel(edgeLength);
            Assert.That(testObject.Print(model), Is.EqualTo(expected));
        }

        [Test]
        public void OneByOnePrintsCorrectly()
        {
            var expected = "";
            expected += "  1  \n";
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
            expected += "    2   \n";
            expected += "┌──────┐\n";
            expected += "│      │\n";
            expected += "│      │\n";
            expected += "└──────┘\n";
            expected += "  1  2  \n";

            AssertSizeIsCorrect(2, expected);
        }
    }

    public class TestChip : IChip
    {
        private readonly int _value;

        public TestChip(int value)
        {
            _value = value;
        }

        public int Random()
        {
            return _value;
        }
    }
}