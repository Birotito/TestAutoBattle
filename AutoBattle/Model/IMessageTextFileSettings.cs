using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public interface IMessageTextFileSettings : ISettings
    {
        //This could be latter changed into a enum, but since we are not using localization now, is not needed to add this complexity.
        public string Language { get; set; }
        public string Path { get; set; }
    }
}
