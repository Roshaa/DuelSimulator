# ⚔️ C# OOP & SOLID Principles: A Turn-Based Duel Simulator

This console application simulates a turn-based duel between two fantasy characters. The main goal is to demonstrate mastery of **Object-Oriented Programming (OOP)** and the **SOLID principles** in C#.

> 🔧 **Purpose:** Showcase clean, maintainable, and extensible code using OOP best practices—not focus on game design.

---

## 🧠 Key Design & Architecture

### ✅ Data-Driven Design

Game logic is **data-first**, minimizing hardcoding and maximizing extensibility:

- **Abilities & Items:** All abilities and items are defined as *data instances* (not unique classes). Add 100+ items/abilities with no code changes.
- **Damage Modifiers:** Class advantages are defined in a `DamageModifiers` dictionary. No `if/else` or switch spaghetti.

### 🧱 SOLID Principles in Action

| Principle | Implementation |
|----------|----------------|
| **S**ingle Responsibility | Each class has one job (e.g., `Duel`, `InputHandler`, `Character`). |
| **O**pen/Closed           | Add new classes/items/abilities without modifying existing logic. |
| **L**iskov Substitution   | `Duel` interacts only with `AbstractClass`, not specific subclasses. |
| **I**nterface Segregation| Interfaces are small and focused (e.g., `IClassInterface`). |
| **D**ependency Inversion | Core logic (`Duel`) depends on abstractions, not implementations. |

---

## 🛠️ Tech Stack

- **Language:** C#
- **Framework:** .NET (6.0+)
- **Platform:** Console Application

---

## 📁 Project Structure

/Classes -> AbstractClass and concrete implementations (e.g., Warrior, Mage)
/Abilities -> Ability class (data-driven)
/Items -> Item class (data-driven)
/Combat -> Duel logic (orchestration)
/Interfaces -> Core abstractions
/UserInputs -> Handles user input
Program.cs -> App entry point (object composition and simulation start)


---

## 🚀 How to Run


# 1. Clone the repo
git clone https://github.com/<your-github-username>/DuelSimulator.git

# 2. Navigate into the project
cd DuelSimulator

# 3. Run the application
dotnet run

Or open in your IDE and run

---

## Example Output:
---

```bash
Welcome to my duel simulator!
You will be given random choices to construct 2 classes, then the classes will duel.
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
A (Ranger) attacks B (Ranger)!
A casts Fireball (Mana Cost: 100, Cooldown: 3 turns)!
  Value from spell: 1000
  A's remaining mana: 500
  Attack Value: 2510
Defense Value: 105
Not very effective... Attack is reduced by 0.5x.
A deals 1202 damage!
B's remaining health: 4498

B (Ranger) attacks A (Ranger)!
B casts Pyroblast (Mana Cost: 750, Cooldown: 8 turns)!
  Value from spell: 1200
  B's remaining mana: 350
  Attack Value: 2408
Defense Value: 180
Not very effective... Attack is reduced by 0.5x.
B deals 1114 damage!
A's remaining health: 2786

A regenerates 25 health (2786 → 2811)
A regenerates 40 mana (500 → 540)

B casts Healing Light (Mana Cost: 350, Cooldown: 7 turns)!
  Value from spell: 1000
  B's remaining mana: 0
B heals 1150 health (4498 → 5648)
B regenerates 65 mana (0 → 65)

--- Turn 2 ---
...

*** Player1 wins the duel! ***
