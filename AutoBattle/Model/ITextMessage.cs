using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public interface ITextMessage
    {
        sbyte ExhibitionOrder { get; set; }
        string Message { get; set; }
    }
}
