using System;

namespace AutoBattle.Core
{
    /// <summary>
    /// Encapsulates the System.Random under a Singleton pattern to be a single static point of access from across the system.
    /// </summary>
    public sealed class Random
    {
        /// <summary>
        /// Using Lazy<T> will make sure that the object is only instantiated when it is used somewhere in the calling code.
        /// </summary>
        private static readonly Lazy<Random> lazy = new Lazy<Random>(() => new Random());

        /// <summary>
        /// Instance for Singleton Pattern
        /// </summary>
        public static Random Instance { get { return lazy.Value; } }

        private System.Random m_Random { get; set; }

        /// <summary>
        /// Construction with no parameter. GUID is used to not get a pseudo random.
        /// </summary>
        private Random() => m_Random = new System.Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// Encapsulates the random method
        /// </summary>
        /// <returns>Return a random integer</returns>
        public int Next() => m_Random.Next();

        /// <summary>
        /// Encapsulates the random method with a maximum value
        /// </summary>
        /// <param name="_MaxNumber">The highest possible value that can be returned</param>
        /// <returns>Return a random integer within the max value</returns>
        public int Next(int _MaxNumber) => m_Random.Next(_MaxNumber);

        /// <summary>
        /// Encapsulates the random method with a maximum value and minimum
        /// </summary>
        /// <param name="_MinNumber">The lowest possible value that can be returned</param>
        /// <param name="_MaxNumber">The highest possible value that can be returned</param>
        /// <returns>Return a random integer within the max and minimum value</returns>
        public int Next(int _MinNumber, int _MaxNumber) => m_Random.Next(_MinNumber, _MaxNumber);

        /// <summary>
        /// Encapsulates the random method with a maximum value
        /// </summary>
        /// <param name="_MaxNumber">The highest possible value that can be returned</param>
        /// <returns>Return a random integer within the max value</returns>
        public Int16 Next(Int16 _MaxNumber) => (Int16)m_Random.Next(_MaxNumber);

        /// <summary>
        /// Encapsulates the random method with a maximum value and minimum
        /// </summary>
        /// <param name="_MinNumber">The lowest possible value that can be returned</param>
        /// <param name="_MaxNumber">The highest possible value that can be returned</param>
        /// <returns>Return a random integer within the max and minimum value</returns>
        public Int16 Next(Int16 _MinNumber, Int16 _MaxNumber) => (Int16)m_Random.Next(_MinNumber, _MaxNumber);

        /// <summary>
        /// Encapsulates the random method with a maximum value
        /// </summary>
        /// <param name="_MaxNumber">The highest possible value that can be returned</param>
        /// <returns>Return a random integer within the max value</returns>
        public sbyte Next(sbyte _MaxNumber) => (sbyte)m_Random.Next(_MaxNumber);

        /// <summary>
        /// Encapsulates the random method with a maximum value and minimum
        /// </summary>
        /// <param name="_MinNumber">The lowest possible value that can be returned</param>
        /// <param name="_MaxNumber">The highest possible value that can be returned</param>
        /// <returns>Return a random integer within the max and minimum value</returns>
        public sbyte Next(sbyte _MinNumber, sbyte _MaxNumber) => (sbyte)m_Random.Next(_MinNumber, _MaxNumber);


    }
}
