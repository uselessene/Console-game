using System;
using Igra.Heroes;
using Igra.Locations;
using Igra.Logging;

namespace Igra
{
    class Program
    {
        static void Main()
        {
            Logi log = new Logi("Log.txt");
            Hero hero = new Hero("Hero", 100, 15);
            Forest forest = new Forest();
            Home home = new Home();

            int[,] osnMap = new int[3, 3]
            {
                {1, 2, 1},
                {1, 1, 1},
                {1, 3, 1}
            };

            int posY = 1;
            int posX = 1;
            bool gameRun = true;

            while (gameRun)
            {
                log.Log("Base location");
                for (int y = 0; y < 3; y++)
                {
                    string row = "";
                    for (int x = 0; x < 3; x++)
                    {
                        if (x == posX && y == posY) row += " 0 ";
                        else row += " " + osnMap[y, x] + " ";
                    }
                    log.Log(row);
                }
                
                log.Log("hp: " + hero.Health);
                log.Log("wasd - walk, z - exit game");

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Z)
                {
                    log.Close();
                    Environment.Exit(0);
                }

                gameRun = Location.Move(key.Key, osnMap, ref posY, ref posX);

                int znach = osnMap[posY, posX];

                if (znach == 2)
                {
                    forest.Play(hero, log);
                    posY = 1; posX = 1;
                }
                else if (znach == 3)
                {
                    home.Play(hero, log);
                    posY = 1; posX = 1;
                }
            }
        }
    }
}