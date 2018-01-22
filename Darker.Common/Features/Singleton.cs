namespace DarkerSmile.Common
{
    /// <summary>
    ///     An abstract base class for  (non enforced!) singleton object access
    /// </summary>
    /// <typeparam name="T">The Type of the parent singleton</typeparam>
    public abstract class Singleton<T> where T : class, new()
    {
        private static T _instance;

        /// <summary>
        /// Singleton Instance
        /// </summary>
        public static T Instance
        {
            get { return _instance ?? (_instance = new T()); }
        }
    }

    /// <summary>
    ///     An abstract base class for  (non enforced!) singleton object access
    /// </summary>
    /// <typeparam name="T">The Type of the parent singleton</typeparam>
    /// <typeparam name="TX">The implemented interface type of the parent singleton</typeparam>
    public abstract class Singleton<T, TX>
        where TX : class
        where T : class, TX, new()
    {
        private static T _instance;

        /// <summary>
        /// Singleton Instance
        /// </summary>
        public static TX Instance
        {
            get { return _instance ?? (_instance = new T()); }
        }
    }
}