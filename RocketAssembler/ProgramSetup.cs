using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketAssembler.UtilityFuncs;

namespace RocketAssembler
{
    static class ProgramSetup
    {
        public static string lang = "eng";

        public static void Initialize()
        {
            TextInitializer.InitializeText(lang);
            TextInitializer.LoadASCIIart();

            Console.CursorVisible = false;
        }
    }
}
