using System;
using Igra.Monsters;
using Igra.Heroes;
using Igra.Logging;
using Igra.Battles;

namespace Igra.Locations
{
    public interface ILocation
    {
        int Id { get; }
        string Name { get; }
        void ApplyEffect(Hero hero);
        void Play(Hero hero, Logi log);
    }

    public class Location : ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HealAmount;
        public Monster Monster;
        public int[,] Map;
        public int posY = 1;
        public int posX = 1;

        public Location(int id, string name, int healAmount, int[,] map, Monster monster = null)
        {
            Id = id;
            Name = name;
            HealAmount = healAmount;
            Map = map;
            Monster = monster;
        }

        public void ApplyEffect(Hero hero)
        {
            if (HealAmount > 0) hero.Heal(HealAmount);
        }

        public static bool Move(ConsoleKey key, int[,] map, ref int posY, ref int posX)
        {
            switch (key)
            {
                case ConsoleKey.W: if (posY > 0) posY--; break;
                case ConsoleKey.A: if (posX > 0) posX--; break;
                case ConsoleKey.S: if (posY < map.GetLength(0) - 1) posY++; break;
                case ConsoleKey.D: if (posX < map.GetLength(1) - 1) posX++; break;
                case ConsoleKey.Q: return false;
            }
            return true;
        }

        public void Play(Hero hero, Logi log)
        {
            bool inLocation = true;

            while (inLocation)
            {
                log.Log(Name);

                for (int y = 0; y < Map.GetLength(0); y++)
                {
                    string row = "";
                    for (int x = 0; x < Map.GetLength(1); x++)
                    {
                        if (x == posX && y == posY) row += " 0 ";
                        else row += " " + Map[y, x] + " ";
                    }
                    log.Log(row);
                }
                
                log.Log("hp: " + hero.Health);
                log.Log("wasd - walk, q - exit the location, z - exit game");

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Z)
                {
                    log.Close();
                    Environment.Exit(0);
                }

                inLocation = Move(key.Key, Map, ref posY, ref posX);

                if (Map[posY, posX] == 2 && Monster != null)
                {
                    Battle.Start(hero, Monster, log);
                    
                    if (Monster.Health <= 0)
                    {
                        Map[posY, posX] = 1;
                    }
                }
                else if (Map[posY, posX] == 3)
                {
                    ApplyEffect(hero);
                }
            }
        }
    }

    public class Forest : Location
    {
        public Forest() : base(1, "Forest", 0, new int[3, 3]
        {
            {1, 2, 1},
            {1, 1, 1},
            {1, 1, 1}
        }, new Vampire()) 
        { 
            posY = 1; posX = 1; 
        }
    }

    public class Home : Location
    {
        public Home() : base(2, "Home", 50, new int[3, 3]
        {
            {3, 3, 3},
            {3, 3, 3},
            {3, 3, 3}
        }, null) 
        { 
            posY = 2; posX = 2; 
        }
    }
}