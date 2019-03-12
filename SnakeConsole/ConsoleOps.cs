using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeConsole
{
    
    class ConsoleOps
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        static bool visibile = false;

        public static void ShowConsole()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_SHOW);
            visibile = true;
        }

        public static void HideConsole()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            visibile = false;
        }

        public static void ShowVersions()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Version : {Application.ProductVersion}");
            Console.WriteLine($"Produced by : {Application.CompanyName}");
            Console.ResetColor();
        }
        public static void WriteToConsoleGreen(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (!visibile) ShowConsole();
            Console.WriteLine($" {x}       {y}");
            Console.ResetColor();
        }
        public static void ConsoleRead(string str)
        {
            if (str == "show colliders") GameWindow.ShowColliders();
        }
    }
}
