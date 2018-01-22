namespace Darker.Common
{
    /// <summary>
    ///     A virtual keyboard that composes other virtual keyboards
    /// </summary>
    public class CompositeVirtualKeyboard : IVirtualKeyboard
    {
        private readonly IVirtualKeyboard[] _keyboards;

        /// <summary>
        ///     Constructs a composite keyboard
        /// </summary>
        /// <param name="keyboards">The keyboards to disseminate commands to</param>
        public CompositeVirtualKeyboard(params IVirtualKeyboard[] keyboards)
        {
            _keyboards = keyboards;
        }

        /// <summary>
        ///     Presses a key on all child keyboards
        /// </summary>
        /// <param name="letter">The letter to press</param>
        public void PressKey(char letter)
        {
            for (var i = 0; i < _keyboards.Length; i++)
                _keyboards[i].PressKey(letter);
        }

        /// <summary>
        ///     Presses a special key on all child keyboards
        /// </summary>
        /// <param name="specialkey">The special key</param>
        public void PressSpecialKey(SpecialKeys specialkey)
        {
            for (var i = 0; i < _keyboards.Length; i++)
                _keyboards[i].PressSpecialKey(specialkey);
        }
    }
}