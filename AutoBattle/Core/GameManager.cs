﻿using System;
using System.Collections.Generic;
using System.Text;

using static AutoBattle.Character;
using static AutoBattle.Grid;
using System.Linq;
using static AutoBattle.Types;
using Random = AutoBattle.Core.Random;
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

        }
        //CharacterClass playerCharacterClass;
        //GridBox PlayerCurrentLocation;
        //GridBox EnemyCurrentLocation;
        //Character PlayerCharacter;
        //Character EnemyCharacter;
        //List<Character> AllPlayers = new List<Character>();

        //void GetPlayerChoice()
        //{
        //    //asks for the player to choose between for possible classes via console.
        //    Console.WriteLine("Choose Between One of this Classes:\n");
        //    Console.WriteLine("[1] Paladin, [2] Warrior, [3] Cleric, [4] Archer");
        //    //store the player choice in a variable
        //    string choice = Console.ReadLine();

        //    switch (choice)
        //    {
        //        case "1":
        //            CreatePlayerCharacter(Int32.Parse(choice));
        //            break;
        //        case "2":
        //            CreatePlayerCharacter(Int32.Parse(choice));
        //            break;
        //        case "3":
        //            CreatePlayerCharacter(Int32.Parse(choice));
        //            break;
        //        case "4":
        //            CreatePlayerCharacter(Int32.Parse(choice));
        //            break;
        //        default:
        //            GetPlayerChoice();
        //            break;
        //    }
        //}

        //void CreatePlayerCharacter(int classIndex)
        //{

        //    CharacterClass characterClass = (CharacterClass)classIndex;
        //    Console.WriteLine($"Player Class Choice: {characterClass}");
        //    PlayerCharacter = new Character(characterClass);
        //    PlayerCharacter.Health = 100;
        //    PlayerCharacter.BaseDamage = 20;
        //    PlayerCharacter.PlayerIndex = 0;

        //    CreateEnemyCharacter();

        //}

        //void CreateEnemyCharacter()
        //{
        //    //randomly choose the enemy class and set up vital variables
        //    int randomInteger = Random.Instance.Next(1, 4);
        //    CharacterClass enemyClass = (CharacterClass)randomInteger;
        //    Console.WriteLine($"Enemy Class Choice: {enemyClass}");
        //    EnemyCharacter = new Character(enemyClass);
        //    EnemyCharacter.Health = 100;
        //    PlayerCharacter.BaseDamage = 20;
        //    PlayerCharacter.PlayerIndex = 1;
        //    StartGame();

        //}

        //void StartGame()
        //{
        //    //populates the character variables and targets
        //    EnemyCharacter.Target = PlayerCharacter;
        //    PlayerCharacter.Target = EnemyCharacter;
        //    AllPlayers.Add(PlayerCharacter);
        //    AllPlayers.Add(EnemyCharacter);
        //    AlocatePlayers();
        //    StartTurn();

        //}

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
