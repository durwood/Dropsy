using System.Collections.Generic;
using Dropsy.test;
using NUnit.Framework;

namespace Dropsy
{
    [TestFixture]
    public class ChipSweeperTests
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
}