using System;
using System.Collections.Generic;

namespace Darker.States
{
    public class TransitioningStateMachine : StateMachine
    {
        private readonly Dictionary<string, StateTransition> _transitions;

        public TransitioningStateMachine()
        {
            _transitions = new Dictionary<string, StateTransition>();
        }

        public void RegisterTransition(string state, StateTransition transition)
        {
            if (transition == null)
                throw new NullReferenceException($"Cannot register null transition for state: {state}");
            _transitions.Add(state, transition);
        }

        protected override void OnChanged(StateChangedEventArgs e)
        {
            Get(e.Previous).Exit();
            Get(e.New).Enter();
        }

        private StateTransition Get(string stateName) => _transitions.ContainsKey(stateName)
            ? _transitions[stateName]
            : EmptyStateTransition.Instance;
    }


    public class EmptyStateTransition : StateTransition
    {
        private static EmptyStateTransition _instance;

        public static EmptyStateTransition Instance => _instance ?? (_instance = new EmptyStateTransition());

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }

    public interface StateTransition
    {
        void Enter();
        void Exit();
    }
}