using AutoBattle.Skills;

namespace AutoBattle.Characters
{
    public abstract class CharacterClass : ICharacterClass
    {
        protected string Default_ClassName = "Default";
        protected short Default_BaseHealth = 100;
        protected short Default_BaseDamage = 10;
        protected short Default_DamageMultiplier = 1;
        protected short Default_HpModifier = 1;
        protected CharacterSkills[] Default_Skills;

        public string Name { get; set; }
        public short BaseHealth { get; set; }
        public short BaseDamage { get; set; }
        public short DamageMultiplier { get; set; }
        public short HpModifier { get; set; }
        public CharacterSkills[] Skills { get; set; }

        protected CharacterClass()
        {
            Name = Default_ClassName;
            BaseHealth = Default_BaseHealth;
            BaseDamage = Default_BaseDamage;
            DamageMultiplier = Default_DamageMultiplier;
            HpModifier = Default_HpModifier;
            Skills = Default_Skills;
        }

        protected CharacterClass(string _ClassName, short _BaseHealth, short _BaseDamage, short _DamageMultiplier, short _HpModifier, CharacterSkills[] _Skills)
        {
            Name = _ClassName;
            BaseHealth = _BaseHealth;
            BaseDamage = _BaseDamage;
            DamageMultiplier = _DamageMultiplier;
            HpModifier = _HpModifier;
            Skills = _Skills;
        }
    }
}
