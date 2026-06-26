using CommandBank.Domain.Enum;

namespace CommandBank.UI
{
    //desenha, borda, titulo e area da tela
    public class BaseRenderer
    {
        public void DrawLayoutScreen(ScreenEnum screen)
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
            Console.Write($"index selecionado: {screen}   ");

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
