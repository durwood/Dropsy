using System.Collections.Generic;
using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    public class ChipDropperTests
    {
        [Test]
        public void DropChipsMovesAChipDown()
        {
            var board = new BoardTestFactory(2).Create(new List<int>()
            {
                0, 1,
                0, 0
            });
            new ChipDropper().DropChips(board);

            Assert.True(board.GetChip(1, 1).HasValue);
        }

        [Test]
        public void DropChipsMovesTwoChipsDown()
        {
            var board = new BoardTestFactory(3).Create(new List<int>()
            {
                0, 0, 2,
                0, 0, 2,
                0, 0, 0
            });
            new ChipDropper().DropChips(board);

            Assert.True(board.GetChip(2, 2).HasValue);
            Assert.True(board.GetChip(1, 2).HasValue);
            Assert.False(board.GetChip(0, 2).HasValue);
        }

        [Test]
        public void DropChipsDoesNothingForOkBoard()
        {
            var board = new BoardTestFactory(2).Create(new List<int>()
            {
                0, 0,
                1, 1
            });
            new ChipDropper().DropChips(board);

            Assert.True(board.GetChip(1, 1).HasValue);
            Assert.True(board.GetChip(1, 0).HasValue);
        }

        [Test]
        public void DropChipsDropAChipTwoSpaces()
        {
            var board = new BoardTestFactory(3).Create(new List<int>()
            {
                0, 0, 2,
                0, 0, 0,
                0, 0, 0
            });
            new ChipDropper().DropChips(board);

            Assert.True(board.GetChip(2, 2).HasValue);
            Assert.False(board.GetChip(1, 2).HasValue);
            Assert.False(board.GetChip(0, 2).HasValue);
        }

        [Test]
        public void DropChipsWorksTwice()
        {
            var board = new BoardTestFactory(3).Create(new List<int>()
            {
                0, 0, 2,
                0, 0, 0,
                0, 0, -1
            });
            new ChipDropper().DropChips(board);
            new ChipDropper().DropChips(board);

            Assert.True(board.GetChip(2, 2).HasValue);
            Assert.True(board.GetChip(1, 2).HasValue);
            Assert.False(board.GetChip(0, 2).HasValue);
        }
    }
}