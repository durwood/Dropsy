using NUnit.Framework;

namespace Dropsy.test
{
    [TestFixture]
    internal class BoxPrinterTest
    {
        [Test]
        public void OneByOnePrintsCorrectly()
        {
            var testObject = new BoxPrinter();
            var model = new BoxModel(1);
            var topLine = PrintConstants.UpperLeft.ToString() + PrintConstants.HorizontalBar +
                          PrintConstants.HorizontalBar +
                          PrintConstants.HorizontalBar + PrintConstants.UpperRight + "\n";
            var middleLine = PrintConstants.VerticalBar + "   " + PrintConstants.VerticalBar + "\n";
            var bottomLine = PrintConstants.LowerLeft.ToString() + PrintConstants.HorizontalBar +
                             PrintConstants.HorizontalBar +
                             PrintConstants.HorizontalBar + PrintConstants.LowerRight + "\n";
            Assert.That(testObject.Print(model), Is.EqualTo(topLine + middleLine + bottomLine));
        }
    }

    public class BoxModel
    {
        public readonly int EdgeLength;

        public BoxModel(int edgeLength)
        {
            EdgeLength = edgeLength;
        }
    }
}