﻿using System;
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
                PresetGraphicDrawer.WriteControls(TextInitializer.menuControls);
                //REMEMBER TO PUT CONTROLS AT THE BOTTOM

                SelectorArrow arrow = new SelectorArrow(new Tuple<int, int>(11, 9), TextInitializer.menuCounter, 2);

                bool decided = false;

                bool usedEnter = false;

                while (!decided)
                {
                    ConsoleKey choice;

                    if(!usedEnter)
                    {
                        choice = Console.ReadKey(true).Key;
                    }
                    else
                    {
                        Enum.TryParse<ConsoleKey>("D" + (arrow.current + 1) , out choice);
                        usedEnter = false;
                    }

                    switch (choice)
                    {
                        //-------------------------------Build a rocket
                        case ConsoleKey.D1:
                            decided = true;
                            break;

                        //-------------------------------Rocket list
                        case ConsoleKey.D2:
                            decided = true;
                            break;

                        //-------------------------------Compare rockets
                        case ConsoleKey.D3:
                            decided = true;
                            break;

                        //-------------------------------Part list
                        case ConsoleKey.D4:
                            decided = true;
                            break;

                        //-------------------------------Compare parts
                        case ConsoleKey.D5:
                            decided = true;
                            break;

                        //-------------------------------Change language
                        case ConsoleKey.D6:
                            decided = true;
                            //TEMP
                            if (ProgramSetup.lang == "eng")
                                ProgramSetup.lang = "pl";
                            else
                                ProgramSetup.lang = "eng";

                            TextInitializer.InitializeText(ProgramSetup.lang);
                            Console.Clear();
                            break;

                        //-------------------------------Exit
                        case ConsoleKey.D7:
                            decided = true;
                            Console.Clear();
                            running = PresetGraphicDrawer.AreYouSureScreen();
                            break;

                        //-------------------------------Move the arrow up
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            arrow.moveArrow(false);
                            break;

                        //-------------------------------Move the arrow down
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            arrow.moveArrow(true);
                            break;

                        //-------------------------------Select on arrow
                        case ConsoleKey.Enter:
                            usedEnter = true;
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
