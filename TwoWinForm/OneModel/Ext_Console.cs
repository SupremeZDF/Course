using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TwoWinForm.OneModel
{
    public class Ext_Console
    {
        static bool console_on = false;

        static Ext_Console() 
        {
            Show(true, "打印");
        }

        public static void Show(bool on, string title)
        {
            console_on = on;
            if (console_on)
            {
                AllocConsole();
                Console.Title = title;
                // use to change color
                Console.BackgroundColor = System.ConsoleColor.White;
                Console.ForegroundColor = System.ConsoleColor.Black;

            }
            else
            {
                FreeConsole();
            }
        }

        public static void Write(string output)
        {
            if (console_on)
            {
                Console.Write(output);
            }
        }

        public static void WriteLine(string output)
        {
            if (console_on)
            {
                Console.WriteLine(output);
            }
        }

        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

    }
}
