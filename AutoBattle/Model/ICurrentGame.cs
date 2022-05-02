using AutoBattle.Core;
using AutoBattle.Characters;
using System;

namespace AutoBattle.Model
{
    public interface ICurrentGame
    {
        /// <summary>
        /// Player name will be also helded here, in case we need somewhere outside character class.
        /// </summary>
        string PlayerName { get; set; }
        Grid Grid { get; set; }
        Int16 CurrentTurn { get; set; }
        Character PlayerCharacter { get; set; }
        Character EnemyCharacter { get; set; }
    }
}
