using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    internal class BoxPrinterTest
    {
        private static BoxModel _model;
        private static BoxPrinter _printer;
        private static int _edgeLength;

        private static void AssertSizeIsCorrect(int edgeLength, string expected)
        {
            _edgeLength = edgeLength;
            Assert.That(_printer.Print(), Is.EqualTo(expected));
        }

        public void CreateTestObj(int edgeLength)
        {
            _model = new BoxModel(edgeLength);
            _printer = new BoxPrinter(_model);
        }

        [Test]
        public void OneByOnePrintsCorrectly()
        {
            _edgeLength = 1;
            CreateTestObj(_edgeLength);

            IChip chip = new TestChip(_edgeLength);
            _model.AddChip(chip);

            var expected = "";
            expected += "  1  \n";
            expected += "┌───┐\n";
            expected += "│   │\n";
            expected += "└───┘\n";
            expected += "  1  \n";

            AssertSizeIsCorrect(_edgeLength, expected);
        }

        [Test]
        public void TwoByTwoPrintsCorrectly()
        {
            _edgeLength = 2;
            CreateTestObj(_edgeLength);

            IChip chip = new TestChip(_edgeLength);
            _model.AddChip(chip);

            var expected = "";
            expected += "    2   \n";
            expected += "┌──────┐\n";
            expected += "│      │\n";
            expected += "│      │\n";
            expected += "└──────┘\n";
            expected += "  1  2  \n";

            AssertSizeIsCorrect(_edgeLength, expected);
        }

        [Test]
        public void ChipDoesNotNeedToBePresent()
        {
            _edgeLength = 2;
            CreateTestObj(_edgeLength);
            var expected = "";

            expected += "┌──────┐\n";
            expected += "│      │\n";
            expected += "│      │\n";
            expected += "└──────┘\n";
            expected += "  1  2  \n";

            AssertSizeIsCorrect(_edgeLength, expected);
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