using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandBank.UI.Structure
{
    internal class ConsoleLayout
    {
        public static void DrawBox(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("┌" + new string('─', width - 2) + "┐");

            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write("│" + new string(' ', width - 2) + "│");
            }

            Console.SetCursorPosition(x, y + height - 1);
            Console.Write("└" + new string('─', width - 2) + "┘");
        }

        //ADICIONAR
        //DrawTitle()
        //ClearContentArea()
    }
}
