using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    public class ControllerTests
    {
        private BoxModel _boxModel;

        [Test]
        public void OutputsStuffToConsolOnRun()
        {
            _boxModel = new BoxModel(2);
            var consoleWrapper = new TestConsole();
            var testObj = new Controller(consoleWrapper, _boxModel);
            testObj.Run();

            Assert.That(consoleWrapper.Outputs, Is.EqualTo(1));
        }
    }

    public class TestConsole : ConsoleWrapper
    {
        public int Outputs = 0;

        public override void Write(string output)
        {
            Outputs++;
        }

        public override char Read()
        {
            return 's';
        }
    }
}