using FluentAssertions;
using NUnit.Framework;

namespace BoxCorp.App.Tests
{
    [TestFixture]
    public class BoxTests
    {
        Box _boxBlue, _boxGreen, _boxYellow, _boxPurple;

        [OneTimeSetUp]
        public void Setup()
        {
            _boxBlue = new Box(1, 2, 2, 6, 5, 0.8M);
            _boxGreen = new Box(2, 3, 3, 6, 4, 0.6M);
            _boxYellow = new Box(3, 2, 8, 4, 3, 0.9M);
            _boxPurple = new Box(4, 8, 9, 2, 2, 0.3M);
        }

        [Test]
        public void JaqardIndexCalculationShouldWork()
        {
            var jaqardIndex = _boxBlue.JaqardIndexWith(_boxGreen);

            jaqardIndex.Should().Be(0.58);

            jaqardIndex = _boxGreen.JaqardIndexWith(_boxBlue);

            jaqardIndex.Should().Be(0.58);
        }
    }
}
