# C# OOP & SOLID Principles: A Turn-Based Duel Simulator

This console application is a hands-on project designed to demonstrate a deep, practical understanding of Object-Oriented Programming (OOP) and the five SOLID design principles. It simulates a turn-based duel between two fantasy characters, where the focus is not on the game itself, but on the quality, maintainability, and extensibility of the underlying code.

This project serves as a portfolio piece to showcase the ability to write C# code.

## Key Design & Architectural Patterns

This project intentionally uses specific design patterns and architectural decisions to create a robust and flexible system.

### Data-Driven Design
A core principle of this project is to define game content as data, not as code. This is a modern approach that allows for rapid content expansion without modifying core application logic.
*   **Abilities & Items:** Instead of creating a separate class for every ability (`Fireball`, `Ice Barrier`) and item (`Frostmourne`, `The One Ring`), they are defined as instances of a single, concrete `Ability` and `Item` class. This makes the system incredibly extensible—adding 20 new items is as simple as adding 20 new lines to a list, with no new classes required.
*   **Damage Modifiers:** Class-vs-class advantages (e.g., "Warrior is strong against Assassin") are not hard-coded with `if/else` statements. Instead, each class defines its own weaknesses and resistances in a `DamageModifiers` dictionary. This logic is applied generically by the central combat engine.

### SOLID Principles in Action

*   **[S] Single Responsibility Principle:** Each class has a single, well-defined purpose. The `Duel` class manages the combat flow, `AbstractClass` and its children manage their own state, and the `InputHandler` manages user interaction.
*   **[O] Open/Closed Principle:** The system is open for extension but closed for modification. You can add a new `Paladin` class, 50 new abilities, or 100 new items without changing any of the existing, tested code in the core combat or character classes.
*   **[L] Liskov Substitution Principle:** All character classes inherit from `AbstractClass`. The `Duel` engine can work with any two `AbstractClass` objects, treating them identically without needing to know their concrete types (`Warrior`, `Mage`, etc.).
*   **[I] Interface Segregation Principle:** Interfaces are kept small and focused (e.g., `IClassInterface`).
*   **[D] Dependency Inversion Principle:** High-level modules like `Duel` depend on abstractions (`AbstractClass`), not on low-level concrete classes (`Warrior`). This decouples the system and allows for greater flexibility.

## Tech Stack

*   **Language:** C#
*   **Framework:** .NET
*   **Platform:** Console Application

## Code Structure Overview

*   **/Classes:** Contains the `AbstractClass` base class and concrete implementations like `Warrior`, `Mage`, and `Assassin`.
*   **/Abilities:** Contains the data-driven `Ability` class.
*   **/Items:** Contains the data-driven `Item` class.
*   **/Combat:** Contains the `Duel` class, which orchestrates the entire simulation.
*   **/Interfaces:** Contains the core abstractions for the project.
*   **/UserInputs:** Contains the `InputHandler` responsible for all console interaction.
*   **Program.cs:** The application's entry point, responsible for composing the objects and starting the simulation.






Example Console Output:

Welcome to my duel simulator!
You will be given random choices to constructs 2 classes, then the classes will duel.
Enter your player name: Player1
Choose your class:
1. Warrior
   Health: 6000, Mana: 0, Armor: 75
   Health Regen: 80, Mana Regen: 0
   Attack Value: 200, Ability Power: 0
   Ability Choices: 0
2. Assassin
   Health: 5000, Mana: 400, Armor: 20
   Health Regen: 25, Mana Regen: 10
   Attack Value: 200, Ability Power: 80
   Ability Choices: 2
3. DeathKnight
   Health: 8000, Mana: 500, Armor: 100
   Health Regen: 50, Mana Regen: 60
   Attack Value: 100, Ability Power: 120
   Ability Choices: 2

Choose ability 1 for Player1:
1. Thornmail Aura (Type: Defensive, Power: 100, Mana Cost: 150, Cooldown: 5)
2. Poisoned Dagger (Type: Offensive, Power: 120, Mana Cost: 70, Cooldown: 3)
3. Mana Spring (Type: StandBy, Power: 150, Mana Cost: 50, Cooldown: 5)
Enter the number of your choice: 1
Thornmail Aura added to Player1's abilities.

Choose ability 2 for Player1:
1. Divine Shield (Type: Defensive, Power: 150, Mana Cost: 100, Cooldown: 4)
2. Mana Spring (Type: StandBy, Power: 150, Mana Cost: 50, Cooldown: 5)
3. Parry (Type: Defensive, Power: 50, Mana Cost: 25, Cooldown: 1)
Enter the number of your choice:
Invalid selection. Please enter a valid number.
Enter the number of your choice: 1
Divine Shield added to Player1's abilities.

Player1 will receive 3 item(s).
Player1 equipped: Glamdring, the Foe-hammer!
Player1 equipped: Warglaives of Azzinoth!
Player1 equipped: Infinity Edge!


--- Class 1 Info ---
Class: Ranger
Player Name: A
Health: 3900
Mana: 600
Armor: 180
Health Regen: 25
Mana Regen: 40
Attack Value: 1370
Ability Power: 750

--- Class 2 Info ---
Class: Ranger
Player Name: B
Health: 5700
Mana: 1100
Armor: 105
Health Regen: 150
Mana Regen: 65
Attack Value: 1050
Ability Power: 400
Type 'start' to begin the duel: start
========================================
DUEL START!
Random roll: 2 (A starts first)
========================================




--- Turn 1 ---
------------------------------------------------------------------------------------
A (Ranger) attacks B (Ranger)!
------------Class Attacking---------------
A casts Fireball (Mana Cost: 100, Cooldown: 3 turns)!
  Value from spell: 1000
  A's remaining mana: 500
  Attack Value: 2510
------------Class Defending---------------
  Defense Value: 105
------------Turn Result---------------
  It's not very effective... The attack is reduced by 0.5x.
  A deals 1202 damage!
  B's remaining health: 4498
------------------------------------------------------------------------------------
B (Ranger) attacks A (Ranger)!
------------Class Attacking---------------
B casts Pyroblast (Mana Cost: 750, Cooldown: 8 turns)!
  Value from spell: 1200
  B's remaining mana: 350
  Attack Value: 2408
------------Class Defending---------------
  Defense Value: 180
------------Turn Result---------------
  It's not very effective... The attack is reduced by 0.5x.
  B deals 1114 damage!
  A's remaining health: 2786
------------------------------------------------------------------------------------
A regenerates 25 health (from 2786 to 2811/3900).
A regenerates 40 mana (from 500 to 540/600).
------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
B casts Healing Light (Mana Cost: 350, Cooldown: 7 turns)!
  Value from spell: 1000
  B's remaining mana: 0
B regenerates 1150 health (from 4498 to 5648/5700).
B regenerates 65 mana (from 0 to 65/1100).
------------------------------------------------------------------------------------

--- Turn 2 ---

...

*** Player1 wins the duel! ***
