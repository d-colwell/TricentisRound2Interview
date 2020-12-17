using FluentAssertions;
using NUnit.Framework;

namespace BoxCorp.App.Tests 
{
    [TestFixture]
    public class BoxDecisioningTests 
    {
        private BoxDecisioning _boxDecisioning;

        [SetUp]
        public void Setup()
        {
            _boxDecisioning = new BoxDecisioning();
        }

        [Test]
        public void PushNewBoxShouldIncreaseBoxNumber() 
        {
            _boxDecisioning.BoxCount.Should().Be(0);

            _boxDecisioning.Push(1, new Box(1, 0, 0, 1, 1, 0.5M));

            _boxDecisioning.BoxCount.Should().Be(1);
        }

        [Test]
        public void PushNewBoxWithLowRankShouldNotIncreaseBoxNumber() 
        {
            _boxDecisioning.BoxCount.Should().Be(0);

            _boxDecisioning.Push(1, new Box(1, 0, 0, 1, 1, 0.4M));

            _boxDecisioning.BoxCount.Should().Be(0);
        }
    }
}
