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

            switch (_type)
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
            switch (_type)
            {
                case "capsule":
                    lineCounter += capsules.Count;
                    for (int i = 0; i < lineCounter; i++)
                    {
                        Console.SetCursorPosition(0, partListPadding + i);
                        for (int j = 0; j < typeSeparator.Length + 14; j++)
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
            Rocket rocketToReturn = new Rocket("New Rocket " + RocketList.rockets.Count, null, null, null, null);

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

            int prevWidth = 0, prevHeight = 0;
            int prevWidthPart = 0, prevHeightPart = 0;

            Tuple<int, int> rocketListPos = new Tuple<int, int>(50, 2);
            Tuple<int, int> partPos = new Tuple<int, int>(13, 4);

            PresetGraphicDrawer.WritePaddedLeft(PartsList.partDescription(capsules[0]), partPos.Item1, partPos.Item2);
            Console.SetCursorPosition(0, 0);

            PresetGraphicDrawer.WriteControls(TextInitializer.buildRocketControls);

            while (running)
            {
                bool decided = false;

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

                string toWrite = RocketList.writeAllParts(rocketToReturn);

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
                PresetGraphicDrawer.WritePaddedLeft(toWrite, rocketListPos.Item1, rocketListPos.Item2);

                while (!decided)
                {
                    ConsoleKey choice = Console.ReadKey(true).Key;

                    switch (choice)
                    {
                        case ConsoleKey.Enter:
                            decided = true;
                            switch (chosenPartType)
                            {
                                case 0:
                                    rocketToReturn.capsule = capsules[arrow.current];
                                    capsule = true;
                                    break;
                                case 1:
                                    rocketToReturn.orbital_stage = orbital_stages[arrow.current];
                                    orbital = true;
                                    break;
                                case 2:
                                    rocketToReturn.main_stage = main_stages[arrow.current];
                                    main = true;
                                    break;
                                case 3:
                                    rocketToReturn.solid_fuel_booster = solid_fuel_boosters[arrow.current];
                                    if (rocketToReturn.solid_fuel_booster == null)
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
                            if (capsule && orbital && main)
                            {
                                rocketToReturn.name = PresetGraphicDrawer.getRocketName();
                                RocketList.rockets.Add(rocketToReturn);
                                return;
                            }
                            break;

                        default:
                            break;
                    }

                    //Part description

                    Console.SetCursorPosition(partPos.Item1, partPos.Item2);
                    for (int i = 0; i < prevHeightPart; i++)
                    {
                        for (int j = 0; j < prevWidthPart; j++)
                        {
                            Console.Write(" ");
                        }
                        Console.SetCursorPosition(partPos.Item1, partPos.Item2 + i);
                    }

                    prevHeightPart = 1;
                    prevWidthPart = 0;

                    Console.SetCursorPosition(0, 0);

                    string toWritePart = "";

                    switch (chosenPartType)
                    {
                        case 0:
                            toWritePart = PartsList.partDescription(capsules[arrow.current]);
                            break;
                        case 1:
                            toWritePart = PartsList.partDescription(orbital_stages[arrow.current]);
                            break;
                        case 2:
                            toWritePart = PartsList.partDescription(main_stages[arrow.current]);
                            break;
                        case 3:
                            if (solid_fuel_boosters[arrow.current] != null)
                                toWritePart = PartsList.partDescription(solid_fuel_boosters[arrow.current]);
                            break;
                        default:
                            break;
                    }

                    int tempCounterPart = 0;

                    foreach (char ch in toWritePart)
                    {
                        if (ch != '\n')
                            tempCounterPart++;
                        else
                        {
                            prevHeightPart++;
                            if (tempCounterPart > prevWidthPart)
                                prevWidthPart = tempCounterPart;
                            tempCounterPart = 0;
                        }
                    }
                    prevHeightPart++;

                    if (tempCounterPart > prevWidthPart)
                        prevWidthPart = tempCounterPart;


                    PresetGraphicDrawer.WritePaddedLeft(toWritePart, partPos.Item1, partPos.Item2);
                }
            }
        }
    }
}
