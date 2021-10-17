using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketAssembler.UtilityClasses;
using RocketAssembler.GraphicalFuncs;
using Newtonsoft.Json;

namespace RocketAssembler.SubMenus
{
    static class PartsList
    {
        static Parts parts;

        static public List<Part> allParts = new List<Part>();

        static public void loadParts()
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(RocketAssembler.Program.directory + @"\JsonFiles\Parts.json"))
            {
                string json = reader.ReadToEnd();
                parts = JsonConvert.DeserializeObject<Parts>(json);
            }

            foreach (Capsule part in parts.capsule)
                allParts.Add(part);
            foreach (Main_Stage part in parts.main_stage)
                allParts.Add(part);
            foreach (Orbital_Stage part in parts.orbital_stage)
                allParts.Add(part);
            foreach (Solid_Fuel_Booster part in parts.solid_fuel_booster)
                allParts.Add(part);
        }

        static string partDescription(Part part)
        {
            string returnString = TextInitializer.name + ": " + part.name + "\n" + TextInitializer.type + ": ";

            if(part is Propolsion)
            {
                if (part is Solid_Fuel_Booster)
                    returnString += TextInitializer.solid_fuel_booster + "\n";
                else if (part is Main_Stage)
                    returnString += TextInitializer.main_stage + "\n";
                else
                    returnString += TextInitializer.orbital_stage + "\n";

                Propolsion propolsion = part as Propolsion;
                returnString += TextInitializer.empty_mass + ": " + propolsion.empty_mass + "t\n";
                returnString += TextInitializer.fuel_mass + ": " + propolsion.fuel_mass + "t\n";
                returnString += TextInitializer.thrust + ": " + propolsion.thrust + "kN\n";
                returnString += TextInitializer.specific_impulse + ": " + propolsion.specific_impulse + "s\n";
                returnString += TextInitializer.burn_time + ": " + propolsion.burn_time + "s";
            }
            else
            {
                returnString += TextInitializer.capsule + "\n";
                Capsule capsule = part as Capsule;
                returnString += TextInitializer.crew + ": " + capsule.crew + "\n";
                returnString += TextInitializer.design_life + ": " + capsule.design_life + "d\n";
            }

            return returnString;
        }

        static public void DrawPartsList()
        {
            Console.Clear();

            bool running = true;

            SelectorArrow arrow = new SelectorArrow(new Tuple<int, int>(11, 6), allParts.Count, 1);
            Console.SetCursorPosition(0, 0);
            PresetGraphicDrawer.PresetGraphicDraw("partsList", ConsoleColor.Gray);
            Console.SetCursorPosition(0, 0);
            if (allParts.Count != 0)
                PresetGraphicDrawer.WritePaddedLeft(partDescription(allParts[0]), 30, 6);
            Console.SetCursorPosition(0, 0);

            int prevCursorPos = 0;

            while (running)
            {
                ConsoleKey choice = Console.ReadKey(true).Key;

                if(prevCursorPos != arrow.current)
                {

                    Console.SetCursorPosition(0, 0);
                }

                switch (choice)
                {
                    //-------------------------------Move the arrow up
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        prevCursorPos = arrow.current;
                        arrow.moveArrow(false);
                        break;

                    //-------------------------------Move the arrow down
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        prevCursorPos = arrow.current;
                        arrow.moveArrow(true);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
