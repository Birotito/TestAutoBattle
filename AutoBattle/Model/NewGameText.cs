using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Model
{
    /// <summary>
    /// Responsible for holding information for texts in the newGame Class
    /// </summary>
    public struct NewGameText : INewGameText<TextMessage, PlayerInputMessage>
    {
        /// <summary>
        /// Text that will be shown at the beginning of the game
        /// </summary>
        public List<TextMessage> Introduction { get; set; }
        /// <summary>
        /// Text option so the player enter their name
        /// </summary>
        public List<PlayerInputMessage> GetPlayerNameMessage { get; set; }
        /// <summary>
        /// After the player name we explain a little about the battlefield and ask to select one.
        /// </summary>
        public List<TextMessage> BattlefieldIntroduction { get; set; }
        /// <summary>
        /// Battlefield options, if the player don't select one, we create one random.
        /// </summary>
        public List<PlayerInputMessage> GetPlayerBattlefieldChoice{ get; set; } //TODO: change to be multiple options
        /// <summary>
        /// Explanation about the heroes to choose from.
        /// </summary>
        public List<TextMessage> HeroIntroduction { get; set; }
        /// <summary>
        /// Text for the player choose among the playable heroes.
        /// </summary>
        public List<PlayerInputMessage> GetPlayerHeroChoice { get; set; }

    }
}

