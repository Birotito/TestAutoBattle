using System;
using AutoBattle.Skills;

namespace AutoBattle.Characters
{
    public interface ICharacterClass
    {
        string Name { get; set; }
        Int16 BaseHealth { get; set; }
        Int16 BaseDamage { get; set; }
        Int16 DamageMultiplier { get; set; }
        Int16 HpModifier { get; set; }
        CharacterSkills[] Skills { get; set; }

    }
}
