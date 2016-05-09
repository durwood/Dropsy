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

            _testObj.Pop(board);

            Assert.False(board.GetChip(0,0).HasValue());
        }

        [Test]
        public void ChipOfValueOnePopsOnABigBoard()
        {
            var board = new Board(3);
            board.PlaceChip(0, 0, new Chip(1));

            _testObj.Pop(board);

            Assert.False(board.GetChip(0, 0).HasValue());

        }
    }
}