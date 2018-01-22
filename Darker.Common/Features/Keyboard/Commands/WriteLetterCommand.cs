namespace Darker.Common
{
    /// <summary>
    ///     A Command pattern that types a key onto a virtual keyboard
    /// </summary>
    public class WriteLetterCommand : Command
    {
        private readonly IVirtualKeyboard _keyboard;
        private readonly char _letter;

        /// <summary>
        ///     Constructs a letter writing command
        /// </summary>
        /// <param name="keyboard">The keyboard to type onto</param>
        /// <param name="letter">The letter to type</param>
        public WriteLetterCommand(IVirtualKeyboard keyboard, char letter)
        {
            _letter = letter;
            _keyboard = keyboard;
        }

        /// <summary>
        ///     Executes the command
        /// </summary>
        public void Execute()
        {
            _keyboard.PressKey(_letter);
        }
    }
}