using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketAssembler.GraphicalFuncs;
using System.Threading;

namespace RocketAssembler
{
    class Program
    {
        public const string directory = @"E:\Repos\RocketAssembler\RocketAssembler";

        static void Main(string[] args)
        {
            bool running = true;

            FileLoader.LoadPresetGraphics();
            
            PresetGraphicDrawer.PresetGraphicDraw(0, ConsoleColor.Yellow);
            //Change time to 10000 after done
            Thread.Sleep(5000);
            Console.Clear();

            PresetGraphicDrawer.PresetGraphicDraw(1, ConsoleColor.Green);
            Thread.Sleep(4000);
            Console.Clear();

            while(running)
            {
                PresetGraphicDrawer.PresetGraphicDraw(2, ConsoleColor.Gray);
                //REMEMBER TO PUT CONTROLS AT THE BOTTOM
                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    //Build a rocket
                    case '1':
                        break;
                    //Rocket list
                    case '2':
                        break;
                    //Compare rockets
                    case '3':
                        break;
                    //Part list
                    case '4':
                        break;
                    //Compare parts
                    case '5':
                        break;
                    //Exit
                    case '6':
                        Console.Clear();
                        running = PresetGraphicDrawer.AreYouSureScreen();
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }
            
            Console.Clear();

            PresetGraphicDrawer.PresetGraphicDraw(3, ConsoleColor.Green);

            Console.ReadKey();
        }
    }
}
