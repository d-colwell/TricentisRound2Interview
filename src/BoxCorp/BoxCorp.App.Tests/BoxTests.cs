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
            _boxBlue = new Box(2, 2, 6, 5, 0.8M);
            _boxGreen = new Box(3, 3, 6, 4, 0.6M);
            _boxYellow = new Box(2, 8, 4, 3, 0.9M);
            _boxPurple = new Box(8, 9, 2, 2, 0.3M);
        }

        [Test]
        public void JaqardIndexCalculationShouldWork()
        {
            var jaqardIndex = _boxBlue.JaqardIndexWith(_boxGreen);

            jaqardIndex.Should().Be(0.58);

            jaqardIndex = _boxGreen.JaqardIndexWith(_boxBlue);

            jaqardIndex.Should().Be(0.58);
        }

        [Test]
        public void CompareShouldHaveNoResultWhenBoxesHaveNoIntersect()
        {
            var result = _boxYellow.CompareTo(_boxBlue);

            result.Should().Be(0);
        }

        [Test]
        public void BoxWithLowerRankShouldBeIgnoredWhenJaqardIndexGreaThanThreshold()
        {
            var result = _boxBlue.CompareTo(_boxGreen);

            result.Should().Be(1);
            _boxGreen.Ignored.Should().BeTrue();
            _boxBlue.Ignored.Should().BeFalse();

            result = _boxGreen.CompareTo(_boxBlue);
            result.Should().Be(-1);
            _boxGreen.Ignored.Should().BeTrue();
            _boxBlue.Ignored.Should().BeFalse();
        }
    }
}
