using System;
using NUnit.Framework;

namespace Dropsy
{
    [TestFixture]
    public class ChipPopperTests
    {
        private ChipPopper _testObj;

        [SetUp]
        public void Setup()
        {
            _testObj = new ChipPopper();
        }

        [Test]
        public void ChipValueOfOnePopsInAOneByOne()
        {
            var board = new Board(1);
            board.PlaceChip(0,0, new Chip(1));

            _testObj.PopChips(board);

            Assert.False(board.GetChip(0,0).HasValue());
        }

        [Test]
        public void ChipOfValueOnePopsOnABigBoard()
        {
            var board = new Board(3);

            for (int row = 0; row < 3; row++)
            {
                for(int column = 0; column < 3; column++)
                {
                    board.PlaceChip(row, column, new Chip(1));
                    _testObj.PopChips(board);
                    Assert.False(board.GetChip(row, column).HasValue());
                }
            }





        }
    }
}