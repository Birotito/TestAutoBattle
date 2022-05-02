using System;

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
        private Character Target { get; set; } 


        /// <summary>
        /// Gets information from the selected class and use in the main character class. 
        /// Everything that we need that is specific to the class (skills for example) if we need we get for the class.
        /// </summary>
        /// <param name="_characterClass">The selected class</param>
        public Character(CharacterClass _characterClass)
        {
            this.M_Name = _characterClass.Name;
            this.M_CurrentHealth = _characterClass.BaseHealth;
            this.M_CurrentDamage = _characterClass.BaseDamage;
            this.M_CurrentDamageMultiplier = _characterClass.DamageMultiplier;
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
            //TODO >> maybe kill him?
        }

        public void WalkTO(bool CanWalk)
        {

        }

        //public void StartTurn(Grid battlefield)
        //{

        //    if (CheckCloseTargets(battlefield)) 
        //    {
        //        Attack(Target);
                

        //        return;
        //    }
        //    else
        //    {   // if there is no target close enough, calculates in wich direction this character should move to be closer to a possible target
        //        if(this.currentBox.xIndex > Target.currentBox.xIndex)
        //        {
        //            if ((battlefield.grids.Exists(x => x.Index == currentBox.Index - 1)))
        //            {
        //                currentBox.ocupied = false;
        //                battlefield.grids[currentBox.Index] = currentBox;
        //                currentBox = (battlefield.grids.Find(x => x.Index == currentBox.Index - 1));
        //                currentBox.ocupied = true;
        //                battlefield.grids[currentBox.Index] = currentBox;
        //                Console.WriteLine($"Player {PlayerIndex} walked left\n");
        //                battlefield.drawBattlefield(5, 5);

        //                return;
        //            }
        //        } else if(currentBox.xIndex < Target.currentBox.xIndex)
        //        {
        //            currentBox.ocupied = false;
        //            battlefield.grids[currentBox.Index] = currentBox;
        //            currentBox = (battlefield.grids.Find(x => x.Index == currentBox.Index + 1));
        //            currentBox.ocupied = true;
        //            return;
        //            battlefield.grids[currentBox.Index] = currentBox;
        //            Console.WriteLine($"Player {PlayerIndex} walked right\n");
        //            battlefield.drawBattlefield(5, 5);
        //        }

        //        if (this.currentBox.yIndex > Target.currentBox.yIndex)
        //        {
        //            battlefield.drawBattlefield(5, 5);
        //            this.currentBox.ocupied = false;
        //            battlefield.grids[currentBox.Index] = currentBox;
        //            this.currentBox = (battlefield.grids.Find(x => x.Index == currentBox.Index - battlefield.xLenght));
        //            this.currentBox.ocupied = true;
        //            battlefield.grids[currentBox.Index] = currentBox;
        //            Console.WriteLine($"Player {PlayerIndex} walked up\n");
        //            return;
        //        }
        //        else if(this.currentBox.yIndex < Target.currentBox.yIndex)
        //        {
        //            this.currentBox.ocupied = true;
        //            battlefield.grids[currentBox.Index] = this.currentBox;
        //            this.currentBox = (battlefield.grids.Find(x => x.Index == currentBox.Index + battlefield.xLenght));
        //            this.currentBox.ocupied = false;
        //            battlefield.grids[currentBox.Index] = currentBox;
        //            Console.WriteLine($"Player {PlayerIndex} walked down\n");
        //            battlefield.drawBattlefield(5, 5);

        //            return;
        //        }
        //    }
        //}

        //// Check in x and y directions if there is any character close enough to be a target.
        //bool CheckCloseTargets(Grid battlefield)
        //{
        //    bool left = (battlefield.grids.Find(x => x.Index == currentBox.Index - 1).ocupied);
        //    bool right = (battlefield.grids.Find(x => x.Index == currentBox.Index + 1).ocupied);
        //    bool up = (battlefield.grids.Find(x => x.Index == currentBox.Index + battlefield.xLenght).ocupied);
        //    bool down = (battlefield.grids.Find(x => x.Index == currentBox.Index - battlefield.xLenght).ocupied);

        //    if (left & right & up & down) 
        //    {
        //        return true;
        //    }
        //    return false; 
        //}

        public void Attack (Character target)
        {
            //var rand = new Random();
            //target.TakeDamage(rand.Next(0, (int)BaseDamage));
            //Console.WriteLine($"Player {PlayerIndex} is attacking the player {Target.PlayerIndex} and did {BaseDamage} damage\n");
        }

        #region Return Private Fields Methods
        public string GetCharacterName() => M_Name;

        #endregion
    }
}
