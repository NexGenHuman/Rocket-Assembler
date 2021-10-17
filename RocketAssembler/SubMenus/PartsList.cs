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
            Console.Write(TextInitializer.type + ": ");

            if(part is Propolsion)
            {
                if(part is Solid_Fuel_Booster)
                    Console.
            }
            else
            {

            }
        }

        static public void DrawPartsList()
        {
            Console.Clear();

            bool running = true;

            SelectorArrow arrow = new SelectorArrow(new Tuple<int, int>(11, 6), allParts.Count, 1);
            Console.SetCursorPosition(0, 0);
            PresetGraphicDrawer.PresetGraphicDraw("partsList", ConsoleColor.Gray);
            Console.SetCursorPosition(0, 0);
            PresetGraphicDrawer.WritePaddedLeft(, 30, 6)
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
