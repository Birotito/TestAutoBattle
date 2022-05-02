using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    /// <summary>
    /// Responsible for holding information for texts in the newGame Class
    /// </summary>
    public class GameplayText : IGameplayText<TextMessage>
    {
        public List<TextMessage> RoundStart { get; set; }
        public List<TextMessage> CharacterMoved { get; set; }
        public List<TextMessage> ReadyToAttack { get; set; }
        public List<TextMessage> DamageDone { get; set; } 
        public List<TextMessage> CharacterDie { get; set; }

    }
}

