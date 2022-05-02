using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public interface IGameOverText<ITextMessage, IPlayerInputMessage>
    {
        /// <summary>
        /// Implementation from ITextMessage Interface
        /// </summary>
        List<ITextMessage> PlayerWin { get; set; }
        List<ITextMessage> EnemyWin { get; set; }
        List<IPlayerInputMessage> PlayAgain { get; set; }
        List<ITextMessage> EndGreetings { get; set; } 
        
    }
}
