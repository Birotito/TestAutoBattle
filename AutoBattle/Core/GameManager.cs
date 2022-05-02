using System;
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
        /// <summary>
        /// Private Game Start Behavior Class
        /// </summary>
        private static IBehavior M_NewGame { get; set; }

       
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
        }

        /// <summary>
        /// Responsible for gameplay
        /// </summary>
        public static void Gameplay()
        {

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


        //void StartTurn()
        //{

        //    if (currentTurn == 0)
        //    {
        //        //AllPlayers.Sort();  
        //    }

        //    foreach (Character character in AllPlayers)
        //    {
        //        character.StartTurn(grid);
        //    }

        //    currentTurn++;
        //    HandleTurn();
        //}

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

        //void AlocatePlayers()
        //{
        //    AlocatePlayerCharacter();

        //}

        //void AlocatePlayerCharacter()
        //{
        //    int random = 0;
        //    GridBox RandomLocation = (grid.grids.ElementAt(random));
        //    Console.Write($"{random}\n");
        //    if (!RandomLocation.ocupied)
        //    {
        //        GridBox PlayerCurrentLocation = RandomLocation;
        //        RandomLocation.ocupied = true;
        //        grid.grids[random] = RandomLocation;
        //        PlayerCharacter.currentBox = grid.grids[random];
        //        AlocateEnemyCharacter();
        //    }
        //    else
        //    {
        //        AlocatePlayerCharacter();
        //    }
        //}

        //void AlocateEnemyCharacter()
        //{
        //    int random = 24;
        //    GridBox RandomLocation = (grid.grids.ElementAt(random));
        //    Console.Write($"{random}\n");
        //    if (!RandomLocation.ocupied)
        //    {
        //        EnemyCurrentLocation = RandomLocation;
        //        RandomLocation.ocupied = true;
        //        grid.grids[random] = RandomLocation;
        //        EnemyCharacter.currentBox = grid.grids[random];
        //        grid.drawBattlefield(5, 5);
        //    }
        //    else
        //    {
        //        AlocateEnemyCharacter();
        //    }
        //}
    }
}
