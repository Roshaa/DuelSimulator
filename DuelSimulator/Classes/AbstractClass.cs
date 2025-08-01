using DuelSimulator.Abilities;
using DuelSimulator.Enum;
using DuelSimulator.Interfaces;
using DuelSimulator.Items;

namespace DuelSimulator.Classes;

public abstract class AbstractClass : IClassInterface
{
    public string PlayerName { get; protected set; }
    public int Health { get; protected set; }
    public int MaxHP { get; protected set; }
    public int Mana { get; protected set; }
    public int MaxMana { get; protected set; }
    public int Armor { get; protected set; }
    public int HealthRegen { get; protected set; }
    public int ManaRegen { get; protected set; }
    public int AttackValue { get; protected set; }
    public int AbilityPower { get; protected set; }
    public int AbilityChoices { get; protected set; } = 2;
    public int EquippableItems { get; protected set; } = 3;

    public List<Ability> OffensiveAbilities;
    public List<Ability> DefensiveAbilities;
    public List<Ability> StandByAbilities;
    public Dictionary<Type, double> DamageModifiers { get; protected set; } = new();

    public virtual int Attack()
    {
        throw new NotImplementedException();
    }

    public virtual int Defend()
    {
        int defensiveValue = Armor;
        defensiveValue += CastSpell(DefensiveAbilities);
        return defensiveValue;
    }

    public void AddAbility(Ability ability)
    {
        switch (ability.Type)
        {
            case AbilityTypeEnum.Offensive:
                OffensiveAbilities.Add(ability);
                break;
            case AbilityTypeEnum.Defensive:
                DefensiveAbilities.Add(ability);
                break;
            case AbilityTypeEnum.StandBy:
                StandByAbilities.Add(ability);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(ability.Type), "Unknown ability type");
        }
    }

    protected int GetRandomizedAttackValue()
    {
        double multiplier = Random.Shared.NextDouble() * 0.6 + 0.6;
        return (int)(AttackValue * multiplier);
    }

    public int CastSpell(List<Ability> listOfAbilities)
    {
        int spellValue = 0;
        bool spellCast = false;

        foreach (Ability ability in listOfAbilities)
        {
            if (ability.CurrentCooldown == 0 && Mana >= ability.ManaCost)
            {
                Console.WriteLine($"{PlayerName} casts {ability.Name} (Mana Cost: {ability.ManaCost}, Cooldown: {ability.Cooldown} turns)!");
                spellValue = ability.CastAbility(AbilityPower);
                Mana -= ability.ManaCost;
                Console.WriteLine($"  Value from spell: {spellValue}");
                Console.WriteLine($"  {PlayerName}'s remaining mana: {Mana}");
                spellCast = true;
                break;
            }
        }

        if (!spellCast && listOfAbilities.Count > 0)
        {
            Console.WriteLine($"{PlayerName} could not cast any spell (insufficient mana or all abilities on cooldown).");
        }

        return spellValue;
    }

    public void DecreaseAllCooldowns()
    {
        DecreaseCooldownHelper(OffensiveAbilities);
        DecreaseCooldownHelper(DefensiveAbilities);
        DecreaseCooldownHelper(StandByAbilities);
    }

    private void DecreaseCooldownHelper(List<Ability> listOfAbilities)
    {
        foreach (Ability ability in listOfAbilities)
        {
            if (ability.CurrentCooldown > 0) ability.CurrentCooldown--;
        }
    }

    public void TakeDamage(int amount)
    {
        if (amount > 0)
        {
            Health -= amount;
        }
    }

    public void Heal(int amount)
    {
        if (amount > 0)
        {
            Health += amount;
        }
    }

    public void RegenMana(int amount)
    {
        if (amount > 0)
        {
            Mana += amount;
        }
    }

    public void EquipItem(Item item)
    {
        Console.WriteLine($"{PlayerName} equipped: {item.Name}!");

        Health += item.HealthBonus;
        MaxHP += item.HealthBonus;
        Mana += item.ManaBonus;
        MaxMana += item.ManaBonus;
        Armor += item.ArmorBonus;
        HealthRegen += item.HealthRegenBonus;
        ManaRegen += item.ManaRegenBonus;
        AttackValue += item.AttackValueBonus;
        AbilityPower += item.AbilityPowerBonus;
    }

}
