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

            while (!M_TurnHandler.DoTurn())
            {
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

        }


        /// <summary>
        /// In case the player wants to try again, but differently from new game we don't need all the inputs from the player,we already know their name, and they can keep the same champion for example
        /// </summary>
        public static void TryAgain()
        {

        }

        /// <summary>
        /// Case the player wants to exit, we end the game and clean all instantiated objects
        /// </summary>
        public static void EndGame()
        {

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

        //void HandleTurn()
        //{
        //    if (PlayerCharacter.Health == 0)
        //    {
        //        return;
        //    }
        //    else if (EnemyCharacter.Health == 0)
        //    {
        //        Console.Write(Environment.NewLine + Environment.NewLine);

        //        // endgame?

        //        Console.Write(Environment.NewLine + Environment.NewLine);

        //        return;
        //    }
        //    else
        //    {
        //        Console.Write(Environment.NewLine + Environment.NewLine);
        //        Console.WriteLine("Click on any key to start the next turn...\n");
        //        Console.Write(Environment.NewLine + Environment.NewLine);

        //        ConsoleKeyInfo key = Console.ReadKey();
        //        StartTurn();
        //    }
        //}
       
    }
}
