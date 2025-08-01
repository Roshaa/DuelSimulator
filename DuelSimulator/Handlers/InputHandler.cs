using DuelSimulator.Abilities;
using DuelSimulator.Classes;
using DuelSimulator.Enum;
using DuelSimulator.Items;

namespace DuelSimulator.UserInputs
{
    public class InputHandler
    {
        public static string PromptForName(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                    continue;
                }

                return input.Trim();
            }
        }

        public static AbstractClass PromptForRandomClass(string playerName)
        {
            var classConstructors = new (string Name, Func<string, AbstractClass> Constructor)[]
            {
                ("Warrior", name => new Warrior(name)),
                ("Assassin", name => new Assassin(name)),
                ("Ranger", name => new Ranger(name)),
                ("DeathKnight", name => new DeathKnight(name)),
                ("Mage", name => new Mage(name))
            };

            var rnd = new Random();
            var options = classConstructors.OrderBy(x => rnd.Next()).Take(3).ToArray();

            Console.WriteLine("Choose your class:");
            for (int i = 0; i < options.Length; i++)
            {
                // Construct a temporary instance to show stats
                var temp = options[i].Constructor(playerName);
                Console.WriteLine($"{i + 1}. {options[i].Name}");
                Console.WriteLine($"   Health: {temp.Health}, Mana: {temp.Mana}, Armor: {temp.Armor}");
                Console.WriteLine($"   Health Regen: {temp.HealthRegen}, Mana Regen: {temp.ManaRegen}");
                Console.WriteLine($"   Attack Value: {temp.AttackValue}, Ability Power: {temp.AbilityPower}");
                Console.WriteLine($"   Ability Choices: {temp.AbilityChoices}");
            }

            int choice = 0;
            while (true)
            {
                Console.Write("Enter the number of your choice: ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= 1 && choice <= options.Length)
                    break;
                Console.WriteLine("Invalid selection. Please enter a valid number.");
            }

            return options[choice - 1].Constructor(playerName);
        }

        public static void PromptForAbilities(AbstractClass player)
        {
            var allAbilities = new List<Ability>
            {
                  new Ability(name: "Fireball", power: 250, manaCost: 100, cooldown: 3, type: AbilityTypeEnum.Offensive),
                  new Ability(name: "Lightning Strike", power: 500, manaCost: 600, cooldown: 6, type: AbilityTypeEnum.Offensive),
                  new Ability(name: "Throw Shuriken", power: 100, manaCost: 50, cooldown: 2, type: AbilityTypeEnum.Offensive),
                  new Ability(name: "Divine Shield", power: 150, manaCost: 100, cooldown: 4, type: AbilityTypeEnum.Defensive),
                  new Ability(name: "Rejuvenation", power: 400, manaCost: 200, cooldown: 5, type: AbilityTypeEnum.StandBy),
                  new Ability(name: "Magic Missile", power: 80, manaCost: 40, cooldown: 1, type: AbilityTypeEnum.Offensive),
                  new Ability(name: "Pyroblast", power: 800, manaCost: 750, cooldown: 8, type: AbilityTypeEnum.Offensive),
                  new Ability(name: "Poisoned Dagger", power: 120, manaCost: 70, cooldown: 3, type: AbilityTypeEnum.Offensive),
                  new Ability(name: "Chain Lightning", power: 200, manaCost: 250, cooldown: 4, type: AbilityTypeEnum.Offensive),
                  new Ability(name: "Ice Barrier", power: 400, manaCost: 300, cooldown: 6, type: AbilityTypeEnum.Defensive),
                  new Ability(name: "Parry", power: 50, manaCost: 25, cooldown: 1, type: AbilityTypeEnum.Defensive),
                  new Ability(name: "Thornmail Aura", power: 100, manaCost: 150, cooldown: 5, type: AbilityTypeEnum.Defensive),
                  new Ability(name: "Healing Light", power: 600, manaCost: 350, cooldown: 7, type: AbilityTypeEnum.StandBy),
                  new Ability(name: "Inner Focus", power: 200, manaCost: 100, cooldown: 4, type: AbilityTypeEnum.StandBy),
                  new Ability(name: "Mana Spring", power: 150, manaCost: 50, cooldown: 5, type: AbilityTypeEnum.StandBy)
            };

            var rnd = Random.Shared;
            int numberOfAbilitiesToChoose = 3;

            for (int i = 0; i < player.AbilityChoices; i++)
            {
                var options = allAbilities.OrderBy(x => rnd.Next()).Take(numberOfAbilitiesToChoose).ToList();

                Console.WriteLine($"\nChoose ability {i + 1} for {player.PlayerName}:");
                for (int j = 0; j < options.Count; j++)
                {
                    var ability = options[j];
                    Console.WriteLine($"{j + 1}. {ability.Name} " +
                        $"(Type: {ability.Type}, Power: {ability.Power}, Mana Cost: {ability.ManaCost}, Cooldown: {ability.Cooldown})");
                }

                int choice = 0;
                while (true)
                {
                    Console.Write("Enter the number of your choice: ");
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out choice) && choice >= 1 && choice <= options.Count)
                        break;
                    Console.WriteLine("Invalid selection. Please enter a valid number.");
                }

                var selected = options[choice - 1];
                player.AddAbility(selected);

                Console.WriteLine($"{selected.Name} added to {player.PlayerName}'s abilities.");
            }
        }

        public static void AssignRandomItems(AbstractClass playerClass)
        {
            var allItems = new List<Item>
            {
                // --- Lord of the Rings Universe ---
                new Item(name: "The One Ring", healthBonus: 400, manaBonus: 250, armorBonus: 15, healthRegenBonus: 15, manaRegenBonus: 15, attackValueBonus: 80, abilityPowerBonus: 100),
                new Item(name: "Andúril, Flame of the West", attackValueBonus: 450, abilityPowerBonus: 50),
                new Item(name: "Glamdring, the Foe-hammer", attackValueBonus: 250, abilityPowerBonus: 150),
                new Item(name: "Staff of Gandalf the White", abilityPowerBonus: 500, manaBonus: 200, manaRegenBonus: 50),
                new Item(name: "Mithril Coat", armorBonus: 150, healthBonus: 500),
                new Item(name: "Phial of Galadriel", manaBonus: 300, manaRegenBonus: 75),

                // --- World of Warcraft Universe ---
                new Item(name: "Frostmourne", attackValueBonus: 500, healthBonus: -500, abilityPowerBonus: 400),
                new Item(name: "Gorehowl", attackValueBonus: 900),
                new Item(name: "Atiesh, Greatstaff of the Guardian", abilityPowerBonus: 600, manaBonus: 300),
                new Item(name: "Thunderfury, Blessed Blade of the Windseeker", attackValueBonus: 200, abilityPowerBonus: 200),
                new Item(name: "Warglaives of Azzinoth", attackValueBonus: 350, healthBonus: 150),
                new Item(name: "Bulwark of Azzinoth", armorBonus: 200, healthBonus: 800),

                // --- Dota 2 / League of Legends Universe ---
                new Item(name: "Aegis of the Immortal", healthBonus: 1000, healthRegenBonus: 50),
                new Item(name: "Divine Rapier", attackValueBonus: 1000, healthBonus: -1000),
                new Item(name: "Scythe of Vyse", abilityPowerBonus: 300, manaRegenBonus: 150),
                new Item(name: "Rabadon's Deathcap", abilityPowerBonus: 800),
                new Item(name: "Infinity Edge", attackValueBonus: 600),
                new Item(name: "Heart of Tarrasque", healthBonus: 1500, healthRegenBonus: 100),
                new Item(name: "Blade of the Ruined King", attackValueBonus: 150, healthBonus: 200),
                new Item(name: "Sunfire Cape", armorBonus: 100, healthBonus: 400, attackValueBonus: 20),
    
                // --- Classic D&D / Fantasy Universe ---
                new Item(name: "Holy Avenger", attackValueBonus: 300, abilityPowerBonus: 300),
                new Item(name: "Rod of Lordly Might", attackValueBonus: 250, armorBonus: 50, abilityPowerBonus: 100),
                new Item(name: "Robe of the Archmagi", manaBonus: 800, abilityPowerBonus: 150, armorBonus: 20),
                new Item(name: "Vorpal Sword", attackValueBonus: 550),
                new Item(name: "Deck of Many Things", healthBonus: 500, manaBonus: 500, attackValueBonus: 100, abilityPowerBonus: 100, armorBonus: 50, healthRegenBonus: 25, manaRegenBonus: 25),
                new Item(name: "Dragon Scale Shield", armorBonus: 250, healthBonus: 300),
                new Item(name: "Boots of Speed", healthRegenBonus: 15, manaRegenBonus: 15),
                new Item(name: "Belt of Giant Strength", attackValueBonus: 200, healthBonus: 400),
                new Item(name: "Cloak of Elvenkind", armorBonus: 25, healthBonus: 100)
            };

            Console.WriteLine($"\n{playerClass.PlayerName} will receive {playerClass.EquippableItems} item(s).");

            for (int i = 0; i < playerClass.EquippableItems; i++)
            {
                if (!allItems.Any())
                {
                    Console.WriteLine("No more unique items to assign!");
                    break;
                }
                int itemIndex = Random.Shared.Next(allItems.Count);
                Item randomItem = allItems[itemIndex];
                playerClass.EquipItem(randomItem);
                allItems.RemoveAt(itemIndex);
            }
        }

        public static bool ConfirmStartDuel()
        {
            Console.Write("Type 'start' to begin the duel: ");
            string? input = Console.ReadLine();
            return string.Equals(input, "start", StringComparison.OrdinalIgnoreCase);
        }
    }
}
