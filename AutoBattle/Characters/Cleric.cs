using AutoBattle.Skills;

namespace AutoBattle.Characters
{
    public class Cleric : CharacterClass
    {
        private string M_ClassName = "Cleric";
        private short M_BaseHealth = 100;
        private short M_BaseDamage = 10;
        private short M_DamageMultiplier = 1;
        private short M_HpModifier = 1;
        private CharacterSkills[] M_Skills = new CharacterSkills[0];

        public Cleric() : base()
        {
            Name = M_ClassName;
            BaseHealth = M_BaseHealth;
            BaseDamage = M_BaseDamage;
            DamageMultiplier = M_DamageMultiplier;
            HpModifier = M_HpModifier;
            Skills = M_Skills;
        }

    }
}
