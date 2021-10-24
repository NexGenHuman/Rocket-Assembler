using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketAssembler.UtilityClasses;
using RocketAssembler.SubMenus;

namespace RocketAssembler.GraphicalFuncs
{
    public static class PresetGraphicDrawer
    {
        const int margin = 10;
        const int minWidth = 12;

        const int menuPosX = 15;
        const int menuPosY = 6;

        static string[] TextDivider(int width, string original)
        {
            List<string> dividedText = new List<string>();
            if (width < minWidth)
                width = minWidth;
            width -= margin + 1;
            
            while (original != "")
            {
                if(width > original.Length)
                {
                    width = original.Length;
                }
                int i = original.Substring(0, width - 1).LastIndexOf(' ');
                int j = original.Substring(0, width - 1).IndexOf('\n');
                int k = j;

                if (k == -1)
                    k = i;
                if (k == -1 || (k < width && j == -1))
                    k = width;

                dividedText.Add(original.Substring(0, k));
                original = original.Remove(0, k);
                if (original != "" && (original[0] == '\n' || original[0] == ' '))
                    original = original.Remove(0, 1);
            }

            return dividedText.ToArray<string>();
        }

        static public void WriteCentered(string text, int width, int paddingTop)
        {
            for (int i = 0; paddingTop > i; i++)
                Console.WriteLine();

            foreach (string s in TextDivider(width, text))
            {
                int vert = Console.CursorTop;
                Console.SetCursorPosition((width - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
            }
        }

        static public void WritePaddedLeft(string text, int padding, int paddingTop)
        {
            for (int i = 0; paddingTop > i; i++)
                Console.WriteLine();

            foreach (string s in TextDivider(Console.BufferWidth - padding, text))
            {
                int vert = Console.CursorTop;
                Console.SetCursorPosition(padding, Console.CursorTop);
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// This method draws one of availeable preset graphics
        /// </summary>
        /// <param name="option">An int value indicating which preset is chosen. 0 is disclaimer, 1 is welcome, 2 is menu and 3 is goodbye</param>
        /// <param name="color">Text colour</param>
        static public void PresetGraphicDraw(string option, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            switch(option)
            {
                case "disclaimer":
                    WriteCentered(TextInitializer.disclaimer, Console.WindowWidth, 10);
                    break;
                case "welcome":
                    WriteCentered(TextInitializer.title, Console.WindowWidth, 7);
                    WriteCentered(TextInitializer.welcome, Console.WindowWidth, 2);
                    break;
                case "menu":
                    WritePaddedLeft(TextInitializer.menu, menuPosX, menuPosY);
                    Console.SetCursorPosition(0, 0);
                    WritePaddedLeft(TextInitializer.logo, 50, 4);
                    break;
                case "goodbye":
                    WriteCentered(TextInitializer.goodbye, Console.WindowWidth, 5);
                    break;
                case "areYouSure":
                    WriteCentered(TextInitializer.areYouSure, Console.WindowWidth, 15);
                    break;
                case "partsList":
                    string temp = "";
                    foreach (var part in PartsList.allParts)
                    {
                        temp += part.name + "\n";
                    }

                    WritePaddedLeft(temp, menuPosX, menuPosY);
                    break;
                case "rocketBuild":
                    BuildRocket.writeBuildRocket();
                    Console.ReadKey();
                    break;
                default:
                    WriteCentered("Unavailable preset " + option + " chosen.", Console.WindowWidth, 10);
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static public bool AreYouSureScreen()
        {
            while (true)
            {
                PresetGraphicDraw("areYouSure", ConsoleColor.DarkRed);

                bool decided = false;

                while (!decided)
                {

                    char choice = Char.ToLower(Console.ReadKey(true).KeyChar);

                    switch (choice)
                    {
                        case 'y':
                            decided = true;
                            return false;
                        case 'n':
                            decided = true;
                            return true;
                        default:
                            break;
                    }
                }
            }
        }

        static public void WriteControls(List<string> controls)
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("▒");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.WindowHeight - 1);

            int controlsLength = 0;
            foreach (string s in controls)
                controlsLength += s.Length;

            int spacing = (Console.WindowWidth - controlsLength) / (controls.Count + 1);

            foreach(string control in controls)
            {
                Console.SetCursorPosition(Console.CursorLeft + spacing, Console.WindowHeight - 1);
                Console.Write(control);
            }

            Console.SetCursorPosition(0, 0);
        }

        static int getOffset(int space, int content)
        {
            return (space - content) / 2;
        }

        static public void DrawRocket(Tuple<int, int> position, bool capsule, bool orbital, bool main, bool sfb)
        {
            Console.SetCursorPosition(0, 0);
            WritePaddedLeft(TextInitializer.separator, position.Item1, position.Item2);
            Console.SetCursorPosition(0, 0);
            WritePaddedLeft(TextInitializer.capsule.ToUpper(), position.Item1 + getOffset(TextInitializer.separator.Length, TextInitializer.capsule.Length), position.Item2);

            if (capsule)
                Console.ForegroundColor = ProgramSetup.positive;
            else
                Console.ForegroundColor = ProgramSetup.negative;

            Console.SetCursorPosition(0, 0);
            WritePaddedLeft(TextInitializer.capsuleASCII, position.Item1 + 9, position.Item2 + 1);
            Console.ForegroundColor = ConsoleColor.White;


            Console.SetCursorPosition(0, 0);
            WritePaddedLeft(TextInitializer.separator, position.Item1, position.Item2 + 3);
            Console.SetCursorPosition(0, 0);
            WritePaddedLeft(TextInitializer.orbital_stage.ToUpper(), position.Item1 + getOffset(TextInitializer.separator.Length, TextInitializer.orbital_stage.Length), position.Item2 + 3);

            if (orbital)
                Console.ForegroundColor = ProgramSetup.positive;
            else
                Console.ForegroundColor = ProgramSetup.negative;

            Console.SetCursorPosition(0, 0);
            WritePaddedLeft(TextInitializer.orbital_stageASCII, position.Item1 + 8, position.Item2 + 4);
            Console.ForegroundColor = ConsoleColor.White;


            if (sfb)
                Console.ForegroundColor = ProgramSetup.positive;
            else
                Console.ForegroundColor = ProgramSetup.optional;

            Console.SetCursorPosition(0, 0);
            WritePaddedLeft(TextInitializer.solid_fuel_boosterASCII, position.Item1 + 5, position.Item2 + 9);
            Console.ForegroundColor = ConsoleColor.White;


            Console.SetCursorPosition(0, 0);
            WritePaddedLeft(TextInitializer.separator, position.Item1, position.Item2 + 7);
            Console.SetCursorPosition(0, 0);
            WritePaddedLeft(TextInitializer.main_stage.ToUpper(), position.Item1 + getOffset(TextInitializer.separator.Length, TextInitializer.main_stage.Length), position.Item2 + 7);
            if (main)
                Console.ForegroundColor = ProgramSetup.positive;
            else
                Console.ForegroundColor = ProgramSetup.negative;
            Console.SetCursorPosition(0, 0);
            WritePaddedLeft(TextInitializer.main_stageASCII, position.Item1 + 8, position.Item2 + 8);
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, 0);
            WritePaddedLeft("▲\n|", position.Item1 + 5, position.Item2 + 17);
            Console.SetCursorPosition(0, 0);
            WritePaddedLeft("▲\n|", position.Item1 + 16, position.Item2 + 17);

            Console.SetCursorPosition(0, 0);
            WritePaddedLeft(TextInitializer.solid_fuel_booster.ToUpper(), position.Item1 + getOffset(TextInitializer.separator.Length, TextInitializer.solid_fuel_booster.Length), position.Item2 + 19);
            WritePaddedLeft("("+TextInitializer.optional.ToUpper()+")", position.Item1 + getOffset(TextInitializer.separator.Length, TextInitializer.optional.Length+2), 0);
        }
    }
}
