using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public interface ITextMessage
    {
        int ExhibitionOrder { get; set; }
        string Message { get; set; }
    }
}
