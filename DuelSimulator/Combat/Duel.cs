using DuelSimulator.Classes;

namespace DuelSimulator.Combat
{
    public class Duel
    {
        public AbstractClass class1;
        public AbstractClass class2;

        public Duel(AbstractClass firstClass, AbstractClass secondClass)
        {
            class1 = firstClass;
            class2 = secondClass;
        }

        public void StartCombat()
        {
            int roll = Random.Shared.Next(1, 9);
            bool class1Starts = roll <= 4;
            int turnsTaken = 0;

            Console.WriteLine("========================================");
            Console.WriteLine("DUEL START!");
            Console.WriteLine($"Random roll: {roll} ({(class1Starts ? class1.PlayerName : class2.PlayerName)} starts first)");
            Console.WriteLine("========================================\n");

            while (turnsTaken < 100)
            {
                Console.WriteLine($"\n--- Turn {turnsTaken + 1} ---");

                if (class1Starts)
                {
                    if (AttackTurn(class1, class2)) break;
                    if (AttackTurn(class2, class1)) break;
                    StandByPhase(class1);
                    StandByPhase(class2);
                    class1.DecreaseAllCooldowns();
                    class2.DecreaseAllCooldowns();
                }
                else
                {
                    if (AttackTurn(class2, class1)) break;
                    if (AttackTurn(class1, class2)) break;
                    StandByPhase(class2);
                    StandByPhase(class1);
                    class2.DecreaseAllCooldowns();
                    class1.DecreaseAllCooldowns();
                }
                Thread.Sleep(2000);
                turnsTaken++;
            }

            if (turnsTaken == 100)
                Console.WriteLine("\nThe combat ended in a draw!");
        }

        private bool AttackTurn(AbstractClass attackingClass, AbstractClass defendingClass)
        {
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine($"{attackingClass.PlayerName} ({attackingClass.GetType().Name}) attacks {defendingClass.PlayerName} ({defendingClass.GetType().Name})!");


            Console.WriteLine("------------Class Attacking---------------");
            int attackValue = attackingClass.Attack();
            Console.WriteLine($"  Attack Value: {attackValue}");
            Console.WriteLine("------------Class Defending---------------");
            int defenseValue = defendingClass.Defend();
            Console.WriteLine($"  Defense Value: {defenseValue}");
            int damage = attackValue - defenseValue;
            Console.WriteLine("------------Turn Result---------------");

            if (defendingClass.DamageModifiers.TryGetValue(attackingClass.GetType(), out double modifier))
            {
                int originalDamage = damage > 0 ? damage : 0;
                damage = (int)(originalDamage * modifier);

                if (modifier > 1.0)
                {
                    Console.WriteLine($"  It's super effective! The attack is amplified by {modifier}x.");
                }
                else if (modifier < 1.0)
                {
                    Console.WriteLine($"  It's not very effective... The attack is reduced by {modifier}x.");
                }
            }


            if (damage > 0)
            {
                defendingClass.TakeDamage(damage);
                Console.WriteLine($"  {attackingClass.PlayerName} deals {damage} damage!");
            }
            else
            {
                Console.WriteLine($"  {attackingClass.PlayerName}'s attack was too weak to penetrate {defendingClass.PlayerName}'s defense!");
            }

            Console.WriteLine($"  {defendingClass.PlayerName}'s remaining health: {Math.Max(defendingClass.Health, 0)}");

            if (defendingClass.Health < 1)
            {
                Console.WriteLine($"\n*** {attackingClass.PlayerName} wins the duel! ***");
                return true;
            }
            return false;
        }


        public virtual void StandByPhase(AbstractClass player)
        {
            Console.WriteLine("------------------------------------------------------------------------------------");
            int oldHealth = player.Health;
            int healthLost = player.MaxHP - player.Health;
            int spellRegen = (healthLost >= 500) ? player.CastSpell(player.StandByAbilities) : 0;
            int healthRegenAmount = player.HealthRegen + spellRegen;
            int newHealth = Math.Min(player.Health + healthRegenAmount, player.MaxHP);
            healthRegenAmount = newHealth - oldHealth;
            player.Heal(healthRegenAmount);

            if (healthRegenAmount > 0)
            {
                Console.WriteLine($"{player.PlayerName} regenerates {healthRegenAmount} health (from {oldHealth} to {player.Health}/{player.MaxHP}).");
            }
            else
            {
                Console.WriteLine($"{player.PlayerName} is already at max health ({player.Health}/{player.MaxHP}). No health regeneration needed.");
            }

            int oldMana = player.Mana;
            int manaRegenAmount = player.ManaRegen;
            int newMana = Math.Min(player.Mana + manaRegenAmount, player.MaxMana);
            manaRegenAmount = newMana - oldMana;
            player.RegenMana(manaRegenAmount);

            if (manaRegenAmount > 0)
            {
                Console.WriteLine($"{player.PlayerName} regenerates {manaRegenAmount} mana (from {oldMana} to {player.Mana}/{player.MaxMana}).");
            }
            else
            {
                Console.WriteLine($"{player.PlayerName} is already at max mana ({player.Mana}/{player.MaxMana}). No mana regeneration needed.");
            }
            Console.WriteLine("------------------------------------------------------------------------------------");
        }
    }
}