using Darker.States;
using NUnit.Framework;

namespace Darker.Common.Tests
{
    [TestFixture]
    public class StateMachineTests
    {
        [SetUp]
        public void SetUp()
        {
            _states = new StateMachine();
        }

        private StateMachine _states;

        [Test]
        public void Changed_Event_Fires()
        {
            var newState = "RUNNING";
            _states.Changed += (o, a) =>
            {
                Assert.AreEqual(newState, a.New);
                Assert.AreEqual(StateMachine.Idle, a.Previous);
            };
            _states.Current = newState;
            Assert.AreEqual(newState, _states.Current);
        }

        [Test]
        public void StateMachine_Starts_Idle()
        {
            Assert.AreEqual(StateMachine.Idle, _states.Current);
        }
    }
}