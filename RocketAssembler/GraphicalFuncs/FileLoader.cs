using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketAssembler.GraphicalFuncs
{
    static public class FileLoader
    {
        static public void LoadPresetGraphics()
        {
            try
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(RocketAssembler.Program.directory + @"\GraphicalFuncs\Graphics\disclaimer.txt"))
                {
                    PresetGraphicDrawer.disclaimer = reader.ReadToEnd();
                    reader.Close();
                }

                using (System.IO.StreamReader reader = new System.IO.StreamReader(RocketAssembler.Program.directory + @"\GraphicalFuncs\Graphics\welcome.txt"))
                {
                    PresetGraphicDrawer.welcome = reader.ReadToEnd();
                    reader.Close();
                }

                using (System.IO.StreamReader reader = new System.IO.StreamReader(RocketAssembler.Program.directory + @"\GraphicalFuncs\Graphics\menu.txt"))
                {
                    PresetGraphicDrawer.menu = reader.ReadToEnd();
                    reader.Close();
                }

                using (System.IO.StreamReader reader = new System.IO.StreamReader(RocketAssembler.Program.directory + @"\GraphicalFuncs\Graphics\goodbye.txt"))
                {
                    PresetGraphicDrawer.goodbye = reader.ReadToEnd();
                    reader.Close();
                }

                using (System.IO.StreamReader reader = new System.IO.StreamReader(RocketAssembler.Program.directory + @"\GraphicalFuncs\Graphics\are_you_sure.txt"))
                {
                    PresetGraphicDrawer.are_you_sure = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
