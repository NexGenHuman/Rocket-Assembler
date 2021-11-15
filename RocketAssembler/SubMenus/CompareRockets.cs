using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketAssembler.GraphicalFuncs;
using RocketAssembler.UtilityClasses;

namespace RocketAssembler.SubMenus
{
    static class CompareRockets
    {
        public static void drawCompareRockets()
        {
            Console.Clear();

            if (RocketList.rockets.Count == 0)
                return;

            Tuple<int, int> listPos1 = new Tuple<int, int>(5, 3);
            Tuple<int, int> listPos2 = new Tuple<int, int>(90, 3);

            bool running = true;

            SelectorArrow arrow1 = new SelectorArrow(listPos1, RocketList.rockets.Count, 1);
            SelectorArrow arrow2 = new SelectorArrow(listPos2, RocketList.rockets.Count, 1);

            string rocketTemp = "";
            foreach (var rocket in RocketList.rockets)
            {
                rocketTemp += rocket.name + "\n";
            }

            Console.SetCursorPosition(0, 0);
            PresetGraphicDrawer.WritePaddedLeft(rocketTemp, listPos1.Item1 + 4, listPos1.Item2);
            Console.SetCursorPosition(0, 0);
            PresetGraphicDrawer.WritePaddedLeft(rocketTemp, listPos2.Item1 + 4, listPos2.Item2);

            PresetGraphicDrawer.WriteControls(TextInitializer.rocketCompareControls);

            while (running)
            {
                for (int i = 0; i < Console.WindowHeight - 1; i++)
                {
                    Console.SetCursorPosition(25, i);
                    Console.Write("                                                                 ");
                }

                int yPos = 3;
                int xPos1 = 25, xPos2 = 60;

                Console.SetCursorPosition(xPos1, yPos);
                Console.Write(RocketList.rockets[arrow1.current].name);

                Console.SetCursorPosition(xPos2, yPos);
                Console.Write(RocketList.rockets[arrow2.current].name);


                yPos++;


                Console.SetCursorPosition(xPos1, yPos);
                Console.Write("------------------------------");

                Console.SetCursorPosition(xPos2, yPos);
                Console.Write("------------------------------");


                yPos++;


                CompareParts.printComparedPart(RocketList.rockets[arrow1.current].capsule, RocketList.rockets[arrow2.current].capsule, xPos1, yPos);
                CompareParts.printComparedPart(RocketList.rockets[arrow2.current].capsule, RocketList.rockets[arrow1.current].capsule, xPos2, yPos);


                yPos += 4;


                Console.SetCursorPosition(xPos1, yPos);
                Console.Write("------------------------------");

                Console.SetCursorPosition(xPos2, yPos);
                Console.Write("------------------------------");


                yPos++;


                CompareParts.printComparedPart(RocketList.rockets[arrow1.current].main_stage, RocketList.rockets[arrow2.current].main_stage, xPos1, yPos);
                CompareParts.printComparedPart(RocketList.rockets[arrow2.current].main_stage, RocketList.rockets[arrow1.current].main_stage, xPos2, yPos);


                yPos += 7;


                Console.SetCursorPosition(xPos1, yPos);
                Console.Write("------------------------------");

                Console.SetCursorPosition(xPos2, yPos);
                Console.Write("------------------------------");


                yPos++;


                CompareParts.printComparedPart(RocketList.rockets[arrow1.current].orbital_stage, RocketList.rockets[arrow2.current].orbital_stage, xPos1, yPos);
                CompareParts.printComparedPart(RocketList.rockets[arrow2.current].orbital_stage, RocketList.rockets[arrow1.current].orbital_stage, xPos2, yPos);


                yPos += 7;


                Console.SetCursorPosition(xPos1, yPos);
                Console.Write("------------------------------");

                Console.SetCursorPosition(xPos2, yPos);
                Console.Write("------------------------------");


                yPos++;

                if (RocketList.rockets[arrow1.current].solid_fuel_booster != null && RocketList.rockets[arrow2.current].solid_fuel_booster != null)
                {
                    CompareParts.printComparedPart(RocketList.rockets[arrow1.current].solid_fuel_booster, RocketList.rockets[arrow2.current].solid_fuel_booster, xPos1, yPos);
                    CompareParts.printComparedPart(RocketList.rockets[arrow2.current].solid_fuel_booster, RocketList.rockets[arrow1.current].solid_fuel_booster, xPos2, yPos);
                }
                else
                {
                    Console.SetCursorPosition(0, 0);
                    PresetGraphicDrawer.WritePaddedLeft(PartsList.partDescription(RocketList.rockets[arrow1.current].solid_fuel_booster), xPos1, yPos);
                    Console.SetCursorPosition(0, 0);
                    PresetGraphicDrawer.WritePaddedLeft(PartsList.partDescription(RocketList.rockets[arrow2.current].solid_fuel_booster), xPos2, yPos);
                    Console.SetCursorPosition(0, 0);
                }


                ConsoleKey choice = Console.ReadKey(true).Key;

                switch (choice)
                {
                    //-------------------------------Move the arrow up on right
                    case ConsoleKey.UpArrow:
                        arrow2.moveArrow(false);
                        break;

                    //-------------------------------Move the arrow down on right
                    case ConsoleKey.DownArrow:
                        arrow2.moveArrow(true);
                        break;
                    //-------------------------------Move the arrow up on left
                    case ConsoleKey.W:
                        arrow1.moveArrow(false);
                        break;

                    //-------------------------------Move the arrow down on left
                    case ConsoleKey.S:
                        arrow1.moveArrow(true);
                        break;
                    //-------------------------------Return to main menu
                    case ConsoleKey.Q:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
