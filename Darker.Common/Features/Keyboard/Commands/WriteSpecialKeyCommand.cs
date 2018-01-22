namespace Darker.Common
{
    /// <summary>
    ///     A command pattern for writing a key onto a virtual keyboard
    /// </summary>
    public class WriteSpecialKeyCommand : Command
    {
        private readonly IVirtualKeyboard _keyboard;
        private readonly SpecialKeys _key;

        /// <summary>
        ///     Constructs a special key command
        /// </summary>
        /// <param name="keyboard">The keyboard to type onto</param>
        /// <param name="key">The key to type</param>
        public WriteSpecialKeyCommand(IVirtualKeyboard keyboard, SpecialKeys key)
        {
            _key = key;
            _keyboard = keyboard;
        }

        /// <summary>
        ///     Executes the command
        /// </summary>
        public void Execute()
        {
            _keyboard.PressSpecialKey(_key);
        }
    }
}