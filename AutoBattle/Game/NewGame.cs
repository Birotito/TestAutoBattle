using AutoBattle.Core;
using AutoBattle.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Game
{
    /// <summary>
    /// Behavior to handle new games.
    /// </summary>
    public class NewGame : IBehavior
    {
        private TextLoader<NewGameText> M_TextLoader { get; set; }

        //Temporary Fields that will be returned.
        #region Private Fields
        private string M_PlayerName;
        private Character M_PlayerCharacter;
        private Character M_EnemyCharacter;
        private Grid M_Grid;
        #endregion

        /// <summary>
        /// Load the text file when initializing the class.
        /// </summary>
        public NewGame()
        {
            M_TextLoader = new TextLoader<NewGameText>();
        }

        /// <summary>
        /// Start a new game, we will set the battlefield size, get the player name and let it choose a class.
        /// </summary>
        public void Start()
        {
            //First we show to the player the introduction text.
            PlayerMessageHandler.Instance.ShowMessageToPlayer(M_TextLoader.Messages.Introduction);

            //After that we need to get the player name
            M_PlayerName = PlayerMessageHandler.Instance.GetInputFromPlayer(M_TextLoader.Messages.GetPlayerNameMessage);

            //Get Battlefield Information, if no predifined BF is set, create a random one and jump this step
            if (GridSettings.Instance.PredefinedGridOptions != null)
            {
                PlayerMessageHandler.Instance.ShowMessageToPlayer(M_TextLoader.Messages.BattlefieldIntroduction, M_PlayerName);
            }


            
        }

        public void End()
        {   
            throw new NotImplementedException();
        }

        #region Return Private Fields Methods
        public string GetPlayerName() => M_PlayerName;

        public Character GetPlayerCharacter() => M_PlayerCharacter;

        public Character GetEnemyCharacter() => M_EnemyCharacter;

        public Grid GetGrid() => M_Grid;
        #endregion

    }
}
