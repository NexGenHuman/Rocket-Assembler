using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketAssembler.UtilityClasses;
using RocketAssembler.GraphicalFuncs;

namespace RocketAssembler.SubMenus
{
    static class CompareParts
    {
        public static void printComparedPart(Part drawn, Part compared, int posX, int posY)
        {
            int tempY = posY;

            Console.SetCursorPosition(posX, tempY);
            Console.Write(TextInitializer.name + ": " + drawn.name);

            Console.SetCursorPosition(posX, ++tempY);
            Console.Write(TextInitializer.type + ": ");

            if (drawn is Propolsion && compared is Propolsion)
            {
                if (drawn is Solid_Fuel_Booster)
                    Console.Write(TextInitializer.solid_fuel_booster);
                else if (drawn is Main_Stage)
                    Console.Write(TextInitializer.main_stage);
                else
                    Console.Write(TextInitializer.orbital_stage);

                Propolsion propolsion = drawn as Propolsion;
                Propolsion toCompare = compared as Propolsion;

                Console.SetCursorPosition(posX, ++tempY);
                if (propolsion.empty_mass < toCompare.empty_mass)
                    Console.ForegroundColor = ProgramSetup.positive;
                else if (propolsion.empty_mass > toCompare.empty_mass)
                    Console.ForegroundColor = ProgramSetup.negative;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.Write(TextInitializer.empty_mass + ": " + propolsion.empty_mass + "t");

                Console.SetCursorPosition(posX, ++tempY);
                if (propolsion.fuel_mass > toCompare.fuel_mass)
                    Console.ForegroundColor = ProgramSetup.positive;
                else if (propolsion.fuel_mass < toCompare.fuel_mass)
                    Console.ForegroundColor = ProgramSetup.negative;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.Write(TextInitializer.fuel_mass + ": " + propolsion.fuel_mass + "t");

                Console.SetCursorPosition(posX, ++tempY);
                if (propolsion.thrust > toCompare.thrust)
                    Console.ForegroundColor = ProgramSetup.positive;
                else if (propolsion.thrust < toCompare.thrust)
                    Console.ForegroundColor = ProgramSetup.negative;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.Write(TextInitializer.thrust + ": " + propolsion.thrust + "kN");

                Console.SetCursorPosition(posX, ++tempY);
                if (propolsion.specific_impulse > toCompare.specific_impulse)
                    Console.ForegroundColor = ProgramSetup.positive;
                else if (propolsion.specific_impulse < toCompare.specific_impulse)
                    Console.ForegroundColor = ProgramSetup.negative;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.Write(TextInitializer.specific_impulse + ": " + propolsion.specific_impulse + "s");

                Console.SetCursorPosition(posX, ++tempY);
                if (propolsion.burn_time > toCompare.burn_time)
                    Console.ForegroundColor = ProgramSetup.positive;
                else if (propolsion.burn_time < toCompare.burn_time)
                    Console.ForegroundColor = ProgramSetup.negative;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.Write(TextInitializer.burn_time + ": " + propolsion.burn_time + "s");
            }
            else
            {
                Console.Write(TextInitializer.capsule);

                Capsule capsule = drawn as Capsule;
                Capsule toCompare = compared as Capsule;

                Console.SetCursorPosition(posX, ++tempY);
                if (capsule.crew > toCompare.crew)
                    Console.ForegroundColor = ProgramSetup.positive;
                else if (capsule.crew < toCompare.crew)
                    Console.ForegroundColor = ProgramSetup.negative;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.Write(TextInitializer.crew + ": " + capsule.crew);

                Console.SetCursorPosition(posX, ++tempY);
                if (capsule.design_life > toCompare.design_life)
                    Console.ForegroundColor = ProgramSetup.positive;
                else if (capsule.design_life < toCompare.design_life)
                    Console.ForegroundColor = ProgramSetup.negative;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.Write(TextInitializer.design_life + ": " + capsule.design_life + "d");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
        }

        public static void drawCompareParts()
        {
            Console.Clear();

            Tuple<int, int> listPos1 = new Tuple<int, int>(10, 3);
            Tuple<int, int> listPos2 = new Tuple<int, int>(80, 3);

            bool running = true;

            SelectorArrow arrow1 = new SelectorArrow(listPos1, PartsList.allParts.Count, 1);
            SelectorArrow arrow2 = new SelectorArrow(listPos2, PartsList.allParts.Count, 1);

            while(running)
            {
                
            }

            printComparedPart(PartsList.allParts[1], PartsList.allParts[4], 10, 5);
            printComparedPart(PartsList.allParts[4], PartsList.allParts[1], 30, 5);

            Console.ReadKey();
        }
    }
}
