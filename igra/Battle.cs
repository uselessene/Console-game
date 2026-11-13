using System;
using Igra.Heroes;
using Igra.Monsters;
using Igra.Logging;

namespace Igra.Battles
{
    public class Battle
    {
        public static void Start(Hero hero, Monster monster, Logi log)
        {
            while (hero.Health > 0 && monster.Health > 0)
            {
                log.Log("hero hp: " + hero.Health + "  Monster hp: " + monster.Health);
                log.Log("1. Attack");
                log.Log("2. Heal");
                log.Log("3. Run away");

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                {
                    int dmg = hero.Ataka();
                    monster.PoluchDamage(dmg);
                    log.Log("You hit for " + dmg + "!");
                }
                else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
                {
                    hero.Heal(30);
                    log.Log("You healed!");
                }
                else if (key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.NumPad3)
                {
                    log.Log("You run!");
                    Console.ReadKey(true);
                    return;
                }

                if (monster.Health > 0)
                {
                    int monsterDmg = monster.Ataka();
                    hero.PoluchDamage(monsterDmg);
                    log.Log("Monster hit you for " + monsterDmg + "!");
                }
                Console.ReadKey(true);
            }

            if (hero.Health <= 0)
            {
                log.Log("You died");
                Console.ReadKey(true);
                log.Close();
                Environment.Exit(0);
            }
            else
            {
                log.Log("You won!");
                Console.ReadKey(true);
            }
        }
    }
}