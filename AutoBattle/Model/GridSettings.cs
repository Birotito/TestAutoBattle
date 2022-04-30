using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AutoBattle.Model
{
    /// <summary>
    /// Data model to read from Grid Settings data structure
    /// </summary>
    public sealed class GridSettings : IGridSettings
    {
        /// <summary>
        /// Using Lazy<T> will make sure that the object is only instantiated when it is used somewhere in the calling code.
        /// </summary>
        private static readonly Lazy<GridSettings> lazy = new Lazy<GridSettings>(() => new GridSettings());
        /// <summary>
        /// Instance for Singleton Pattern
        /// </summary>
        public static GridSettings Instance { get { return lazy.Value; } }

        /// <summary>
        /// Method to get information from the read JSON Iconfiguration into properties.
        /// </summary>
        /// <param name="configuration"></param>
        public void Configure(IConfiguration configuration)
        {
            //TODO: Check the best way to handle error, or if a key was deleted from file.
            try
            {
                MinYSize = Convert.ToInt32(configuration["MinYSize"]);
                MaxYSize = Convert.ToInt32(configuration["MaxYSize"]);
                MinXSize = Convert.ToInt32(configuration["MinXSize"]);
                MaxXSize = Convert.ToInt32(configuration["MaxXSize"]);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurred an error when trying to load the settings file. Please check if the file is in the correct folder. Trace: " + ex.Message);
            }
        }

        /// <summary>
        /// Minimum Y Size from the battlefield
        /// </summary>
        public int MinYSize { get; set; }
        /// <summary>
        /// Maximum Y Size from the battlefield
        /// </summary>
        public int MaxYSize { get; set; }
        /// <summary>
        /// Minimum Y Size from the battlefield
        /// </summary>
        public int MinXSize { get; set; }
        /// <summary>
        /// Maximum X Size from the battlefield
        /// </summary>
        public int MaxXSize { get; set; }
    }
}
