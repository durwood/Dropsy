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
            _boxModel = new BoxModel(2);
            _consoleWrapper = new TestConsole();
            _testObj = new Controller(_consoleWrapper, _boxModel);
        }

        private BoxModel _boxModel;
        private TestConsole _consoleWrapper;
        private Controller _testObj;

        [Test]
        public void OutputsStuffToConsolOnRun()
        {
            _consoleWrapper.NextChar = new[] {'1', 'q' };
            _testObj.Run();

            Assert.That(_consoleWrapper.NumWrites, Is.EqualTo(2));
        }

        [Test]
        public void RunCanTakeABunchOfInputs()
        {
            _consoleWrapper.NextChar = new[] {'1', '2','1', '2', 'q'};
            _testObj.Run();
            Assert.That(_consoleWrapper.NumReads, Is.EqualTo(5));
            Assert.True(HasChipIn(0));
            Assert.True(HasChipIn(1));
        }

        [Test]
        public void RunTakesUsersInputAndTellsModelAColumn()
        {
            _consoleWrapper.NextChar = new[] {'2', 'q'};
            _testObj.Run();
            Assert.That(_consoleWrapper.NumReads, Is.EqualTo(2));
            Assert.True(HasChipIn(1));
        }

        private bool HasChipIn(int row)
        {
            return _boxModel.GetRow(row).Count(chip => chip.HasValue()) > 0;
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