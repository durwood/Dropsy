using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    public class BoxPrinterTest
    {
        private BoxModel _model;
        private  BoxPrinter _printer;
        private  int _edgeLength;

        private void AssertSizeIsCorrect(int edgeLength, string expected)
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

            IChip chip = new Chip(_edgeLength);
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

            IChip chip = new Chip(_edgeLength);
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
        public void PutTheChipInAColumn()
        {
            _edgeLength = 2;
            CreateTestObj(_edgeLength);

            IChip chip = new Chip(_edgeLength);
            _model.AddChip(chip);
            _model.PutChipInColumn(1);

            var expected = "\n";
            expected += "┌──────┐\n";
            expected += "│      │\n";
            expected += "│    2 │\n";
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

            expected += "\n";
            expected += "┌──────┐\n";
            expected += "│      │\n";
            expected += "│      │\n";
            expected += "└──────┘\n";
            expected += "  1  2  \n";

            AssertSizeIsCorrect(_edgeLength, expected);
        }

        [Test]
        public void TwoChipsCanBePutInSameColumn()
        {
            _edgeLength = 2;
            CreateTestObj(_edgeLength);
            var expected = "";

            IChip chip = new Chip(_edgeLength);
            _model.AddChip(chip);
            _model.PutChipInColumn(1);
            chip = new Chip(_edgeLength);
            _model.AddChip(chip);
            _model.PutChipInColumn(1);

            expected += "\n";
            expected += "┌──────┐\n";
            expected += "│    2 │\n";
            expected += "│    2 │\n";
            expected += "└──────┘\n";
            expected += "  1  2  \n";

            AssertSizeIsCorrect(_edgeLength, expected);
        }
    }
}