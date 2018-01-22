namespace Darker.Common
{
    public abstract class AUIVirtualKeyboard : IVirtualKeyboard
    {
        /// <summary>
        ///     The Source to write text to
        /// </summary>
        protected abstract string CurrentText { get; set; }

        /// <summary>
        ///     Types a key onto a text mesh
        /// </summary>
        /// <param name="letter">The key to type on the text mesh</param>
        public void PressKey(char letter)
        {
            if (letter == ' ')
                PressSpecialKey(SpecialKeys.Spacebar);
            else if (letter == '\n')
                PressSpecialKey(SpecialKeys.Enter);
            else
                CurrentText = WithLetterAdded(CurrentText, letter);
        }

        /// <summary>
        ///     Performs a special key action on a text mesh
        /// </summary>
        /// <param name="specialkey">Special Key to perform</param>
        public void PressSpecialKey(SpecialKeys specialkey)
        {
            if (specialkey == SpecialKeys.Backspace)
                CurrentText = WithLastXLettersRemoved(CurrentText, 1);
            if (specialkey == SpecialKeys.Enter)
                CurrentText = WithANewLineAdded(CurrentText);
            if (specialkey == SpecialKeys.Spacebar)
                CurrentText = WithASpaceAdded(CurrentText);
        }

        #region Implementation

        private string WithLetterAdded(string text, char letter)
        {
            return text + letter;
        }

        private string WithASpaceAdded(string text)
        {
            return text + ' ';
        }

        private string WithANewLineAdded(string text)
        {
            return text + '\n';
        }

        private string WithLastXLettersRemoved(string text, int number)
        {
            if (CurrentText.Length >= number)
                return text.Substring(0, text.Length - number);
            return string.Empty;
        }

        #endregion
    }
}