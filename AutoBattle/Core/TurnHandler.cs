using AutoBattle.Characters;
using AutoBattle.Game;
using AutoBattle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoBattle.Core
{
    public class TurnHandler : ITurn
    {
        private TextLoader<GameplayText> M_TextLoader { get; set; }
        private sbyte M_CurrentPlayerTurn { get; set; }
        private List<Character> M_PlayingCharacters { get; set; }
        private short M_CurrentTurn { get; set; }
        private sbyte M_NumberPlayers { get; set; }
        private Grid M_Grid { get; set; }

        public TurnHandler(List<Character> _playingCharacters, Grid _grid)
        {
            M_PlayingCharacters = _playingCharacters;
            M_Grid = _grid;
            M_TextLoader = new TextLoader<GameplayText>();
        }


        public void Start()
        {
            M_CurrentTurn = 0;
            M_NumberPlayers = (sbyte)M_PlayingCharacters.Count;
            DecidesFirstTurn();

            //Shows to the player the grid with the characters placed and who will go first
            PlayerMessageHandler.Instance.DrawBattlefield(M_Grid.M_Grids, M_Grid.M_xLenght, GetPlayerCharcter().GetPlayerCurrentPosition(), GetEnemmyCharcter().GetPlayerCurrentPosition());
            PlayerMessageHandler.Instance.ShowMessageToPlayer(M_TextLoader.Messages.RoundStart, false, ReturnCharacterPlayerName());
        }

        public bool DoTurn()
        {
            short currentPlayerTurnIndex = M_CurrentPlayerTurn;
            GridBox? targetPosition;


            //Check if can attack 
            if (M_PlayingCharacters[currentPlayerTurnIndex].CheckCloseTargets(M_Grid, out targetPosition))
            {
                //Drawn updatededd battlefield and wait for player input
                PlayerMessageHandler.Instance.DrawBattlefield(M_Grid.M_Grids, M_Grid.M_xLenght, GetPlayerCharcter().GetPlayerCurrentPosition(), GetEnemmyCharcter().GetPlayerCurrentPosition());

                //Tell player that character is ready to attack.
                PlayerMessageHandler.Instance.ShowGameplayMessageToPlayer(M_TextLoader.Messages.ReadyToAttack, M_PlayingCharacters[currentPlayerTurnIndex].GetCharacterName());

                short targetToAttackIndex = (short)M_PlayingCharacters.FindIndex(x => x.GetPlayerCurrentPosition() == Array.IndexOf(M_Grid.M_Grids, targetPosition));
                //We are close to attack and we have our target position. Let's find the character in that position, and pass so our character can do some damage to it.
                short DamageDone = M_PlayingCharacters[currentPlayerTurnIndex].Attack();
                M_PlayingCharacters[targetToAttackIndex].TakeDamage(DamageDone);

                //Tell player that character is ready to attack.
                PlayerMessageHandler.Instance.ShowGameplayMessageToPlayer(M_TextLoader.Messages.DamageDone, M_PlayingCharacters[currentPlayerTurnIndex].GetCharacterName(), DamageDone.ToString(), M_PlayingCharacters[targetToAttackIndex].GetCharacterName());

            }
            else
            {
                //If not move close to the enemy, and gets the new position.
                GridBox newPosition = M_PlayingCharacters[currentPlayerTurnIndex].WalkTO(M_Grid);

                //We have the new position but te character didn't moved yet. Lets tell the Grid about the change and then change the new index of the character;
                newPosition = M_Grid.M_Grids.Where(x => x.xIndex == newPosition.xIndex && x.yIndex == newPosition.yIndex).FirstOrDefault();

                short newPositionIndex = (short)Array.IndexOf(M_Grid.M_Grids, newPosition);
                M_Grid.M_Grids[newPositionIndex].OccupyBox();

                short oldPosition = M_PlayingCharacters[currentPlayerTurnIndex].SetCharacterPlaceInGrid(newPositionIndex);
                M_Grid.M_Grids[oldPosition].VacateBox();

                //Drawn updatededd battlefield 
                PlayerMessageHandler.Instance.DrawBattlefield(M_Grid.M_Grids, M_Grid.M_xLenght, GetPlayerCharcter().GetPlayerCurrentPosition(), GetEnemmyCharcter().GetPlayerCurrentPosition());

                //Tell the player that the championt moved.
                PlayerMessageHandler.Instance.ShowGameplayMessageToPlayer(M_TextLoader.Messages.CharacterMoved, M_PlayingCharacters[currentPlayerTurnIndex].GetCharacterName(), M_PlayingCharacters[currentPlayerTurnIndex].GetCharacterName());
            }


            EndTurn();

            //Checks if someone is dead, if so, we returns false ending the gameplay.
            if (M_PlayingCharacters.Where(x => x.GetCharacterIsDead()).FirstOrDefault() != null)
            {
                PlayerMessageHandler.Instance.ShowGameplayMessageToPlayer(M_TextLoader.Messages.CharacterDie, M_PlayingCharacters.Where(x => x.GetCharacterIsDead()).FirstOrDefault().GetCharacterName());
                PlayerMessageHandler.Instance.EndTurn();
                return false;
            }


            //If the game is not finished, return true.
            return true;
        }

        private void EndTurn()
        {
            PlayerMessageHandler.Instance.EndTurn();

            M_CurrentTurn++;
            M_CurrentPlayerTurn++;

            if (M_CurrentPlayerTurn >= M_NumberPlayers)
                M_CurrentPlayerTurn = 0;
        }

        private string ReturnCharacterPlayerName()
        {
            if (M_PlayingCharacters[M_CurrentPlayerTurn].M_isPlayerCharacter)
                return "You";
            else
                return "Enemy";
        }

        public void End()
        {
            //Cleans resources so GC can free memory space.
            M_TextLoader = null;
            M_PlayingCharacters = null;
            M_Grid = null;
            M_CurrentPlayerTurn = 0;
            M_CurrentTurn = 0;
            M_NumberPlayers = 0;
        }


        private void DecidesFirstTurn()
        {
            M_CurrentPlayerTurn = (sbyte)Core.Random.Instance.Next(0, 1);
        }


        #region Return Private Fields Methods
        public short GetCurrentTurn() => M_CurrentTurn;

        public Grid GetGrid() => M_Grid;

        //TODO: Right now we only have 2 characters, and we now that we pass them in this order, but in the future find a way to differentiate each team
        public Character GetPlayerCharcter() => M_PlayingCharacters.SingleOrDefault(x => x.M_isPlayerCharacter);

        public Character GetEnemmyCharcter() => M_PlayingCharacters.SingleOrDefault(x => !x.M_isPlayerCharacter);
        #endregion
    }
}
