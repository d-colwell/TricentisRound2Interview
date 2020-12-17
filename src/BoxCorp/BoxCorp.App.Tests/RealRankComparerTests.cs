using FluentAssertions;
using NUnit.Framework;
namespace BoxCorp.App.Tests
{
    [TestFixture]
    public class RealRankComparerTests
    {
        Box _boxBlue, _boxGreen, _boxYellow, _boxPurple;

        RealRankComparer _realRankComparer;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _boxBlue = new Box(1, 2, 2, 6, 5, 0.8M);
            _boxGreen = new Box(2, 3, 3, 6, 4, 0.6M);
            _boxYellow = new Box(3, 2, 8, 4, 3, 0.9M);
            _boxPurple = new Box(4, 8, 9, 2, 2, 0.3M);

            _realRankComparer = new RealRankComparer();
        }

        [SetUp]
        public void Setup()
        {
            _boxBlue = new Box(1, 2, 2, 6, 5, 0.8M);
            _boxGreen = new Box(2, 3, 3, 6, 4, 0.6M);
            _boxYellow = new Box(3, 2, 8, 4, 3, 0.9M);
            _boxPurple = new Box(4, 8, 9, 2, 2, 0.3M);

            _realRankComparer = new RealRankComparer();
        }

        [Test]
        public void CompareShouldHaveNoResultWhenBoxesHaveNoIntersect()
        {
            var result = _realRankComparer.Compare(_boxYellow, _boxBlue);

            result.Should().Be(0);
            _realRankComparer.IgnoredBoxes.Should().BeEmpty();
        }

        [Test]
        public void BoxWithLowerRankShouldBeIgnoredWhenJaqardIndexGreatThanThreshold()
        {
            var result = _realRankComparer.Compare(_boxBlue, _boxGreen);

            result.Should().Be(1);

            _realRankComparer.IgnoredBoxes.Should().HaveCount(1);
            _realRankComparer.IgnoredBoxes.Should().Contain(_boxGreen.Id);
            _realRankComparer.IgnoredBoxes.Should().NotContain(_boxBlue.Id);
        }

        [Test]
        public void BoxWithLowerRankShouldBeIgnoredWhenJaqardIndexGreatThanThresholdReverse()
        {
            var result = _realRankComparer.Compare(_boxGreen, _boxBlue);
            result.Should().Be(-1);

            _realRankComparer.IgnoredBoxes.Should().HaveCount(1);
            _realRankComparer.IgnoredBoxes.Should().Contain(_boxGreen.Id);
            _realRankComparer.IgnoredBoxes.Should().NotContain(_boxBlue.Id);
        }
    }
}
