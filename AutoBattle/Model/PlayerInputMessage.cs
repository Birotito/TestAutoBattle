using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public class PlayerInputMessage : TextMessage, IPlayerInputMessage
    {
        public string InvalidInput { get; set; }   
    }
}
