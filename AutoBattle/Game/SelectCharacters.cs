using AutoBattle.Characters;
using AutoBattle.Core;
using AutoBattle.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBattle.Game
{
    public class SelectCharacters : IBehavior
    {
        public List<TextMessage> M_HeroIntroductionMessages { get; set; }
        public List<PlayerInputMessage> M_HeroSelectionChoiceMessages { get; set; }
        public CharacterClass M_PlayerCharacter { get; set; }
        public CharacterClass M_EnemyCharacter { get; set; }

        private List<CharacterClass> M_AvailableClasses;

        public SelectCharacters(List<TextMessage> _heroIntroductionMessages, List<PlayerInputMessage> _heroSelectionChoiceMessages)
        {
            M_HeroIntroductionMessages = _heroIntroductionMessages;
            M_HeroSelectionChoiceMessages = _heroSelectionChoiceMessages;
        }

        public void Start()
        {
            InitiateAllAvailableClasses();

            #region Character selection
            //Show messages about chmapion selection to player
            PlayerMessageHandler.Instance.ShowMessageToPlayer(M_HeroIntroductionMessages, false);

            //Player select a character among one of the option
            M_PlayerCharacter = PlayerMessageHandler.Instance.GetMutipleChoiceInputFromPlayer<CharacterClass>(M_HeroSelectionChoiceMessages, M_AvailableClasses);

            //Remove the class that the player choose and selects one for the PC
            M_AvailableClasses.Remove(M_PlayerCharacter);
            M_EnemyCharacter = M_AvailableClasses[Core.Random.Instance.Next(M_AvailableClasses.Count - 1)];

            //TODO set the player character
            //Set a random enemy character
            #endregion
        }

        /// <summary>
        /// All classes that the player com select are listed from here
        /// </summary>
        private void InitiateAllAvailableClasses()
        {
            M_AvailableClasses = new List<CharacterClass>();

            //Paladin 
            M_AvailableClasses.Add(new Paladin());

            //Archer
            M_AvailableClasses.Add(new Archer());

            //Warrior 
            M_AvailableClasses.Add(new Warrior());

            //Cleric 
            M_AvailableClasses.Add(new Cleric());
        }

        public void End()
        {
            //Cleans resources so GC can free memory space.
            M_HeroIntroductionMessages = null;
            M_HeroSelectionChoiceMessages = null;
            M_PlayerCharacter = null;
            M_EnemyCharacter = null;
            M_AvailableClasses = null;
        }
    }
}
