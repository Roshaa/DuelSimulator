using DuelSimulator.Abilities;

namespace DuelSimulator.Classes
{
    public class DeathKnight : AbstractClass
    {
        public DeathKnight(string name)
        {
            PlayerName = name;
            Health = 8000;
            MaxHP = Health;
            Mana = 500;
            MaxMana = Mana;
            Armor = 100;
            HealthRegen = 50;
            ManaRegen = 60;
            AttackValue = 100;
            AbilityPower = 120;
            EquippableItems = 4;
            OffensiveAbilities = new List<Ability>();
            DefensiveAbilities = new List<Ability>();
            StandByAbilities = new List<Ability>();
        }

        public override int Attack()
        {
            int attack = GetRandomizedAttackValue();
            attack += CastSpell(OffensiveAbilities);
            return attack;
        }

    }
}
