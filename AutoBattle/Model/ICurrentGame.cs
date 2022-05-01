using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public interface ICurrentGame
    {
        /// <summary>
        /// Player name will be also helded here, in case we need somewhere outside character class.
        /// </summary>
        string PlayerName { get; set; }
        Grid Grid { get; set; }
        int CurrentTurn { get; set; }
        Character PlayerCharacter { get; set; }
        Character EnemyCharacter { get; set; }
    }
}
