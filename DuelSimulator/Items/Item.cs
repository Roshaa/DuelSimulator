namespace DuelSimulator.Items
{
    public class Item
    {
        public string Name { get; }
        public int HealthBonus { get; }
        public int ManaBonus { get; }
        public int ArmorBonus { get; }
        public int HealthRegenBonus { get; }
        public int ManaRegenBonus { get; }
        public int AttackValueBonus { get; }
        public int AbilityPowerBonus { get; }

        public Item(
            string name,
            int healthBonus = 0,
            int manaBonus = 0,
            int armorBonus = 0,
            int healthRegenBonus = 0,
            int manaRegenBonus = 0,
            int attackValueBonus = 0,
            int abilityPowerBonus = 0)
        {
            Name = name;
            HealthBonus = healthBonus;
            ManaBonus = manaBonus;
            ArmorBonus = armorBonus;
            HealthRegenBonus = healthRegenBonus;
            ManaRegenBonus = manaRegenBonus;
            AttackValueBonus = attackValueBonus;
            AbilityPowerBonus = abilityPowerBonus;
        }
    }
}