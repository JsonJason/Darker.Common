namespace DarkerSmile.Progress
{
    public class ProgressPercent : Progress
    {
        /// <summary>
        ///     The current completion percent
        /// </summary>
        public float Percent { get; set; }

        /// <summary>
        ///     A friendly string representation of the
        ///     progress percent
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}%", Percent);
        }
    }
}