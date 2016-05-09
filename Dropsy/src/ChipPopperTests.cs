using System.Collections.Generic;
using Dropsy.test;
using NUnit.Framework;

namespace Dropsy
{
    [TestFixture]
    public class ChipPopperTests
    {
        [SetUp]
        public void Setup()
        {
            _testObj = new ChipPopper();
        }

        private ChipPopper _testObj;


        [Test]
        public void ChipOfValueOneCanNotPop()
        {
            var board = new BoardTestFactory(2).Create(new List<int> {1, 1, 1, 1});
            _testObj.PopChips(board);

            foreach (var chip in board.All())
            {
                Assert.That(chip.HasValue);
            }
        }

        [Test]
        public void ChipOfValueOnePopsOnABigBoard()
        {
            var board = new Board(3);

            for (var row = 0; row < 3; row++)
            {
                for (var column = 0; column < 3; column++)
                {
                    board.PlaceChip(row, column, new Chip(1));
                    _testObj.PopChips(board);
                    Assert.False(board.GetChip(row, column).HasValue());
                }
            }
        }

        [Test]
        public void ChipValueOfOnePopsInAOneByOne()
        {
            var board = new Board(1);
            board.PlaceChip(0, 0, new Chip(1));

            _testObj.PopChips(board);

            Assert.False(board.GetChip(0, 0).HasValue());
        }

        [Test]
        public void ChipsPopInBothRowAndColumn()
        {
            var board = new BoardTestFactory(2).Create(new List<int>() {2, 2, 2, 2});
            _testObj.PopChips(board);

            foreach (var chip in board.All())
            {
                Assert.False(chip.HasValue());
            }
        }

        [Test]
        public void ChipsMustBeNeighborsToBeConsideredForPopping()
        {
            var board = new BoardTestFactory(3).Create(new List<int>() { 0, 0, 0, 0, 0, 0, 2, 0, 2 });
            _testObj.PopChips(board);
            Assert.True(board.GetChip(2, 0).HasValue());
            Assert.True(board.GetChip(2, 2).HasValue());
        }
    }
}