using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public class CurrentGame : ICurrentGame
    {
        public string PlayerName { get; set; }
        public Grid Grid { get; set; }
        public int CurrentTurn { get; set; }
        public Character PlayerCharacter { get; set; }
        public Character EnemyCharacter { get; set; }
    }
}
