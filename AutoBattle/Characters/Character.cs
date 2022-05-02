using AutoBattle.Core;
using AutoBattle.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoBattle.Characters
{
    public class Character : ICharacter
    {
        private string M_Name { get; set; }
        private Int16 M_CurrentHealth { get; set; }
        private Int16 M_CurrentDamage { get; set; }
        private Int16 M_CurrentDamageMultiplier { get; set; }
        private Int16 M_PlayerIndex { get; set; }
        private ICharacterClass M_CurrentClass { get; set; }
        public bool M_isPlayerCharacter { get; set; }
        private bool M_IsDead { get; set; }

        /// <summary>
        /// Gets information from the selected class and use in the main character class. 
        /// Everything that we need that is specific to the class (skills for example) if we need we get for the class.
        /// </summary>
        /// <param name="_characterClass">The selected class</param>
        public Character(CharacterClass _characterClass, bool _isPlayer)
        {
            this.M_Name = _characterClass.Name;
            this.M_CurrentHealth = _characterClass.BaseHealth;
            this.M_CurrentDamage = _characterClass.BaseDamage;
            this.M_CurrentDamageMultiplier = _characterClass.DamageMultiplier;
            this.M_isPlayerCharacter = _isPlayer;
            this.M_CurrentClass = _characterClass;
            this.M_IsDead = false;
        }


        // Check in x and y directions if there is any character close enough to be a target.
        public bool CheckCloseTargets(Grid _battlefield, out GridBox? _targetPosition)
        {
            //Get our current Position
            GridBox CurrentPosition = _battlefield.M_Grids[M_PlayerIndex];
            bool isTargetInRange = false;

            //See if any of the 8 directions around us is occupied. 
            //If we go from our position -1 to our position + 1 in both directions we will cover all directions.We just need to be careful to not go outbounds.
            short minimumYChecker = (short)Math.Max(0, (CurrentPosition.yIndex - 1)); //if value is bellow 0 would means that is outside
            short minimumXChecker = (short)Math.Max(0, (CurrentPosition.xIndex - 1)); //if value is bellow 0 would means that is outside

            short maximumYChecker = (short)Math.Min(_battlefield.M_yLength - 1, (CurrentPosition.yIndex + 1)); //if value is hIgher then maximum grid size would means that is outside
            short maximumXChecker = (short)Math.Min(_battlefield.M_yLength - 1, (CurrentPosition.xIndex + 1));  //if value is hIgher then maximum grid size would means that is outside


            //We can use a Linq to go search for a list instead of doing a loop.
            List<GridBox> aroundPlaces = _battlefield.M_Grids.Where(x => x.xIndex >= minimumXChecker
                                                && x.xIndex <= maximumXChecker
                                                && x.yIndex >= minimumYChecker
                                                && x.yIndex <= maximumYChecker
                                                && x.occupied).ToList();

            //Remove us from the list
            aroundPlaces.Remove(CurrentPosition);

            //if we have something on the list, that's our target.
            isTargetInRange = aroundPlaces.Count() > 0;

            //If true, Since we finded the target, lets return to not need to search again.
            if (isTargetInRange)
                _targetPosition = aroundPlaces.FirstOrDefault();
            else
                _targetPosition = null;

            return isTargetInRange;
        }

        public GridBox WalkTO(Grid _battlefield)
        {
            //Get our current Position
            GridBox CurrentPosition = _battlefield.M_Grids[M_PlayerIndex];
            GridBox targetPosition;

            //We need to find our target and direcation to it. So first let's find all occupied and remove our own;
            List<GridBox> occupiedPlaces = _battlefield.M_Grids.Where(x => x.occupied).ToList();

            //Remove us from the list
            occupiedPlaces.Remove(CurrentPosition);

            //Let's get the first enemy that we fould, but we know that we have multiple enemies we can search for the closest one, or even remove the ones on our team.
            targetPosition = occupiedPlaces.FirstOrDefault();
            GridBox newPosition = CurrentPosition;
            
            //We have the position of our enemy, now we should move. We can move in 8 directions, so if our Y and X is different we can move in both those.
            if (CurrentPosition.xIndex < targetPosition.xIndex)
            {
                //Our target is on our right side, so lets move to it.
                newPosition.xIndex++;
            }
            else if (CurrentPosition.xIndex > targetPosition.xIndex)
            {
                //Our target is on our left side, so lets move to it.
                newPosition.xIndex--;
            }

            if (CurrentPosition.yIndex > targetPosition.yIndex)
            {
                //Our target is above us, so lets move to it.
                newPosition.yIndex--;
            }
            else if (CurrentPosition.yIndex < targetPosition.yIndex)
            {
                //Our target is below us, so lets move to it.
                newPosition.yIndex++;
            }

            //We have our new position, let's return it so the behavior can change the Grid and then update the character.
            return newPosition;
        }

        /// <summary>
        /// Character takes damage, check if is dead too.
        /// </summary>
        /// <param name="amount">Amount of damage that will be dealth to the character;</param>
        public void TakeDamage(Int16 amount)
        {
            //It's ok if health goes bellow 0;
            M_CurrentHealth -= amount;

            if (M_CurrentHealth <= 0)
                Die();
        }

        public void Die()
        {
            this.M_IsDead = true;
        }

        public short Attack()
        {
            short Damage = (short)(M_CurrentDamage * M_CurrentDamageMultiplier);
            Damage = Core.Random.Instance.CalculateDamage(Damage);

            return Damage;
        }

        #region Return Private Fields Methods
        public string GetCharacterName() => M_Name;

        public short GetPlayerCurrentPosition() => M_PlayerIndex;

        public bool GetCharacterIsDead() => M_IsDead;

        public Int16 SetCharacterPlaceInGrid(Int16 _newPlace)
        {
            Int16 OldPlace = M_PlayerIndex;
            M_PlayerIndex = _newPlace;

            return OldPlace;
        }

        #endregion
    }
}
