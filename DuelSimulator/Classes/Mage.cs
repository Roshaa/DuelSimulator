using DuelSimulator.Abilities;

namespace DuelSimulator.Classes
{
    public class Mage : AbstractClass
    {
        public Mage(string name)
        {
            PlayerName = name;
            Health = 3000;
            MaxHP = Health;
            Mana = 1000;
            MaxMana = Mana;
            Armor = 0;
            HealthRegen = 50;
            ManaRegen = 60;
            AttackValue = 50;
            AbilityPower = 150;
            AbilityChoices = 5;
            OffensiveAbilities = new List<Ability>();
            DefensiveAbilities = new List<Ability>();
            StandByAbilities = new List<Ability>();
            DamageModifiers = new Dictionary<Type, double>
            {
                { typeof(Ranger), 2.0 }
            };
        }

        public override int Attack()
        {
            int attack = GetRandomizedAttackValue();
            attack += CastSpell(OffensiveAbilities);
            attack += CastSpell(OffensiveAbilities);
            return attack;
        }

    }
}
