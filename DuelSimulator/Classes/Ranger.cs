using DuelSimulator.Abilities;

namespace DuelSimulator.Classes
{
    public class Ranger : AbstractClass
    {
        public Ranger(string name)
        {
            PlayerName = name;
            Health = 3600;
            MaxHP = Health;
            Mana = 600;
            MaxMana = Mana;
            Armor = 30;
            HealthRegen = 25;
            ManaRegen = 40;
            AttackValue = 150;
            AbilityPower = 100;
            EquippableItems = 5;
            OffensiveAbilities = new List<Ability>();
            DefensiveAbilities = new List<Ability>();
            StandByAbilities = new List<Ability>();
            DamageModifiers = new Dictionary<Type, double>
            {
                { typeof(Ranger), 0.5 }
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
