using System;
using System.Collections.Generic;
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
                MinYSize = Convert.ToSByte(configuration["MinYSize"]);
                MaxYSize = Convert.ToSByte(configuration["MaxYSize"]);
                MinXSize = Convert.ToSByte(configuration["MinXSize"]);
                MaxXSize = Convert.ToSByte(configuration["MaxXSize"]);
                RandomGridName = configuration["RandomGridName"];

                PredefinedGridOptions = configuration.GetSection("PredefinedGridOptions").Get<List<PredefinedGridOptions>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurred an error when trying to load the settings file. Please check if the file is in the correct folder. Trace: " + ex.Message);
            }
        }

        /// <summary>
        /// Minimum Y Size from the battlefield
        /// </summary>
        public sbyte MinYSize { get; set; }
        /// <summary>
        /// Maximum Y Size from the battlefield
        /// </summary>
        public sbyte MaxYSize { get; set; }
        /// <summary>
        /// Minimum Y Size from the battlefield
        /// </summary>
        public sbyte MinXSize { get; set; }
        /// <summary>
        /// Maximum X Size from the battlefield
        /// </summary>
        public sbyte MaxXSize { get; set; }
        /// <summary>
        /// Name to be exhibit to the player when choosing a random grid. If no predefined grid exists on the setting file, this grid is automatically selected
        /// </summary>
        public string RandomGridName { get; set; }
        /// <summary>
        /// Loads the list of grids that exists on the settings file.
        /// </summary>
        public List<PredefinedGridOptions> PredefinedGridOptions { get; set; }

        public PredefinedGridOptions CreateRandomGridOption()
        {
            return new PredefinedGridOptions() { 
                Name = GridSettings.Instance.RandomGridName, //Name
                YSize = Core.Random.Instance.Next(GridSettings.Instance.MinYSize, GridSettings.Instance.MaxYSize), //YSize
                XSize = Core.Random.Instance.Next(GridSettings.Instance.MinXSize, GridSettings.Instance.MaxXSize) //XSize
             };
        }
    }
}
