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
            _consoleWrapper.NextChar = new[] {'1'};
            _testObj.Run();

            Assert.That(_consoleWrapper.NumWrites, Is.EqualTo(2));
        }

        [Test]
        public void RunAllowsTwoConsecutiveChipsToBeDropped()
        {
            _consoleWrapper.NextChar = new[] {'1', '2'};
            _testObj.Run();
            Assert.That(_consoleWrapper.NumReads, Is.EqualTo(2));
            Assert.True(_boxModel.HasChipIn(0));
            Assert.True(_boxModel.HasChipIn(1));
        }

        [Test]
        public void RunTakesUsersInputAndTellsModelAColumn()
        {
            _consoleWrapper.NextChar = new[] {'2'};
            _testObj.Run();
            Assert.That(_consoleWrapper.NumReads, Is.EqualTo(1));
            Assert.True(_boxModel.HasChipIn(1));
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