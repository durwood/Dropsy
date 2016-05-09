using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    public class BoxPrinterTest
    {
        private BoxModel _model;
        private  BoxPrinter _printer;
        private  int _edgeLength;
        private FakeChipFactory _fakeChipFactory;
        private Board _board;

        private void AssertSizeIsCorrect(int edgeLength, string expected)
        {
            _edgeLength = edgeLength;
            Assert.That(_printer.Print(), Is.EqualTo(expected));
        }

        public void CreateTestObj(int edgeLength)
        {
            _fakeChipFactory = new FakeChipFactory();
            _board = new Board(edgeLength);
            _model = new BoxModel(edgeLength, _fakeChipFactory, _board);
            _printer = new BoxPrinter(_model);
        }

        [Test]
        public void OneByOnePrintsCorrectly()
        {
            _edgeLength = 1;
            CreateTestObj(_edgeLength);

            IChip chip = new Chip(_edgeLength);
            _fakeChipFactory.Chip = chip;
            _model.AddUnplacedChip();

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
            _fakeChipFactory.Chip = chip;
            _model.AddUnplacedChip();

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
            _fakeChipFactory.Chip = chip;
            _model.AddUnplacedChip();
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

            IChip chip = new Chip(5);
            _fakeChipFactory.Chip = chip;
            _model.PutChipOnBoard(1);
            _model.PutChipOnBoard(1);
            _model.PutChipOnBoard(0);

            expected += "\n";
            expected += "┌──────┐\n";
            expected += "│    5 │\n";
            expected += "│ 5  5 │\n";
            expected += "└──────┘\n";
            expected += "  1  2  \n";

            AssertSizeIsCorrect(_edgeLength, expected);
        }

        [Test]
        public void AfterFourTurnsNoBoxes()
        {
            _edgeLength = 3;
            CreateTestObj(_edgeLength);
            var expected = "";

            IChip chip = new Chip(_edgeLength);
            _fakeChipFactory.Chip = chip;
            _model.PutChipOnBoard(1);
            _model.PutChipOnBoard(1);
            _model.PutChipOnBoard(0);
            _model.PutChipOnBoard(0);

            expected += "\n";
            expected += "┌─────────┐\n";
            expected += "│         │\n";
            expected += "│ 3  3    │\n";
            expected += "│ 3  3    │\n";
            expected += "└─────────┘\n";
            expected += "  1  2  3  \n";

            AssertSizeIsCorrect(_edgeLength, expected);
        }

        [Test]
        public void AfterFiveTurnsThereAreBoxesOnLowestRow()
        {
            _edgeLength = 3;
            CreateTestObj(_edgeLength);
            var expected = "";

            IChip chip = new Chip(5);
            _fakeChipFactory.Chip = chip;
            _model.PutChipOnBoard(2);
            _model.PutChipOnBoard(1);
            _model.PutChipOnBoard(1);
            _model.PutChipOnBoard(0);
            _model.PutChipOnBoard(0);

            expected += "\n";
            expected += "┌─────────┐\n";
            expected += "│ 5  5    │\n";
            expected += "│ 5  5  5 │\n";
            expected += "│ █  █  █ │\n";
            expected += "└─────────┘\n";
            expected += "  1  2  3  \n";

            AssertSizeIsCorrect(_edgeLength, expected);
        }
    }

    public class FakeChipFactory : IChipFactory
    {
        public IChip Chip;

        public IChip Create(int edgeLength)
        {
            return Chip;
        }
    }

    public class UnpoppableChipFactory : IChipFactory
    {
        public IChip Create(int edgeLength)
        {
            return new BlockChip();
        }
    }
}