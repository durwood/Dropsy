using System;
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
            var consoleWrapper = new ConsoleWrapper();
            var testObj = new Controller(consoleWrapper, _boxModel);

        }
    }

    public class ConsoleWrapper
    {
        public void Write(string output)
        {
            Console.Write(output);
        }

        public char Read()
        {
            return Console.ReadKey(true).KeyChar;
        }
    }
}