using NUnit.Framework;

namespace Dropsy
{
    [TestFixture]
    public class ChipTests
    {

        [Test]
        public void IsAnimatingIsFalseForNow()
        {
            var chip = new Chip(1);
            Assert.False(chip.IsAnimating());
        }

        [Test]
        public void IsAnimatingReturnsTrueWhenChipHasPopped()
        {
            var chip = new Chip(1);
            chip.Pop();
            Assert.True(chip.IsAnimating());
            Assert.That(chip.Print(), Is.EqualTo("*"));
            chip.StopAnimating();
            Assert.That(chip.Print(), Is.EqualTo(" "));
        }
    }
}