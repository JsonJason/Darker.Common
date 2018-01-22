namespace Darker.Common
{
    /// <summary>
    ///     Factory pattern for create letter writing commands
    /// </summary>
    public class MessageWriterCommandFactory
    {
        private readonly IVirtualKeyboard _keyboard;

        /// <summary>
        ///     Constructs a command factory
        /// </summary>
        /// <param name="keyboard">The virtual keyboard to type onto</param>
        public MessageWriterCommandFactory(IVirtualKeyboard keyboard)
        {
            _keyboard = keyboard;
        }

        /// <summary>
        ///     Creates a letter typing command
        /// </summary>
        /// <param name="letter">The letter to create a type command for</param>
        /// <returns>A new typing command</returns>
        public Command CreateLetterCommand(char letter)
        {
            return new WriteLetterCommand(_keyboard, letter);
        }

        /// <summary>
        ///     Creates a special key command
        /// </summary>
        /// <param name="key">The key to create a command for</param>
        /// <returns>A new typing command</returns>
        public Command CreateSpecialKeyCommand(SpecialKeys key)
        {
            return new WriteSpecialKeyCommand(_keyboard, key);
        }
    }
}