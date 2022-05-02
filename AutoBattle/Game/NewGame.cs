using AutoBattle.Core;
using AutoBattle.Model;
using AutoBattle.Characters;
using System;
using System.Collections.Generic;

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
            //TODO: We also could add a flag for each in the settings file so we could jumo any of those steps, and get a default player name, random battlefield, and random character.

            #region Introduction and player name

            GetPlayerName getPlayerNameSelection = new GetPlayerName(M_TextLoader.Messages.Introduction, M_TextLoader.Messages.GetPlayerNameMessage);
            getPlayerNameSelection.Start();
            M_PlayerName = getPlayerNameSelection.M_PlayerName;
            getPlayerNameSelection.End();
            getPlayerNameSelection = null;

            #endregion

            #region Battlefield selection

            SelectBattlefield bfSelection = new SelectBattlefield(M_TextLoader.Messages.BattlefieldIntroduction, M_TextLoader.Messages.GetPlayerBattlefieldChoice, M_PlayerName);
            bfSelection.Start();
            M_Grid = bfSelection.M_Grid;
            bfSelection.End();
            bfSelection = null;

            #endregion

            #region Character selection

            SelectCharacters charSelection = new SelectCharacters(M_TextLoader.Messages.HeroIntroduction, M_TextLoader.Messages.GetPlayerHeroChoice);
            charSelection.Start();
            M_PlayerCharacter = new Character(charSelection.M_PlayerCharacter);
            M_EnemyCharacter = new Character(charSelection.M_EnemyCharacter);
            charSelection.End();
            charSelection = null;
            #endregion

            //Show final message before going to the next behavior
            PlayerMessageHandler.Instance.ShowMessageToPlayer(M_TextLoader.Messages.FinalText, true, M_PlayerCharacter.GetCharacterName());
        }

        public void End()
        {
            //Cleans resources so GC can free memory space.
            M_PlayerName = string.Empty;
            M_PlayerCharacter = null;
            M_EnemyCharacter = null;
            M_Grid = null;
        }
        

        #region Return Private Fields Methods
        public string GetPlayerName() => M_PlayerName;

        public Character GetPlayerCharacter() => M_PlayerCharacter;

        public Character GetEnemyCharacter() => M_EnemyCharacter;

        public Grid GetGrid() => M_Grid;
        #endregion

    }
}
