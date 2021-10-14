using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RocketAssembler.UtilityFuncs
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

        public static int menuCounter;

        public static void InitializeText(string lang)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(RocketAssembler.Program.directory + @"\Text.json"))
            {
                //RESET
                menuCounter = 0;
                areYouSure = "";
                disclaimer = "";
                menu = "";
                welcome = "";

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
