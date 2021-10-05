using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketAssembler.GraphicalFuncs
{
    public static class PresetGraphicDrawer
    {
        const int margin = 10;
        const int minWidth = 12;

        static public string disclaimer;
        static public string welcome;
        static public string menu;
        static public string goodbye;
        static public string are_you_sure;


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
        static public void PresetGraphicDraw(int option, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            switch(option)
            {
                case 0:
                    WriteCentered(disclaimer, Console.WindowWidth, 10);
                    break;
                case 1:
                    WriteCentered(welcome, Console.WindowWidth, 10);
                    break;
                case 2:
                    WritePaddedLeft(menu, 15, 3);
                    break;
                case 3:
                    WriteCentered(goodbye, Console.WindowWidth, 5);
                    break;
                case 4:
                    WriteCentered(are_you_sure, Console.WindowWidth, 15);
                    break;
                default:
                    WriteCentered("Unavailable preset No." + option + " chosen.", Console.WindowWidth, 10);
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static public bool AreYouSureScreen()
        {
            while (true)
            {
                PresetGraphicDraw(4, ConsoleColor.DarkRed);
                char choice = Char.ToLower(Console.ReadKey().KeyChar);

                switch (choice)
                {
                    case 'y':
                        return false;
                    case 'n':
                        return true;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
