using System;
using Microsoft.Extensions.Configuration;
using AutoBattle.Model;
using AutoBattle.Core;

namespace AutoBattle
{
    public class Program
    {
        /// <summary>
        /// Path where the setting file is located.
        /// </summary>
        public const string settingsPath = "Data\\Settings.json";

        /// <summary>
        /// Star point of the system. Calls setup for setting loading, and then go for gamestart
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                //Read setting file.
                Setup();

                //after the setting will load we start the game, game manager will be responsible to set the current status of the game and call each responsible part.
                GameManager.StartGame();
            }
            catch (Exception ex)
            {
                //TODO: would be nice to automatically save a log file if we get an exception.
                throw ex;
            }
        }

        /// <summary>
        /// Method responsible for reading information from the setting json file.
        /// </summary>
        private static void Setup()
        {
            GridSettings.Instance.Configure(new ConfigurationBuilder().AddJsonFile(settingsPath).Build().GetSection("GridSetting"));
            MessageTextFileSettings.Instance.Configure(new ConfigurationBuilder().AddJsonFile(settingsPath).Build().GetSection("MessageTextFileSettings"));
        }
    }
}
