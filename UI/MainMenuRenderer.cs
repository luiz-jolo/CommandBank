using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandBank.UI
{
    public class MainMenuRenderer
    {
        public void DrawHomeMenu(List<string> options, int selectedIndex) {
            
            int width = 40;
            int height = options.Count + options.Count;

            int startX = (Console.WindowWidth - width) / 2;
            int startY = (Console.WindowHeight - height) / 2;

            DrawBox(startX, startY, width, height);
            Console.CursorVisible = false;
            Console.SetCursorPosition(startX + 2, startY);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Sharp - Bank ");
            Console.ResetColor();

            for (int i = 0; i < options.Count; i++)
            {
                int posX = startX + 2;
                int posY = startY + 2 + i;

                Console.SetCursorPosition(posX, posY);

                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"> {options[i]}".PadRight(width - 4));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"  {options[i]}");
                }

                Console.ResetColor();
            }
        }

        static void DrawBox(int x, int y, int width, int height)
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

    }
}
