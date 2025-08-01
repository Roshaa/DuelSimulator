using DuelSimulator.Classes;
using DuelSimulator.Combat;
using DuelSimulator.UserInputs;

Console.WriteLine("Welcome to my duel simulator!");
Console.WriteLine("You will be given random choices to constructs 2 classes, then the classes will duel.");

string class1Name = InputHandler.PromptForName("Enter your player name: ");
AbstractClass class1 = InputHandler.PromptForRandomClass(class1Name);
InputHandler.PromptForAbilities(class1);
InputHandler.AssignRandomItems(class1);

Console.WriteLine("--------------------------------------------------------------");
Console.WriteLine("First class has been constructed...");
Console.WriteLine("We will now create the second class..");


string class2Name = InputHandler.PromptForName("Enter your player name: ");
AbstractClass class2 = InputHandler.PromptForRandomClass(class2Name);
InputHandler.PromptForAbilities(class2);
InputHandler.AssignRandomItems(class2);

Console.WriteLine("\n--- Class 1 Info ---");
Console.WriteLine($"Class: {class1.GetType().Name}");
Console.WriteLine($"Player Name: {class1.PlayerName}");
Console.WriteLine($"Health: {class1.Health}");
Console.WriteLine($"Mana: {class1.Mana}");
Console.WriteLine($"Armor: {class1.Armor}");
Console.WriteLine($"Health Regen: {class1.HealthRegen}");
Console.WriteLine($"Mana Regen: {class1.ManaRegen}");
Console.WriteLine($"Attack Value: {class1.AttackValue}");
Console.WriteLine($"Ability Power: {class1.AbilityPower}");

Console.WriteLine("\n--- Class 2 Info ---");
Console.WriteLine($"Class: {class2.GetType().Name}");
Console.WriteLine($"Player Name: {class2.PlayerName}");
Console.WriteLine($"Health: {class2.Health}");
Console.WriteLine($"Mana: {class2.Mana}");
Console.WriteLine($"Armor: {class2.Armor}");
Console.WriteLine($"Health Regen: {class2.HealthRegen}");
Console.WriteLine($"Mana Regen: {class2.ManaRegen}");
Console.WriteLine($"Attack Value: {class2.AttackValue}");
Console.WriteLine($"Ability Power: {class2.AbilityPower}");

while (!InputHandler.ConfirmStartDuel())
{
    Console.WriteLine("Duel not started. Type 'start' to begin the duel.");
}

Duel duel = new Duel(class1, class2);
duel.StartCombat();
