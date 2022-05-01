using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    public interface INewGameText<ITextMessage, IPlayerInputMessage>
    {
        /// <summary>
        /// Implementation from ITextMessage Interface
        /// </summary>
        List<ITextMessage> Introduction { get; set; }
        List<IPlayerInputMessage> GetPlayerNameMessage { get; set; }
        List<ITextMessage> BattlefieldIntroduction { get; set; }
        List<IPlayerInputMessage> GetPlayerBattlefieldChoice { get; set; } 
        List<ITextMessage> HeroIntroduction { get; set; }
        List<IPlayerInputMessage> GetPlayerHeroChoice { get; set; }
    }
}
