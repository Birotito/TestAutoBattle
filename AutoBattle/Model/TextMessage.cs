using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public class TextMessage : ITextMessage
    {
        public int ExhibitionOrder { get; set; }
        public string Message { get; set; }
        
    }
}
