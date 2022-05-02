using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public interface IGameplayText<ITextMessage>
    {
        /// <summary>
        /// Implementation from ITextMessage Interface
        /// </summary>
        List<ITextMessage> RoundStart { get; set; }
        List<ITextMessage> CharacterMoved { get; set; }
        List<ITextMessage> ReadyToAttack { get; set; }
        List<ITextMessage> DamageDone { get; set; } 
        List<ITextMessage> CharacterDie { get; set; }
        
    }
}
