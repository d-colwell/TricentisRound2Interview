using FluentAssertions;
using NUnit.Framework;

namespace BoxCorp.App.Tests 
{
    [TestFixture]
    public class BoxDecisioningTests 
    {
        private BoxDecisioning _boxDecisioning;

        [OneTimeSetUp]
        public void Setup()
        {
            _boxDecisioning = new BoxDecisioning();
        }

        [Test]
        public void PushNewBoxShouldIncreaseBoxNumber() 
        {
            _boxDecisioning.BoxCount.Should().Be(0);

            _boxDecisioning.Push(new Box(0, 0, 1, 1, 0.5M));

            _boxDecisioning.BoxCount.Should().Be(1);
        }


    }
}
