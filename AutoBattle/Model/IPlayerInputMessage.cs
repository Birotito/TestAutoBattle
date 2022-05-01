using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public interface IPlayerInputMessage : ITextMessage
    {
        string InvalidInput { get; set; }
    }
}
