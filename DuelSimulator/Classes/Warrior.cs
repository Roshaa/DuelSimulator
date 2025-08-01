using DuelSimulator.Abilities;

namespace DuelSimulator.Classes
{
    public class Warrior : AbstractClass
    {
        public Warrior(string name)
        {
            PlayerName = name;
            Health = 6000;
            MaxHP = Health;
            Mana = 0;
            MaxMana = Mana;
            Armor = 75;
            HealthRegen = 80;
            ManaRegen = 0;
            AttackValue = 200;
            AbilityPower = 0;
            AbilityChoices = 0;
            EquippableItems = 5;
            OffensiveAbilities = new List<Ability>();
            DefensiveAbilities = new List<Ability>();
            StandByAbilities = new List<Ability>();
            DamageModifiers = new Dictionary<Type, double>
            {
                { typeof(Assassin), 0.5 },
                { typeof(DeathKnight), 2.0 }
            };
        }

        public override int Attack()
        {
            int attack = GetRandomizedAttackValue();
            attack += CastSpell(OffensiveAbilities);
            return attack;
        }

    }
}
