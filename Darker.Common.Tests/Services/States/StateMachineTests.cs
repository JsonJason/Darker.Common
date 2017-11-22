using Darker.States;
using NUnit.Framework;

namespace Darker.Common.Tests
{
    [TestFixture]
    public class StateMachineTests
    {
        private StateMachine _states;

        [SetUp]
        public void SetUp()
        {
            _states = new StateMachine();
        }

        [Test]
        public void StateMachine_Starts_Idle()
        {
            Assert.AreEqual(StateMachine.Idle, _states.Current);
        }

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
            Assert.AreEqual(newState,_states.Current);
        }
    }
}
