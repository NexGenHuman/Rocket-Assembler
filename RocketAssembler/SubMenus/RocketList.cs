using System;
using System.Collections.Generic;
using RocketAssembler.UtilityClasses;
using RocketAssembler.GraphicalFuncs;

namespace RocketAssembler.SubMenus
{
    static class RocketList
    {
        static public List<Rocket> rockets = new List<Rocket>();

        public static string writeAllParts(Rocket _rocket)
        {
            string toWrite = "";
            toWrite += "Name - " + _rocket.name + "\n";
            if (_rocket.capsule != null)
            {
                toWrite += "------------------------------" + "\n";
                toWrite += PartsList.partDescription(_rocket.capsule);
            }
            if (_rocket.orbital_stage != null)
            {
                toWrite += "------------------------------" + "\n";
                toWrite += PartsList.partDescription(_rocket.orbital_stage);
            }
            if (_rocket.main_stage != null)
            {
                toWrite += "------------------------------" + "\n";
                toWrite += PartsList.partDescription(_rocket.main_stage);
            }
            if (_rocket.solid_fuel_booster != null)
            {
                toWrite += "------------------------------" + "\n";
                toWrite += PartsList.partDescription(_rocket.solid_fuel_booster);
            }

            return toWrite;
        }

        public static void writeRocketList()
        {
            Console.Clear();

            bool running = true;

            if (rockets.Count == 0)
                return;

            SelectorArrow arrow = new SelectorArrow(new Tuple<int, int>(11, 6), rockets.Count, 1);
            Tuple<int, int> rocketListPos = new Tuple<int, int>(40, 3);

            Console.SetCursorPosition(0, 0);
            PresetGraphicDrawer.PresetGraphicDraw("rocketsList", ConsoleColor.White);
            Console.SetCursorPosition(0, 0);

            int prevWidth = 0, prevHeight = 0;
            int prevArrowPos = 1;

            while (running)
            {
                if (prevArrowPos != arrow.current)
                {
                    Console.SetCursorPosition(rocketListPos.Item1, rocketListPos.Item2);
                    for (int i = 0; i < prevHeight; i++)
                    {
                        for (int j = 0; j < prevWidth; j++)
                        {
                            Console.Write(" ");
                        }
                        Console.SetCursorPosition(rocketListPos.Item1, rocketListPos.Item2 + i);
                    }
                    prevHeight = 1;
                    prevWidth = 0;

                    string toWrite = writeAllParts(rockets[arrow.current]);

                    int tempCounter = 0;

                    foreach (char ch in toWrite)
                    {
                        if (ch != '\n')
                            tempCounter++;
                        else
                        {
                            prevHeight++;
                            if (tempCounter > prevWidth)
                                prevWidth = tempCounter;
                            tempCounter = 0;
                        }
                    }
                    prevHeight++;

                    if (tempCounter > prevWidth)
                        prevWidth = tempCounter;

                    Console.SetCursorPosition(0, 0);
                    if (rockets[arrow.current].solid_fuel_booster == null)
                        PresetGraphicDrawer.DrawRocket(new Tuple<int, int>(84, 7), true, true, true, false);
                    else
                        PresetGraphicDrawer.DrawRocket(new Tuple<int, int>(84, 7), true, true, true, true);

                    Console.SetCursorPosition(0, 0);
                    PresetGraphicDrawer.WritePaddedLeft(toWrite, rocketListPos.Item1, rocketListPos.Item2);
                }

                prevArrowPos = arrow.current;

                ConsoleKey choice = Console.ReadKey(true).Key;

                switch (choice)
                {
                    //-------------------------------Move the arrow up
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        arrow.moveArrow(false);
                        break;

                    //-------------------------------Move the arrow down
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        arrow.moveArrow(true);
                        break;
                    //-------------------------------Return to main menu
                    case ConsoleKey.Q:
                        return;
                    default:
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}