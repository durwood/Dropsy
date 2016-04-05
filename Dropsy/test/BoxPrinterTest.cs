using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    internal class BoxPrinterTest
    {
        private static void AssertSizeIsCorrect(int edgeLength, string expected)
        {
            IChip chip = new TestChip(edgeLength);
            var model = new BoxModel(edgeLength);
            var testObject = new BoxPrinter(model);
            model.AddChip(chip);
            Assert.That(testObject.Print(), Is.EqualTo(expected));
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