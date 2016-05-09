using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    public class BoxModelTests
    {
        [SetUp]
        public void Setup()
        {
            var chipFactory = new UnpoppableChipFactory();
            _testObj = new BoxModel(3, chipFactory, new Board(3));
        }

        private BoxModel _testObj;

        private void AssertRowHasCount(int row, int count)
        {
            Assert.That(_testObj.GetRow(row).Count(n => n.HasValue()), Is.EqualTo(count));
        }

        [Test]
        public void AddUnplacedChipPlacesBoxesOnBottomRowAfterFiveTurns()
        {
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(1);
            _testObj.PutChipOnBoard(2);
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(1);

            AssertRowHasCount(0, 2);
            AssertRowHasCount(1, 3);
            AssertRowHasCount(2, 3);
        }

        [Test]
        public void AddUnplacedChipPlacesRowOnBottomAfterMultiplesOfFive()
        {
            _testObj = new BoxModel(7, new ChipFactory(), new Board(7));

            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(1);
            _testObj.PutChipOnBoard(2);
            _testObj.PutChipOnBoard(3);
            _testObj.PutChipOnBoard(4);
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(1);
            _testObj.PutChipOnBoard(2);
            _testObj.PutChipOnBoard(3);
            _testObj.PutChipOnBoard(4);

            AssertRowHasCount(6, 7);
            AssertRowHasCount(5, 7);
            AssertRowHasCount(4, 5);
            AssertRowHasCount(3, 5);
        }

        [Test]
        public void AddUnplacedChipPlacesRowOnBottomAfterTurnIsTaken()
        {
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(1);
            _testObj.PutChipOnBoard(2);
            _testObj.PutChipOnBoard(0);
            _testObj.AddUnplacedChip();

            AssertRowHasCount(0, 0);
            AssertRowHasCount(1, 1);
            AssertRowHasCount(2, 3);
        }

        [Test]
        public void ChipsCanBePopped()
        {
            var fakeChipFactory = new FakeChipFactory {Chip = new Chip(1)};
            _testObj = new BoxModel(1, fakeChipFactory, new Board(1));
            _testObj.PutChipOnBoard(0);
            Assert.False(_testObj.GameOver());
        }

        [Test]
        public void FullColumnCanNotAcceptChips()
        {
            var fakeChipFactory = new FakeChipFactory {Chip = new Chip(5)};
            _testObj = new BoxModel(2, fakeChipFactory, new Board(2));
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(0);
            fakeChipFactory.Chip = new Chip(6);
            _testObj.PutChipOnBoard(0);

            Assert.That(_testObj.GetRow(0).First().print(), Is.EqualTo("5"));
        }

        [Test]
        public void GameOverReturnsFalseWhenBoardIsFresh()
        {
            Assert.False(_testObj.GameOver());
        }

        [Test]
        public void GameOverReturnsFalseWhenBoardNotFull()
        {
            _testObj = new BoxModel(2, new ChipFactory(), new Board(2));
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(1);
            Assert.False(_testObj.GameOver());
        }

        [Test]
        public void GameOverReturnsTrueWhenBoardIsFull()
        {
            var board = new BoardTestFactory(2).Create(new List<int>{1, 1, 1, 1});
            _testObj = new BoxModel(2, new ChipFactory(), board);
            Assert.True(_testObj.GameOver());
        }

        [Test]
        public void GameOverReturnsTrueWhenValuesArePushedOffBox()
        {
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(1);
            _testObj.PutChipOnBoard(1);
            Assert.True(_testObj.GameOver());
        }

        [Test]
        public void HasChipInAndPutChipInEndToEnd()
        {
            _testObj.PutChipOnBoard(2);
            AssertRowHasCount(2, 1);
        }

        [Test]
        public void HasNoChipTrueByDefault()
        {
            Assert.True(_testObj.HasNoUnplacedChip());
        }

        [Test]
        public void TwoChipsCanGoInSameColumn()
        {
            _testObj = new BoxModel(2, new ChipFactory(), new Board(2));
            _testObj.PutChipOnBoard(1);
            _testObj.PutChipOnBoard(1);

            AssertRowHasCount(1, 1);
            Assert.That(_testObj.GetRow(0).Count(n => n.print() != " "), Is.EqualTo(1));
        }

        [Test]
        public void WhenChipPlacedInFullColumnNextUnplacedChipIsNotRerolled()
        {
            var fakeChipFactory = new FakeChipFactory {Chip = new Chip(5)};
            _testObj = new BoxModel(2, fakeChipFactory, new Board(2));
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(0);
            fakeChipFactory.Chip = new Chip(6);
            _testObj.PutChipOnBoard(0);
            fakeChipFactory.Chip = new Chip(7);
            _testObj.PutChipOnBoard(1);

            Assert.That(_testObj.GetRow(1)[1].print(), Is.EqualTo("6"));
        }

        [Test]
        public void WhenColumnIsFullPlacingAChipDoesNotPlaceBlocks()
        {
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(1);
            _testObj.PutChipOnBoard(0);

            AssertRowHasCount(0, 1);
            AssertRowHasCount(1, 1);
            AssertRowHasCount(2, 2);
        }
    }

    public class BoardTestFactory
    {
        private readonly int _edgeLength;

        public BoardTestFactory(int edge)
        {
            _edgeLength = edge;
        }

        public Board Create(List<int> values)
        {
            var board = new Board(_edgeLength);
            for (int i = 0; i < _edgeLength*_edgeLength; i++)
            {
                board.PlaceChip(GetRow(i), GetColumn(i), new Chip(values[i]));
            }
            return board;
        }

        private int GetColumn(int i)
        {
            return i/_edgeLength;
        }

        private int GetRow(int i)
        {
            return i%_edgeLength;
        }
    }
}