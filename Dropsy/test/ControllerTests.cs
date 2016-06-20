using System.Linq;
using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    public class ControllerTests
    {
        [SetUp]
        public void Setup()
        {
            CreateTestObj(2);
        }

        private BoxModel _boxModel;
        private TestConsole _consoleWrapper;
        private Controller _testObj;

        private void CreateTestObj(int edgeLength)
        {
            _boxModel = new BoxModel(edgeLength, new UnpoppableChipFactory(), new Board(edgeLength));
            _consoleWrapper = new TestConsole();
            _testObj = new Controller(_consoleWrapper, _boxModel);
        }

        private bool HasChipIn(int row)
        {
            return _boxModel.GetRow(row).Count(chip => chip.HasValue) > 0;
        }

        [Test]
        public void OutputsStuffToConsolOnRun()
        {
            _consoleWrapper.NextChar = new[] {'1', 'q'};
            _testObj.Run();

            Assert.That(_consoleWrapper.NumWrites, Is.EqualTo(2));
        }

        [Test]
        public void RunCanTakeABunchOfInputs()
        {
            _consoleWrapper.NextChar = new[] {'1', '2', '1', 'q'};
            _testObj.Run();
            Assert.That(_consoleWrapper.NumReads, Is.EqualTo(4));
            Assert.True(HasChipIn(1));
        }

        [Test]
        public void RunStopsWhenBoardIsFull()
        {
            CreateTestObj(2);
            _consoleWrapper.NextChar = new[]
            {
                '1',
                '1',
                '2',
                '2'
            };
            _testObj.Run();
            Assert.That(_consoleWrapper.NumWrites, Is.EqualTo(4));
        }

        [Test]
        public void RunTakesUsersInputAndTellsModelAColumn()
        {
            _consoleWrapper.NextChar = new[] {'2', 'q'};
            _testObj.Run();
            Assert.That(_consoleWrapper.NumReads, Is.EqualTo(2));
            Assert.True(HasChipIn(1));
        }
    }

    public class TestConsole : IConsoleWrapper
    {
        public int NumReads;
        public int NumWrites;
        public char[] NextChar { get; set; }

        public void Write(string output)
        {
            NumWrites++;
        }

        public char Read()
        {
            return NextChar[NumReads++];
        }

        public void Clear()
        {
        }
    }
}