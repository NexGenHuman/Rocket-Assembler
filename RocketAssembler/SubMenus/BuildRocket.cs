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
        }

        static void writeSelection(string _type)
        {
            string header = "";
            string content = "";

            switch(_type)
            {
                case "capsule":
                    header += "(Q)<< " + TextInitializer.capsule + " >>(E)\n";
                    header += typeSeparator;

                    foreach (Capsule c in capsules)
                        content += c.name + "\n";
                    break;
                case "orbital_stage":
                    header += "(Q)<< " + TextInitializer.orbital_stage + " >>(E)\n";
                    header += typeSeparator;

                    foreach (Orbital_Stage os in orbital_stages)
                        content += os.name + "\n";
                    break;
                case "main_stage":
                    header += "(Q)<< " + TextInitializer.main_stage + " >>(E)\n";
                    header += typeSeparator;

                    foreach (Main_Stage ms in main_stages)
                        content += ms.name + "\n";
                    break;
                case "sfb":
                    header += "(Q)<< " + TextInitializer.solid_fuel_booster + " >>(E)\n";
                    header += typeSeparator;

                    foreach (Solid_Fuel_Booster sfb in solid_fuel_boosters)
                        content += sfb.name + "\n";
                    break;
                default:
                    break;
            }

            Console.SetCursorPosition(0, 0);
            PresetGraphicDrawer.WriteCentered(header, typeSeparator.Length + 14, 14);
            PresetGraphicDrawer.WritePaddedLeft(content, 14, 1);
        }

        static public void writeBuildRocket()
        {
            Console.Clear();
            loadParts();

            writeSelection("capsule");
            Console.SetCursorPosition(0, 0);
            PresetGraphicDrawer.DrawRocket(new Tuple<int, int>(84, 7), false, false, false, false);
            Console.SetCursorPosition(0, 0);
        }
    }
}
