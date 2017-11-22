using System;
using Darker.States;
using NSubstitute;
using NUnit.Framework;

namespace Darker.Common.Tests
{
    public class TransitioningStateMachineTests
    {
        private TransitioningStateMachine _states;

        [SetUp]
        public void SetUp()
        {
            _states = new TransitioningStateMachine();
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
            Assert.AreEqual(newState, _states.Current);
        }

        [Test]
        public void Registering_Null_Transition_Throws()
        {
            Assert.Throws<NullReferenceException>(
                () => _states.RegisterTransition("SOMESTATE", null));
        }

        [Test]
        public void StateTransition_Exit_Called_On_Exit()
        {
            var transition = Substitute.For<StateTransition>();
            _states.RegisterTransition(StateMachine.Idle, transition);
            _states.Current = "New State";
            transition.Received().Exit();
            transition.DidNotReceive().Enter();
        }

        [Test]
        public void StateTransition_Enter_Called_On_Enter()
        {
            const string RUNNING = "RUNNING";

            var transition = Substitute.For<StateTransition>();
            _states.RegisterTransition(RUNNING, transition);
            _states.Current = RUNNING;
            transition.DidNotReceive().Exit();
            transition.Received().Enter();
        }
    }
}