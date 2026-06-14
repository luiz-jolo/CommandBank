using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandBank.UI
{
    //desenha, borda, titulo e area da tela
    public class BaseRenderer
    {
        public void DrawMenu(int index)
        {
            Console.Clear();

            int width = Console.WindowWidth - 2;
            int height = Console.WindowHeight - 2;

            int startX = 0;
            int startY = 0;

            DrawBox(startX, startY, width, height);

            Console.SetCursorPosition(2, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" SubMenu ");
            Console.ResetColor();
            Console.Write($"index selecionado: {index}   ");

            //for (int i = 0; i < subOptions.Length; i++)
            //{
            //    int posX = 4;
            //    int posY = 3 + i;

            //    Console.SetCursorPosition(posX, posY);

            //    if (i == subSelectedIndex)
            //    {
            //        Console.BackgroundColor = ConsoleColor.White;
            //        Console.ForegroundColor = ConsoleColor.Black;
            //        Console.Write($"> {subOptions[i]}".PadRight(30));
            //    }
            //    else
            //    {
            //        Console.ForegroundColor = ConsoleColor.Gray;
            //        Console.Write($"  {subOptions[i]}");
            //    }

            //    Console.ResetColor();
            //}
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
