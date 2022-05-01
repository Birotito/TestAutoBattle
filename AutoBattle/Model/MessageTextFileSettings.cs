using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    /// <summary>
    /// Data model to read from message text file settings  data structure
    /// </summary>
    public sealed class MessageTextFileSettings : IMessageTextFileSettings
    {
        /// <summary>
        /// Using Lazy<T> will make sure that the object is only instantiated when it is used somewhere in the calling code.
        /// </summary>
        private static readonly Lazy<MessageTextFileSettings> lazy = new Lazy<MessageTextFileSettings>(() => new MessageTextFileSettings());
        /// <summary>
        /// Instance for Singleton Pattern
        /// </summary>
        public static MessageTextFileSettings Instance { get { return lazy.Value; } }

        /// <summary>
        /// Method to get information from the read JSON Iconfiguration into properties.
        /// </summary>
        /// <param name="configuration"></param>
        public void Configure(IConfiguration configuration)
        {
            try
            {
                Language = configuration["Language"];
                Path = configuration["Path"];
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurred an error when trying to load the settings file. Please check if the file is in the correct folder. Trace: " + ex.Message);
            }
        }

        /// <summary>
        /// Language tag that we are using. Right now not beign used;
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// Path for the desired text file.
        /// </summary>
        public string Path { get; set; }


    }
}
