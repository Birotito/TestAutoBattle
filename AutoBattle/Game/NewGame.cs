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
            //TODO: each one of those steps should be in a single class for single responsability and reasuability
            //TODO: We also could add a flag for each in the settings file so we could jumo any of those steps, and get a default player name, random battlefield, and random character.

            #region Introduction and player name
            //First we show to the player the introduction text.
            PlayerMessageHandler.Instance.ShowMessageToPlayer(M_TextLoader.Messages.Introduction);

            //After that we need to get the player name
            M_PlayerName = PlayerMessageHandler.Instance.GetInputFromPlayer(M_TextLoader.Messages.GetPlayerNameMessage);
            #endregion

            #region Battlefield selection
            //Get Battlefield Information, if no predifined BF is set, create a random one and jump this step
            if (GridSettings.Instance.PredefinedGridOptions != null)
            {
                PlayerMessageHandler.Instance.ShowMessageToPlayer(M_TextLoader.Messages.BattlefieldIntroduction, true, M_PlayerName);

                //We could pass the list without the method to not add the random value, this could be easily changed.
                M_Grid = new Grid(PlayerMessageHandler.Instance.GetMutipleChoiceInputFromPlayer<PredefinedGridOptions>(M_TextLoader.Messages.GetPlayerBattlefieldChoice, CreateGridOptionWithRandom(GridSettings.Instance.PredefinedGridOptions)));

                //Draw selected grid.
                PlayerMessageHandler.Instance.DrawBattlefield(M_Grid.M_Grids, M_Grid.M_xLenght);
            }
            else
            {
                //Random grid
                M_Grid = new Grid(GridSettings.Instance.CreateRandomGridOption());
            }
            #endregion

            #region Character selection
            //Show messages about chmapion selection to player
            PlayerMessageHandler.Instance.ShowMessageToPlayer(M_TextLoader.Messages.HeroIntroduction, false);

            //Player select a player among one of the option
            PlayerMessageHandler.Instance.ShowMessageToPlayer(M_TextLoader.Messages.HeroIntroduction, false);
            #endregion
        }

        private List<PredefinedGridOptions> CreateGridOptionWithRandom(List<PredefinedGridOptions> _preExistingList)
        {
            List<PredefinedGridOptions> returnList = new List<PredefinedGridOptions>();
            returnList.AddRange(_preExistingList);

            //Add random in last for the player to choose from.
            returnList.Add(GridSettings.Instance.CreateRandomGridOption());

            return returnList;
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
