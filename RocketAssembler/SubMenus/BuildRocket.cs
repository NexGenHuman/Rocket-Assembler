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
    class BuildRocket
    {
        static List<Capsule> capsules = new List<Capsule>();
        static List<Orbital_Stage> orbital_stages = new List<Orbital_Stage>();
        static List<Main_Stage> main_stages = new List<Main_Stage>();
        static List<Solid_Fuel_Booster> solid_fuel_boosters = new List<Solid_Fuel_Booster>();

        static Capsule chosenC = null;
        static Orbital_Stage chosenOS = null;
        static Main_Stage chosenMS = null;
        static Solid_Fuel_Booster chosenSFB = null;

        static int partListPadding = 14;

        static string typeSeparator = "--------------------------------------";

        static Parts parts;

        static void loadParts()
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(RocketAssembler.Program.directory + @"\JsonFiles\Parts.json"))
            {
                string json = reader.ReadToEnd();
                parts = JsonConvert.DeserializeObject<Parts>(json);
            }

            capsules = parts.capsule;
            orbital_stages = parts.orbital_stage;
            main_stages = parts.main_stage;
            solid_fuel_boosters = parts.solid_fuel_booster;
            solid_fuel_boosters.Add(null);
        }

        static void writeSelection(string _type)
        {
            string header = "";
            string content = "";

            switch(_type)
            {
                case "capsule":
                    header += "(A)<< " + TextInitializer.capsule + " >>(D)\n";
                    header += typeSeparator;

                    foreach (Capsule c in capsules)
                        content += c.name + "\n";
                    break;
                case "orbital_stage":
                    header += "(A)<< " + TextInitializer.orbital_stage + " >>(D)\n";
                    header += typeSeparator;

                    foreach (Orbital_Stage os in orbital_stages)
                        content += os.name + "\n";
                    break;
                case "main_stage":
                    header += "(A)<< " + TextInitializer.main_stage + " >>(D)\n";
                    header += typeSeparator;

                    foreach (Main_Stage ms in main_stages)
                        content += ms.name + "\n";
                    break;
                case "sfb":
                    header += "(A)<< " + TextInitializer.solid_fuel_booster + " >>(D)\n";
                    header += typeSeparator;

                    foreach (Solid_Fuel_Booster sfb in solid_fuel_boosters)
                    {
                        if (sfb != null)
                            content += sfb.name + "\n";
                        else
                            content += TextInitializer.none + "\n";
                    }
                    break;
                default:
                    break;
            }

            Console.SetCursorPosition(0, 0);
            PresetGraphicDrawer.WriteCentered(header, typeSeparator.Length + 14, partListPadding);
            PresetGraphicDrawer.WritePaddedLeft(content, 14, 1);
        }

        static void clearSelection(string _type)
        {
            int lineCounter = 3;
            switch(_type)
            {
                case "capsule":
                    lineCounter += capsules.Count;
                    for(int i = 0; i < lineCounter; i++)
                    {
                        Console.SetCursorPosition(0, partListPadding + i);
                        for(int j = 0; j < typeSeparator.Length + 14; j++)
                        {
                            Console.Write(" ");
                        }
                    }
                    break;
                case "orbital_stage":
                    lineCounter += orbital_stages.Count;
                    for (int i = 0; i < lineCounter; i++)
                    {
                        Console.SetCursorPosition(0, partListPadding + i);
                        for (int j = 0; j < typeSeparator.Length + 14; j++)
                        {
                            Console.Write(" ");
                        }
                    }
                    break;
                case "main_stage":
                    lineCounter += main_stages.Count;
                    for (int i = 0; i < lineCounter; i++)
                    {
                        Console.SetCursorPosition(0, partListPadding + i);
                        for (int j = 0; j < typeSeparator.Length + 14; j++)
                        {
                            Console.Write(" ");
                        }
                    }
                    break;
                case "sfb":
                    lineCounter += solid_fuel_boosters.Count;
                    for (int i = 0; i < lineCounter; i++)
                    {
                        Console.SetCursorPosition(0, partListPadding + i);
                        for (int j = 0; j < typeSeparator.Length + 14; j++)
                        {
                            Console.Write(" ");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        static int getTypeLength(string _type)
        {
            switch (_type)
            {
                case "capsule":
                    return capsules.Count;
                case "orbital_stage":
                    return orbital_stages.Count;
                case "main_stage":
                    return main_stages.Count;
                case "sfb":
                    return solid_fuel_boosters.Count;
                default:
                    return 0;
            }
        }

        static public void writeBuildRocket()
        {
            Console.Clear();
            loadParts();
            string[] selections = new string[]
            {
                "capsule", "orbital_stage", "main_stage", "sfb"
            };

            bool capsule = false;
            bool orbital = false;
            bool main = false;
            bool sfb = false;

            Tuple<int, int> arrowStartPos = new Tuple<int, int>(10, 17);

            bool running = true;

            writeSelection("capsule");
            Console.SetCursorPosition(0, 0);

            SelectorArrow arrow = new SelectorArrow(arrowStartPos, capsules.Count, 1);

            PresetGraphicDrawer.DrawRocket(new Tuple<int, int>(84, 7), false, false, false, false);
            Console.SetCursorPosition(0, 0);

            int chosenPartType = 0;

            while (running)
            {
                bool decided = false;

                while(!decided)
                {
                    ConsoleKey choice = Console.ReadKey(true).Key;

                    switch(choice)
                    {
                        case ConsoleKey.Enter:
                            decided = true;
                            switch(chosenPartType)
                            {
                                case 0:
                                    chosenC = capsules[arrow.current];
                                    capsule = true;
                                    break;
                                case 1:
                                    chosenOS = orbital_stages[arrow.current];
                                    orbital = true;
                                    break;
                                case 2:
                                    chosenMS = main_stages[arrow.current];
                                    main = true;
                                    break;
                                case 3:
                                    chosenSFB = solid_fuel_boosters[arrow.current];
                                    if (chosenSFB == null)
                                        sfb = false;
                                    else
                                        sfb = true;
                                    break;
                                default:
                                    break;
                            }
                            PresetGraphicDrawer.DrawRocket(new Tuple<int, int>(84, 7), capsule, orbital, main, sfb);
                            Console.SetCursorPosition(0, 0);
                            break;

                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            decided = true;
                            clearSelection(selections[chosenPartType]);
                            chosenPartType--;
                            if (chosenPartType < 0)
                                chosenPartType = 3;
                            writeSelection(selections[chosenPartType]);
                            arrow = new SelectorArrow(arrowStartPos, getTypeLength(selections[chosenPartType]), 1);
                            break;

                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            decided = true;
                            clearSelection(selections[chosenPartType]);
                            chosenPartType++;
                            if (chosenPartType > 3)
                                chosenPartType = 0;
                            writeSelection(selections[chosenPartType]);
                            arrow = new SelectorArrow(arrowStartPos, getTypeLength(selections[chosenPartType]), 1);
                            break;

                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            arrow.moveArrow(true);
                            break;

                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            arrow.moveArrow(false);
                            break;

                        case ConsoleKey.Q:
                            return;
                        
                        case ConsoleKey.Spacebar:
                            if (chosenC != null && chosenOS != null && chosenMS != null)
                            {
                                RocketList.rockets.Add(new Rocket("Rocket" + RocketList.rockets.Count, chosenC, chosenOS, chosenMS, chosenSFB));
                                return;
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}
