using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketAssembler.UtilityClasses;
using Newtonsoft.Json;

namespace RocketAssembler
{
    static class ProgramSetup
    {
        public static string lang = "eng";

        public static void Initialize()
        {
            Program.directory = AppDomain.CurrentDomain.BaseDirectory;

            TextInitializer.InitializeText(lang);
            TextInitializer.LoadASCIIart();

            Console.CursorVisible = false;
            Console.WindowWidth = 120;
            Console.WindowHeight = 35;
        }
    }
}
