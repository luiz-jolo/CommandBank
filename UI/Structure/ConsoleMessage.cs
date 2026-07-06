using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandBank.UI.Structure
{
    public class ConsoleMessage
    {
        public static void ShowError(string message)
        {
            Console.SetCursorPosition(4, Console.WindowHeight - 4);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message.PadRight(Console.WindowWidth - 6));
            Console.ResetColor();
        }

        public static void ShowSuccess(string message)
        {
            Console.SetCursorPosition(4, Console.WindowHeight - 4);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message.PadRight(Console.WindowWidth - 6));
            Console.ResetColor();
        }
    }
}
