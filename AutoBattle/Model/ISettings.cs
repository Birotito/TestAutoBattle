using Microsoft.Extensions.Configuration;
using System;

namespace AutoBattle.Model
{
    public interface ISettings
    {
        /// <summary>
        /// Using Lazy<T> will make sure that the object is only instantiated when it is used somewhere in the calling code.
        /// </summary>
        private static readonly Lazy<ISettings> lazy;

        /// <summary>
        /// Instance for Singleton Pattern
        /// </summary>
        public static ISettings Instance { get { return lazy.Value; } }

        /// <summary>
        /// Method to get information from the read JSON Iconfiguration into properties.
        /// </summary>
        /// <param name="configuration"></param>
        public void Configure(IConfiguration configuration);
    }
}
