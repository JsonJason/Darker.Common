using System;

namespace Darker.States
{
    public class StateMachine
    {
        public StateMachine()
        {
            _current = Idle;
        }

        public virtual string Current
        {
            get => _current;
            set
            {
                var args = new StateChangedEventArgs(_current,value);
                _current = value;
                OnChanged(args);
            }
        }

        public event EventHandler<StateChangedEventArgs> Changed; 
        public static string Idle = "IDLE";
        private string _current;

        protected virtual void OnChanged(StateChangedEventArgs e)
        {
            Changed?.Invoke(this, e);
        }
    }

    public class StateChangedEventArgs : EventArgs
    {
        public StateChangedEventArgs(string prevState,string newState)
        {
            Previous = prevState;
            New = newState;
        }
        public string Previous { get; }
        public string New { get; }
    }

}
