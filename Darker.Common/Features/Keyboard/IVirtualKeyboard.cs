namespace Darker.Common
{
    /// <summary>
    ///     A Typable virtual keyboard
    /// </summary>
    public interface IVirtualKeyboard
    {
        /// <summary>
        ///     Press a character on the virtual keyboard
        /// </summary>
        /// <param name="letter">Letter to type</param>
        void PressKey(char letter);

        /// <summary>
        ///     Press a special key or function button on the keyboard
        /// </summary>
        /// <param name="specialkey">Function key to press</param>
        void PressSpecialKey(SpecialKeys specialkey);
    }

    /// <summary>
    ///     Special Keyboard Function Keys
    /// </summary>
    public enum SpecialKeys
    {
        Backspace,
        Spacebar,
        Enter,
        Escape,
        Ctrl,
        Shift,
        Tab
    }
}