using AutoBattle.Model;
using Newtonsoft.Json.Linq;
using System.IO;
using System;

namespace AutoBattle.Core
{
    /// <summary>
    /// Responsible to load the texts from the json file into the respective class
    /// </summary>
    public class TextLoader<T>
    {
        /// <summary>
        /// Property that will hold the loaaded information, this way the class that calls the loader only needs a reference to the loader.
        /// </summary>
        public T Messages { get; set; }

        /// <summary>
        /// Constructor already try to load the file.
        /// </summary>
        public TextLoader() => LoadMessagesFromFile();

        /// <summary>
        /// Try to load the information from the JSON file into the property object
        /// </summary>
        private void LoadMessagesFromFile()
        {
            //read all the content inside the file
            string jsonData = File.ReadAllText(MessageTextFileSettings.Instance.Path);

            //if no data is present then return exception, player needs to check if the file was not moved.
            if (string.IsNullOrWhiteSpace(jsonData)) throw new Exception("Text file not found, please check if the file is in the correct place.");

            //Gets the part from the JSON file that is corresponding to the parent class that called the loader.
            Messages = (T)JObject.Parse(jsonData).GetValue(typeof(T).Name.ToString()).ToObject(typeof(T));
        }
    }
}
