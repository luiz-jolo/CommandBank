using System;

class Progam
{
    enum Screen
    {
        MainMenu,
        SubMenu
    }

    static Screen currentScreen = Screen.MainMenu;

    static int selectedIndex = 0;
    static int subSelectedIndex = 0;

    static string[] options = { "Iniciar", "Configurações", "Sair" };
    static string[] subOptions = { "Escrever", "Voltar" };

    static void Main()
    {
        Console.CursorVisible = false;

        while (true)
        {
            Render();

            var key = Console.ReadKey(true).Key;

            HandleInput(key);
        }
    }

    static void Render()
    {
        Console.Clear();

        switch (currentScreen)
        {
            case Screen.MainMenu:
                DrawMainMenu();
                break;

            case Screen.SubMenu:
                DrawSubMenu();
                break;
        }
    }

    static void HandleInput(ConsoleKey key)
    {
        if (currentScreen == Screen.MainMenu)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % options.Length;
                    break;

                case ConsoleKey.Enter:
                    if (selectedIndex == 0) // Iniciar
                    {
                        currentScreen = Screen.SubMenu;
                    }
                    break;
            }
        }
        else if (currentScreen == Screen.SubMenu)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    subSelectedIndex = (subSelectedIndex - 1 + subOptions.Length) % subOptions.Length;
                    break;

                case ConsoleKey.DownArrow:
                    subSelectedIndex = (subSelectedIndex + 1) % subOptions.Length;
                    break;

                case ConsoleKey.Enter:
                    ExecuteSubMenu();
                    break;
            }
        }
    }

    static void DrawMainMenu()
    {
        int width = 40;
        int height = options.Length + 4;

        int startX = (Console.WindowWidth - width) / 2;
        int startY = (Console.WindowHeight - height) / 2;

        DrawBox(startX, startY, width, height);

        Console.SetCursorPosition(startX + 2, startY);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(" Sharp - Bank ");
        Console.ResetColor();

        for (int i = 0; i < options.Length; i++)
        {
            int posX = startX + 2;
            int posY = startY + 2 + i;

            Console.SetCursorPosition(posX, posY);

            if (i == selectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.White;
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

    static void DrawSubMenu()
    {
        int width = Console.WindowWidth - 2;
        int height = Console.WindowHeight - 2;

        int startX = 0;
        int startY = 0;

        DrawBox(startX, startY, width, height);

        Console.SetCursorPosition(2, 0);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(" INICIAR ");
        Console.ResetColor();

        for (int i = 0; i < subOptions.Length; i++)
        {
            int posX = 4;
            int posY = 3 + i;

            Console.SetCursorPosition(posX, posY);

            if (i == subSelectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"> {subOptions[i]}".PadRight(30));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"  {subOptions[i]}");
            }

            Console.ResetColor();
        }
    }

    static void ExecuteSubMenu()
    {
        if (subSelectedIndex == 0) // Escrever
        {
            Console.Clear();

            DrawBox(0, 0, Console.WindowWidth - 2, Console.WindowHeight - 2);

            Console.SetCursorPosition(4, 4);
            Console.Write("Executando ação...");

            Console.SetCursorPosition(4, 6);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Texto exemplo sendo exibido no console.");
            Console.ResetColor();

            Console.SetCursorPosition(4, 8);
            Console.Write("Pressione qualquer tecla para voltar...");
            Console.ReadKey(true);
        }
        else if (subSelectedIndex == 1) // Voltar
        {
            currentScreen = Screen.MainMenu;
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
