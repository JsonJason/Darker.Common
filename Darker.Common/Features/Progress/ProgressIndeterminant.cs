namespace DarkerSmile.Progress
{
    /// <summary>
    ///     A progress which cannot be determined
    /// </summary>
    public class ProgressIndeterminant : Progress
    {
        public float Percent
        {
            get { return 0; }
        }

        public override string ToString()
        {
            return "Indeterminant";
        }

        /// <summary>
        ///     The singleton instance
        /// </summary>
        public static Progress Instance
        {
            get { return _progress ?? (_progress = new ProgressIndeterminant()); }
        }

        private static Progress _progress;
    }
}