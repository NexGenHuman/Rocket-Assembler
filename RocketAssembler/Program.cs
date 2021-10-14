using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketAssembler.GraphicalFuncs;
using System.Threading;
using RocketAssembler.UtilityFuncs;

namespace RocketAssembler
{
    class Program
    {
        public const string directory = @"E:\Repos\RocketAssembler\RocketAssembler";

        static void Main(string[] args)
        {
            bool running = true;

            ProgramSetup.Initialize();
            
            PresetGraphicDrawer.PresetGraphicDraw(0, ConsoleColor.Yellow);
            //Change time to 10000 after done
            Thread.Sleep(1000);
            Console.Clear();

            PresetGraphicDrawer.PresetGraphicDraw(1, ConsoleColor.Green);
            Thread.Sleep(1000);
            Console.Clear();

            while(running)
            {
                PresetGraphicDrawer.PresetGraphicDraw(2, ConsoleColor.Gray);
                //REMEMBER TO PUT CONTROLS AT THE BOTTOM

                bool decided = false;

                while (!decided)
                {
                    char choice = Console.ReadKey(true).KeyChar;

                    switch (choice)
                    {
                        //Build a rocket
                        case '1':
                            decided = true;
                            break;
                        //Rocket list
                        case '2':
                            decided = true;
                            break;
                        //Compare rockets
                        case '3':
                            decided = true;
                            break;
                        //Part list
                        case '4':
                            decided = true;
                            break;
                        //Compare parts
                        case '5':
                            decided = true;
                            break;
                        //Change language
                        case '6':
                            decided = true;
                            //TEMP
                            if (ProgramSetup.lang == "eng")
                                ProgramSetup.lang = "pl";
                            else
                                ProgramSetup.lang = "eng";

                            TextInitializer.InitializeText(ProgramSetup.lang);
                            Console.Clear();
                            break;
                        //Exit
                        case '7':
                            decided = true;
                            Console.Clear();
                            running = PresetGraphicDrawer.AreYouSureScreen();
                            break;
                        default:
                            break;
                    }
                }

                Console.Clear();
            }
            
            Console.Clear();

            PresetGraphicDrawer.PresetGraphicDraw(3, ConsoleColor.Green);

            Console.ReadKey();
        }
    }
}
