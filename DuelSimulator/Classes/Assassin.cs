using DuelSimulator.Abilities;

namespace DuelSimulator.Classes
{
    public class Assassin : AbstractClass
    {
        public int DodgeChance;

        public Assassin(string name)
        {
            PlayerName = name;
            Health = 5000;
            MaxHP = Health;
            Mana = 400;
            MaxMana = Mana;
            Armor = 20;
            HealthRegen = 25;
            ManaRegen = 10;
            AttackValue = 200;
            AbilityPower = 80;
            DodgeChance = 25;
            OffensiveAbilities = new List<Ability>();
            DefensiveAbilities = new List<Ability>();
            StandByAbilities = new List<Ability>();
            DamageModifiers = new Dictionary<Type, double>
            {
                { typeof(Warrior), 2.0 },
                { typeof(DeathKnight), 2.0 },
                { typeof(Mage), 0.5 }
            };
        }

        public override int Attack()
        {
            int attack = GetRandomizedAttackValue();
            attack += CastSpell(OffensiveAbilities);

            return attack;
        }

        public override int Defend()
        {
            int dodgeChance = DodgeChance;

            int roll = Random.Shared.Next(1, 101);
            if (roll <= dodgeChance)
            {
                Console.WriteLine($"{PlayerName} dodged the attack!");
                return 500000;
            }

            int defensiveValue = Armor;
            defensiveValue += CastSpell(DefensiveAbilities);

            return defensiveValue;
        }
    }
}
