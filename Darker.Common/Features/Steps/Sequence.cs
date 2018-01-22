using System.Collections.Generic;
namespace Darker.Common
{
    /// <summary>
    ///     A sequence of steps. Runs till completion
    /// </summary>
    public class Sequence : Step, Timer
    {
        public string Name { get; set; }

        public Sequence() : this(DEFAULT_NAME)
        {
        }

        public Sequence(string name)
        {
            _steps = new List<Step>();
            Name = name;
        }

        public Sequence AddStep(Step step)
        {
            _steps.Add(step);
            return this;
        }

        public void ClearSteps()
        {
            _steps.Clear();
        }

        public void Update()
        {
            if (!IsRunning) return;

            if (IsComplete || _steps.Count < _currentIndex) return;

            if (!CurrentStep.IsComplete)
            {
                CurrentStep.Update();
            }
            else
            {
                _currentIndex++;

                if (_currentIndex >= _steps.Count)
                {
                    IsComplete = true;
                }
                else
                {
                    CurrentStep.Start();
                    Update();
                }
            }
        }

        #region Timing

        public bool IsRunning { get; private set; }

        public void Pause()
        {
            IsRunning = false;
        }

        public void Restart()
        {
            _currentIndex = 0;
            IsComplete = false;
            IsRunning = true;
            CurrentStep.Start();
        }

        public void Resume()
        {
            IsRunning = true;
        }

        public void Start()
        {
            _currentIndex = 0;
            IsComplete = false;
            IsRunning = true;
            CurrentStep.Start();
        }

        public void Stop()
        {
            IsRunning = false;
        }

        #endregion

        public bool IsComplete { get; private set; }

        public int NumberOfSteps => _steps.Count;

        public Step CurrentStep => _currentIndex < _steps.Count ? _steps[_currentIndex] : null;

        private int _currentIndex;
        private readonly List<Step> _steps;
        private const string DEFAULT_NAME = "Sequence";
    }
}