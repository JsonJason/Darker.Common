namespace Darker.Common
{
    /// <summary>
    ///     A Unit of work that you can run till completion
    /// </summary>
    public interface Step
    {
        /// <summary>
        ///     Start this step
        /// </summary>
        void Start();

        /// <summary>
        ///     Update this step
        /// </summary>
        void Update();

        /// <summary>
        ///     This step has completed
        /// </summary>
        bool IsComplete { get; }
    }
}