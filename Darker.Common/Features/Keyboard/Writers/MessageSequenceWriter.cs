namespace Darker.Common
{
    /// <summary>
    ///     Types a text copy to a virtual keyboard
    /// </summary>
    public class SimpleMessageWriter
    {
        private readonly IVirtualKeyboard _keyboard;

        /// <summary>
        ///     Constructs a message writer
        /// </summary>
        /// <param name="keyboard">Virtual Keyboard to write to</param>
        public SimpleMessageWriter(IVirtualKeyboard keyboard)
        {
            _keyboard = keyboard;
        }

        /// <summary>
        ///     Has some steps (letters/special key actions) remaining to perform
        /// </summary>
        public bool HasStepsRemaining { get; private set; }

        /// <summary>
        ///     Assigns the text copy to be written
        /// </summary>
        /// <param name="message">Message to write on the  virtual keyboard</param>
        public void SetCopy(string message)
        {
            _copy = message;
            currentLetterIndex = 0;
            HasStepsRemaining = true;
        }

        /// <summary>
        ///     Performs the next step action to be done on the virtual keyboard
        /// </summary>
        public void PerformNextStep()
        {
            if (currentLetterIndex >= _copy.Length - 1) HasStepsRemaining = false;
            WriteKey(_copy[currentLetterIndex++]);
        }

        #region Implementation

        private void WriteKey(char key)
        {
            if (key.Equals(' '))
                _keyboard.PressSpecialKey(SpecialKeys.Spacebar);
            else
                _keyboard.PressKey(key);
        }

        private string _copy;
        private int currentLetterIndex;

        #endregion
    }
}