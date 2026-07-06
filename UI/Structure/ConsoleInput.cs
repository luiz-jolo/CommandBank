using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandBank.UI.Structure
{
    internal class ConsoleInput
    {
        public static string ReadInput(int x, int y, bool isPassword = false)
        {
            Console.SetCursorPosition(x, y);

            string input = "";

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                    break;

                if (key.Key == ConsoleKey.Escape)
                    return "__ESC__";

                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input[..^1];

                    Console.SetCursorPosition(x + input.Length, y);
                    Console.Write(" ");
                    Console.SetCursorPosition(x + input.Length, y);
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    input += key.KeyChar;

                    Console.SetCursorPosition(x + input.Length - 1, y);
                    Console.Write(isPassword ? "*" : key.KeyChar);
                }
            }

            return input;
        }

    }
}
