using Dropsy.test;
using NUnit.Framework.Api;

namespace Dropsy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int edgeLength = 7;
            var model = new BoxModel(edgeLength, new ChipFactory());
            var controller = new Controller(new ConsoleWrapper(), model);
            controller.Run();
        }
    }
}