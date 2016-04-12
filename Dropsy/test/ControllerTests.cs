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
            _consoleWrapper.NextChar = '1';
            _testObj.Run();

            Assert.That(_consoleWrapper.NumWrites, Is.EqualTo(2));
        }

        [Test]
        public void RunTakesUsersInputAndTellsModelAColumn()
        {
            _consoleWrapper.NextChar = '2';
            _testObj.Run();
            Assert.That(_consoleWrapper.NumReads, Is.EqualTo(1));
            Assert.True(_boxModel.HasChipIn(1));
        }
    }

    public class TestConsole : ConsoleWrapper
    {
        public int NumWrites;
        public int NumReads;
        public char NextChar { get; set; }

        public override void Write(string output)
        {
            NumWrites++;
        }

        public override char Read()
        {
            NumReads++;
            return NextChar;
        }
        
    }
}