using DuelSimulator.Enum;
using DuelSimulator.Interfaces;

namespace DuelSimulator.Abilities
{
    public class Ability : IAbility
    {
        public string Name { get; }
        public int Power { get; }
        public int ManaCost { get; }
        public int Cooldown { get; }
        public int CurrentCooldown { get; set; }
        public AbilityTypeEnum Type { get; }

        public Ability(string name, int power, int manaCost, int cooldown, AbilityTypeEnum type)
        {
            Name = name;
            Power = power;
            ManaCost = manaCost;
            Cooldown = cooldown;
            Type = type;
            CurrentCooldown = 0;
        }

        public int CastAbility(int abilityPower)
        {
            CurrentCooldown = Cooldown;
            return abilityPower + Power;
        }
    }
}