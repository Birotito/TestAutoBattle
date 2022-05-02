using System;
using System.Collections.Generic;
using AutoBattle.Characters;
using AutoBattle.Game;
using AutoBattle.Model;

namespace AutoBattle.Core
{
    /// <summary>
    /// This class is responsible for managing the game and all the steps included in it.
    /// </summary>
    public static class GameManager
    {
        public static CurrentGame M_CurrentGame { get; set; }

        #region Private Behavior declaration
        private static IBehavior M_NewGame { get; set; }
        private static IBehavior M_PlaceCharactersInGrid { get; set; }
        private static ITurn M_TurnHandler { get; set; }
        private static IBehavior M_GameOver { get; set; }
        private static IBehavior M_EndGame { get; set; }

        #endregion

        /// <summary>
        /// Entry point for the game. Since we don't have a load/save state, we go directly to new game, but in the future we can check before if we have a game before going to it.
        /// </summary>
        public static void StartGame()
        {
            //Initialize the classes.
            M_NewGame = new NewGame();
            M_CurrentGame = new CurrentGame();

            //Call New Game Start
            M_NewGame.Start();
#if DEBUG
            Console.WriteLine("New Game!:\n");
#endif

            //Get information from new game and feed it to currentgame class
            NewGameSetupIntoCurrentGame((NewGame)M_NewGame);

            //End NewGame class and clean instantiation
            M_NewGame.End();
            M_NewGame = null;

            //Move to gameplay
            Gameplay();
        }

        /// <summary>
        /// Responsible for gameplay
        /// </summary>
        public static void Gameplay()
        {
            //Place the characters in the grid.
            M_PlaceCharactersInGrid = new PlaceCharactersInGrid(M_CurrentGame.Grid, new List<Character>() { M_CurrentGame.PlayerCharacter, M_CurrentGame.EnemyCharacter });
            M_PlaceCharactersInGrid.Start();
            GetCharactersPosition((PlaceCharactersInGrid)M_PlaceCharactersInGrid);
            M_PlaceCharactersInGrid.End();
            M_PlaceCharactersInGrid = null;

            //Play Turns
            M_TurnHandler = new TurnHandler(new List<Character>() { M_CurrentGame.PlayerCharacter, M_CurrentGame.EnemyCharacter }, M_CurrentGame.Grid);
            M_TurnHandler.Start();

            while (M_TurnHandler.DoTurn()) { 

                //Update informations that happened in the turn
                UpdateAfterTurn((TurnHandler)M_TurnHandler);
            }
            M_TurnHandler.End();
            M_TurnHandler = null;

            //Game finished.
            GameOver();

        }

        /// <summary>
        /// When the game end (a character dies) starts this behavior to show results
        /// </summary>
        public static void GameOver()
        {
            //Show the result of the game
            M_GameOver = new GameOver(M_CurrentGame.PlayerCharacter.GetCharacterIsDead() ? M_CurrentGame.PlayerCharacter : M_CurrentGame.EnemyCharacter);
            M_GameOver.Start();
            M_GameOver.End();
            M_GameOver = null;

            //If we got a positive message from game over we would go to try again.Unfortunately there will be no time to implement that
            EndGame();
        }


        /// <summary>
        /// In case the player wants to try again, but differently from new game we don't need all the inputs from the player,we already know their name, and they can keep the same champion for example
        /// </summary>
        public static void TryAgain()
        {
            //If after game over player wants to play again, we can start from here.
        }

        /// <summary>
        /// Case the player wants to exit, we end the game and clean all instantiated objects
        /// </summary>
        public static void EndGame()
        {   //Show the result of the game
            M_EndGame = new EndGame();
            M_EndGame.Start();
            M_EndGame.End();
            M_EndGame = null;

        }

        /// <summary>
        /// Get information from the new created game into out current game property.
        /// </summary>
        /// <param name="_newGameSetup">Behavior that created the new game, can be a try again, load or new game</param>
        private static void NewGameSetupIntoCurrentGame(NewGame _newGameSetup)
        {
            M_CurrentGame.CurrentTurn = 0;
            M_CurrentGame.PlayerName = _newGameSetup.GetPlayerName();
            M_CurrentGame.PlayerCharacter = _newGameSetup.GetPlayerCharacter();
            M_CurrentGame.EnemyCharacter = _newGameSetup.GetEnemyCharacter();
            M_CurrentGame.Grid = _newGameSetup.GetGrid();
            
        }

        private static void GetCharactersPosition(PlaceCharactersInGrid _placeToGrid)
        {
            M_CurrentGame.Grid = _placeToGrid.GetGrid();
            M_CurrentGame.PlayerCharacter = _placeToGrid.GetPlayerCharcter();
            M_CurrentGame.EnemyCharacter = _placeToGrid.GetEnemmyCharcter();
        }

        private static void UpdateAfterTurn(TurnHandler _turnHandler)
        {
            M_CurrentGame.Grid = _turnHandler.GetGrid();
            M_CurrentGame.PlayerCharacter = _turnHandler.GetPlayerCharcter();
            M_CurrentGame.EnemyCharacter = _turnHandler.GetEnemmyCharcter();
            M_CurrentGame.CurrentTurn = _turnHandler.GetCurrentTurn();
        }
       
    }
}
