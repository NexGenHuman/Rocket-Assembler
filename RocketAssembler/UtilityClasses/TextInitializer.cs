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
        public static string disclaimer;
        public static string menu;
        public static string welcome;

        //---ASCII ART---
        public static string goodbye;
        public static string logo;
        public static string title;

        //---DESCRIPTORS---
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

        //---CONTROLS---
        public static List<string> menuControls = new List<string>();

        public static int menuCounter;

        public static void InitializeText(string lang)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(RocketAssembler.Program.directory + @"\JsonFiles\Text.json"))
            {
                //RESET
                menuCounter = 0;
                areYouSure = "";
                disclaimer = "";
                menu = "";
                welcome = "";
                menuControls.Clear();

                string JSONtext = reader.ReadToEnd();
                JObject Jobj = JObject.Parse(JSONtext);

                foreach(var str in Jobj[lang]["are_you_sure"])
                {
                    areYouSure += str + "\n";
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

                type = Jobj[lang]["descriptors"]["type"] + "";
                name = Jobj[lang]["descriptors"]["name"] + "";
                empty_mass = Jobj[lang]["descriptors"]["empty_mass"] + "";
                fuel_mass = Jobj[lang]["descriptors"]["fuel_mass"] + "";
                thrust = Jobj[lang]["descriptors"]["thrust"] + "";
                specific_impulse = Jobj[lang]["descriptors"]["specific_impulse"] + "";
                burn_time = Jobj[lang]["descriptors"]["burn_time"] + "";
                crew = Jobj[lang]["descriptors"]["crew"] + "";
                design_life = Jobj[lang]["descriptors"]["design_life"] + "";
                solid_fuel_booster = Jobj[lang]["descriptors"]["solid_fuel_boosters"] + "";
                main_stage = Jobj[lang]["descriptors"]["main_stages"] + ""; ;
                orbital_stage = Jobj[lang]["descriptors"]["orbital_stages"] + ""; ;
                capsule = Jobj[lang]["descriptors"]["capsules"] + ""; ;

                reader.Close();
            }
        }

        public static void LoadASCIIart()
        {
            try
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(RocketAssembler.Program.directory + @"\GraphicalFuncs\ASCIIart\goodbye.txt"))
                {
                    goodbye = reader.ReadToEnd();
                    reader.Close();
                }
                using (System.IO.StreamReader reader = new System.IO.StreamReader(RocketAssembler.Program.directory + @"\GraphicalFuncs\ASCIIart\logo.txt"))
                {
                    logo = reader.ReadToEnd();
                    reader.Close();
                }
                using (System.IO.StreamReader reader = new System.IO.StreamReader(RocketAssembler.Program.directory + @"\GraphicalFuncs\ASCIIart\title.txt"))
                {
                    title = reader.ReadToEnd();
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
