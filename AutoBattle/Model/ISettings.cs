using Microsoft.Extensions.Configuration;
using System;

namespace AutoBattle.Model
{
    public interface ISettings
    {
        /// <summary>
        /// Method to get information from the read JSON Iconfiguration into properties.
        /// </summary>
        /// <param name="configuration"></param>
        public void Configure(IConfiguration configuration);
    }
}
