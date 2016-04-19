using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    public class BoxModelTests
    {
        private BoxModel _testObj;

        [SetUp]
        public void Setup()
        {
            _testObj = new BoxModel(3, new ChipFactory());
        }

        [Test]
        public void GameOverReturnsFalseWhenBoardIsFresh()
        {
            Assert.False(_testObj.GameOver());
        }

        [Test]
        public void GameOverReturnsFalseWhenBoardNotFull()
        {
            _testObj = new BoxModel(2,new ChipFactory());
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(0);
            _testObj.PutChipOnBoard(1);
            Assert.False(_testObj.GameOver());
        }

        [Test]
        public void GameOverReturnsTrueWhenBoardIsFull()
        {
            _testObj = new BoxModel(1, new ChipFactory());
            _testObj.PutChipOnBoard(0);
            Assert.True(_testObj.GameOver());
        }

        [Test]
        public void HasNoChipTrueByDefault()
        {
            Assert.True(_testObj.HasNoUnplacedChip());
        }

        [Test]
        public void HasChipInAndPutChipInEndToEnd()
        {
            _testObj.PutChipOnBoard(2);
            HasChipInRow(2);
        }

        [Test]
        public void TwoChipsCanGoInSameColumn()
        {
            _testObj = new BoxModel(2, new ChipFactory());
            _testObj.PutChipOnBoard(1);
            _testObj.PutChipOnBoard(1);

            HasChipInRow(1);
            Assert.That(_testObj.GetRow(0).Count(n => n.print() != " "), Is.EqualTo(1));
        }

        private void HasChipInRow(int row)
        {
            Assert.That(_testObj.GetRow(row).Count(n => n.print() != " "), Is.EqualTo(1));
        }
    }
}   