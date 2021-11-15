using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RocketAssembler.UtilityClasses
{
    static class TextInitializer
    {
        //---TEXT---
        public static string areYouSure;
        public static string areYouSureAlt;
        public static string disclaimer;
        public static string menu;
        public static string welcome;

        //---ASCII ART---
        public static string goodbye;
        public static string logo;
        public static string title;
        public static string capsuleASCII;
        public static string orbital_stageASCII;
        public static string main_stageASCII;
        public static string solid_fuel_boosterASCII;
        public static string separator;

        //---WORDS---
        public static string type;
        public static string name;
        public static string empty_mass;
        public static string fuel_mass;
        public static string thrust;
        public static string specific_impulse;
        public static string burn_time;
        public static string crew;
        public static string design_life;
        public static string solid_fuel_booster;
        public static string main_stage;
        public static string orbital_stage;
        public static string capsule;
        public static string optional;
        public static string none;
        public static string enter_rocket_name;
        public static string different_types;

        //---CONTROLS---
        public static List<string> menuControls = new List<string>();
        public static List<string> partsListControls = new List<string>();
        public static List<string> buildRocketControls = new List<string>();
        public static List<string> rocketListControls = new List<string>();
        public static List<string> rocketCompareControls = new List<string>();
        public static List<string> partCompareControls = new List<string>();

        public static int menuCounter;

        public static void InitializeText(string lang)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(Program.directory + @"\JsonFiles\Text.json"))
            {
                //RESET
                menuCounter = 0;
                areYouSure = "";
                areYouSureAlt = "";
                disclaimer = "";
                menu = "";
                welcome = "";
                menuControls.Clear();
                partsListControls.Clear();
                buildRocketControls.Clear();
                rocketListControls.Clear();
                rocketCompareControls.Clear();
                partCompareControls.Clear();

                string JSONtext = reader.ReadToEnd();
                JObject Jobj = JObject.Parse(JSONtext);

                foreach(var str in Jobj[lang]["are_you_sure"])
                {
                    areYouSure += str + "\n";
                }
                foreach (var str in Jobj[lang]["are_you_sure_alt"])
                {
                    areYouSureAlt += str + "\n";
                }
                foreach (var str in Jobj[lang]["disclaimer"])
                {
                    disclaimer += str + "\n";
                }

                //Menu build
                menu += "|===========================|\n\n----\n";
                foreach (var str in Jobj[lang]["menu"])
                {
                    menuCounter++;
                    menu += menuCounter + ". " + str + "\n----\n";
                }
                menu += "\n|===========================|";

                foreach (var str in Jobj[lang]["welcome"])
                {
                    welcome += str + "\n";
                }

                foreach (var str in Jobj[lang]["menu_controls"])
                {
                    menuControls.Add(str + "");
                }

                foreach (var str in Jobj[lang]["parts_list_controls"])
                {
                    partsListControls.Add(str + "");
                }

                foreach (var str in Jobj[lang]["build_rocket_controls"])
                {
                    buildRocketControls.Add(str + "");
                }

                foreach (var str in Jobj[lang]["rocket_list_controls"])
                {
                    rocketListControls.Add(str + "");
                }

                foreach (var str in Jobj[lang]["rockets_compare_controls"])
                {
                    rocketCompareControls.Add(str + "");
                }

                foreach (var str in Jobj[lang]["parts_compare_controls"])
                {
                    partCompareControls.Add(str + "");
                }

                type = Jobj[lang]["descriptors"]["type"] + "";
                name = Jobj[lang]["descriptors"]["name"] + "";
                empty_mass = Jobj[lang]["descriptors"]["empty_mass"] + "";
                fuel_mass = Jobj[lang]["descriptors"]["fuel_mass"] + "";
                thrust = Jobj[lang]["descriptors"]["thrust"] + "";
                specific_impulse = Jobj[lang]["descriptors"]["specific_impulse"] + "";
                burn_time = Jobj[lang]["descriptors"]["burn_time"] + "";
                crew = Jobj[lang]["descriptors"]["crew"] + "";
                design_life = Jobj[lang]["descriptors"]["design_life"] + "";
                solid_fuel_booster = Jobj[lang]["descriptors"]["solid_fuel_booster"] + "";
                main_stage = Jobj[lang]["descriptors"]["main_stage"] + "";
                orbital_stage = Jobj[lang]["descriptors"]["orbital_stage"] + "";
                capsule = Jobj[lang]["descriptors"]["capsule"] + "";
                optional = Jobj[lang]["descriptors"]["optional"] + "";
                none = Jobj[lang]["descriptors"]["none"] + "";
                enter_rocket_name = Jobj[lang]["descriptors"]["enter_rocket_name"] + "";
                different_types = Jobj[lang]["descriptors"]["different_types"] + "";

                reader.Close();
            }
        }

        public static void LoadASCIIart()
        {
            try
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(Program.directory + @"\GraphicalFuncs\ASCIIart\goodbye.txt"))
                {
                    goodbye = reader.ReadToEnd();
                    reader.Close();
                }
                using (System.IO.StreamReader reader = new System.IO.StreamReader(Program.directory + @"\GraphicalFuncs\ASCIIart\logo.txt"))
                {
                    logo = reader.ReadToEnd();
                    reader.Close();
                }
                using (System.IO.StreamReader reader = new System.IO.StreamReader(Program.directory + @"\GraphicalFuncs\ASCIIart\title.txt"))
                {
                    title = reader.ReadToEnd();
                    reader.Close();
                }
                using (System.IO.StreamReader reader = new System.IO.StreamReader(Program.directory + @"\GraphicalFuncs\ASCIIart\capsule.txt"))
                {
                    capsuleASCII = reader.ReadToEnd();
                    reader.Close();
                }
                using (System.IO.StreamReader reader = new System.IO.StreamReader(Program.directory + @"\GraphicalFuncs\ASCIIart\orbital_stage.txt"))
                {
                    orbital_stageASCII = reader.ReadToEnd();
                    reader.Close();
                }
                using (System.IO.StreamReader reader = new System.IO.StreamReader(Program.directory + @"\GraphicalFuncs\ASCIIart\main_stage.txt"))
                {
                    main_stageASCII = reader.ReadToEnd();
                    reader.Close();
                }
                using (System.IO.StreamReader reader = new System.IO.StreamReader(Program.directory + @"\GraphicalFuncs\ASCIIart\solid_fuel_booster.txt"))
                {
                    solid_fuel_boosterASCII = reader.ReadToEnd();
                    reader.Close();
                }
                using (System.IO.StreamReader reader = new System.IO.StreamReader(Program.directory + @"\GraphicalFuncs\ASCIIart\separator.txt"))
                {
                    separator = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
