using AutoBattle.Core;
using AutoBattle.Characters;
using System;

namespace AutoBattle.Model
{
    public class CurrentGame : ICurrentGame
    {
        public string PlayerName { get; set; }
        public Grid Grid { get; set; }
        public Int16 CurrentTurn { get; set; }
        public Character PlayerCharacter { get; set; }
        public Character EnemyCharacter { get; set; }
    }
}
