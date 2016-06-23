using System.Collections.Generic;
using System.Linq;
using Dropsy.test;
using NUnit.Framework;

namespace Dropsy
{
    [TestFixture]
    public class ChipTests
    {

        [Test]
        public void IsAnimatingIsFalseForNow()
        {
            var chip = new Chip(1);
            Assert.False(chip.IsAnimating());
        }

        [Test]
        public void IsAnimatingReturnsTrueWhenChipHasPopped()
        {
            var chip = new Chip(1);
            chip.Pop();
            Assert.True(chip.IsAnimating());
            Assert.That(chip.Print(), Is.EqualTo("*"));
            chip.StopAnimating();
            Assert.That(chip.Print(), Is.EqualTo(" "));
        }
    }

    [TestFixture]
    public class ChipAnimatorTests
    {
        [SetUp]
        public void Setup()
        {
            _testObj = new ChipSweeper();
        }

        private ChipSweeper _testObj;

        [Test]
        public void ChipsAreAnimatingReturnsTrueAfterChipsBeginToPop()
        {
            var board = new BoardTestFactory(2).Create(new List<int>() {
                0, 0,
                1, 0
            });

            new ChipPopper().Go(board);
            Assert.True(_testObj.HasPendingChips(board));
        }

        [Test]
        public void ChipsAreAnimatingReturnsFalseAfterSweeping()
        {
            var board = new BoardTestFactory(2).Create(new List<int>() {
                0, 0,
                1, 0
            });

           _testObj.Go(board);
            Assert.False(_testObj.HasPendingChips(board));
        }
    }

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
            _testObj.Go(board);

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
                    _testObj.Go(board);
                    Assert.False(board.GetChip(row, column).HasValue);
                }
            }
        }

        [Test]
        public void ChipValueOfOnePopsInAOneByOne()
        {
            var board = new Board(1);
            board.PlaceChip(0, 0, new Chip(1));

            _testObj.Go(board);

            Assert.False(board.GetChip(0, 0).HasValue);
        }

        [Test]
        public void ChipsPopInBothRowAndColumn()
        {
            var board = new BoardTestFactory(2).Create(new List<int>() {2, 2, 2, 2});
            _testObj.Go(board);

            foreach (var chip in board.All())
            {
                Assert.False(chip.HasValue);
            }
        }

        [Test]
        public void ChipsMustBeNeighborsToBeConsideredForPopping()
        {
            var board = new BoardTestFactory(3).Create(new List<int>()
            {
                0, 0, 0,
                0, 0, 0,
                2, 0, 2
            });
            _testObj.Go(board);
            Assert.True(board.GetChip(2, 0).HasValue);
            Assert.True(board.GetChip(2, 2).HasValue);
        }

        [Test]
        public void ChipsThatAreNotNeigborsCountTheWholeRow()
        {
            var board = new BoardTestFactory(4).Create(new List<int>() {
                0, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 0,
                2, 2, 0, 1
            });
            _testObj.Go(board);
            Assert.False(board.GetChip(3, 0).HasValue);
            Assert.False(board.GetChip(3, 1).HasValue);
            Assert.False(board.GetChip(3, 3).HasValue);
        }

        [Test]
        public void ChipsThatArBlocksAreConsideredContiguous()
        {
            var board = new BoardTestFactory(3).Create(new List<int>() {
                0, 0, 0, 
                0, 0, 0, 
                3, -1, 3
            });
            _testObj.Go(board);
            Assert.False(board.GetChip(2, 0).HasValue);
            Assert.True(board.GetChip(2, 1).HasValue);
            Assert.False(board.GetChip(2, 2).HasValue);
        }

        [Test]
        public void PopWholeRow()
        {
            var board = new BoardTestFactory(3).Create(new List<int>() {
                0, 0, 0,
                3, 0, 0,
                3, 3, 3
            });
            _testObj.Go(board);
            Assert.True(board.GetChip(1, 0).HasValue);
            Assert.False(board.GetChip(2, 0).HasValue);
            Assert.False(board.GetChip(2, 1).HasValue);
            Assert.False(board.GetChip(2, 2).HasValue);
        }

        [Test]
        public void GetPoppableChipsReturnsListOfChips()
        {
            var board = new BoardTestFactory(2).Create(new List<int>() {
                0, 0,
                1, 0
            });
            var result = _testObj.GetPoppableChips(board);
            
            Assert.That(result.First().Value, Is.EqualTo(1));
        }
    }
}