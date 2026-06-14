using CommandBank.Core;
using CommandBank.Domain.Enum;
using CommandBank.StateMachine;
using CommandBank.UI;
using System;

class Progam
{
    
    static void Main(string[] args)
    {
        //criando as telas em uma lista de string
        List<string> options = Enum.GetNames(typeof(ScreenEnum)).ToList();

        MenuController controller = new MenuController(options, 0);
        
        MainMenuRenderer mainMenuRender = new MainMenuRenderer();

        var State = new StateModel(); 
        State.CurrentIndex = 0;

        while(State.CurrentIndex == 0)
        {
            mainMenuRender.DrawHomeMenu(controller.options, controller.selectedIndex);

            var key = Console.ReadKey(true).Key;
            var selectedIndex = controller.RetornaIndexSelecionado(key);
            Console.Write($"index :: {selectedIndex}   ");
            if(key == ConsoleKey.Enter)
            {
                State.CurrentIndex = selectedIndex;
                var b = new BaseRenderer();
                b.DrawMenu(selectedIndex);
            }


            //controller.HandleInput(key);
        }

        //while (State.CurrentStateIndex == 0)
        //{
        //    mainMenuRender.DrawHomeMenu(controller.options , controller.selectedIndex);
        //    var key = Console.ReadKey(true).Key;
        //    controller.HandleInput(key);
        //}


        //controller.ReadInput();
    }

    //static ScreenEnum currentScreen = ScreenEnum.MainMenu;

    //static int selectedIndex = 0;
    //static int subSelectedIndex = 0;

    //static string[] options = { "Login", "Configurações", "Sair" };
    //static string[] subOptions = { "Escrever", "Voltar" };

    //static void Main()
    //{
    //    Console.CursorVisible = false;

    //    while (true)
    //    {
    //        Render();

    //        var key = Console.ReadKey(true).Key;

    //        HandleInput(key);
    //    }
    //}

    //static void Render()
    //{
    //    Console.Clear();

    //    switch (currentScreen)
    //    {
    //        case ScreenEnum.MainMenu:
    //            DrawMainMenu();
    //            break;

    //        case ScreenEnum.SubMenu:
    //            DrawSubMenu();
    //            break;
    //    }
    //}

    //static void HandleInput(ConsoleKey key)
    //{
    //    if (currentScreen == ScreenEnum.MainMenu)
    //    {
    //        switch (key)
    //        {
    //            case ConsoleKey.UpArrow:
    //                selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
    //                break;

    //            case ConsoleKey.DownArrow:
    //                selectedIndex = (selectedIndex + 1) % options.Length;
    //                break;

    //            case ConsoleKey.Enter:
    //                if (selectedIndex == 0) // Iniciar
    //                {
    //                    currentScreen = ScreenEnum.SubMenu;
    //                }
    //                break;
    //        }
    //    }
    //    else if (currentScreen == ScreenEnum.SubMenu)
    //    {
    //        switch (key)
    //        {
    //            case ConsoleKey.UpArrow:
    //                subSelectedIndex = (subSelectedIndex - 1 + subOptions.Length) % subOptions.Length;
    //                break;

    //            case ConsoleKey.DownArrow:
    //                subSelectedIndex = (subSelectedIndex + 1) % subOptions.Length;
    //                break;

    //            case ConsoleKey.Enter:
    //                ExecuteSubMenu();
    //                break;
    //        }
    //    }
    //}

    //static void DrawMainMenu()
    //{
    //    int width = 40;
    //    int height = options.Length + 4;

    //    int startX = (Console.WindowWidth - width) / 2;
    //    int startY = (Console.WindowHeight - height) / 2;

    //    DrawBox(startX, startY, width, height);

    //    Console.SetCursorPosition(startX + 2, startY);
    //    Console.ForegroundColor = ConsoleColor.Yellow;
    //    Console.Write(" Sharp - Bank ");
    //    Console.ResetColor();

    //    for (int i = 0; i < options.Length; i++)
    //    {
    //        int posX = startX + 2;
    //        int posY = startY + 2 + i;

    //        Console.SetCursorPosition(posX, posY);

    //        if (i == selectedIndex)
    //        {
    //            Console.BackgroundColor = ConsoleColor.White;
    //            Console.ForegroundColor = ConsoleColor.Black;
    //            Console.Write($"> {options[i]}".PadRight(width - 4));
    //        }
    //        else
    //        {
    //            Console.ForegroundColor = ConsoleColor.Gray;
    //            Console.Write($"  {options[i]}");
    //        }

    //        Console.ResetColor();
    //    }
    //}

    //static void DrawSubMenu()
    //{
    //    int width = Console.WindowWidth - 2;
    //    int height = Console.WindowHeight - 2;

    //    int startX = 0;
    //    int startY = 0;

    //    DrawBox(startX, startY, width, height);

    //    Console.SetCursorPosition(2, 0);
    //    Console.ForegroundColor = ConsoleColor.Cyan;
    //    Console.Write(" SubMenu ");
    //    Console.ResetColor();

    //    for (int i = 0; i < subOptions.Length; i++)
    //    {
    //        int posX = 4;
    //        int posY = 3 + i;

    //        Console.SetCursorPosition(posX, posY);

    //        if (i == subSelectedIndex)
    //        {
    //            Console.BackgroundColor = ConsoleColor.White;
    //            Console.ForegroundColor = ConsoleColor.Black;
    //            Console.Write($"> {subOptions[i]}".PadRight(30));
    //        }
    //        else
    //        {
    //            Console.ForegroundColor = ConsoleColor.Gray;
    //            Console.Write($"  {subOptions[i]}");
    //        }

    //        Console.ResetColor();
    //    }
    //}

    //static void DrawLoginMenu()
    //{
    //    while (true)
    //    {
    //        Console.Clear();

    //        int width = Console.WindowWidth - 2;
    //        int height = Console.WindowHeight - 2;

    //        DrawBox(0, 0, width, height);

    //        Console.SetCursorPosition(2, 0);
    //        Console.ForegroundColor = ConsoleColor.Cyan;
    //        Console.Write(" L O G I N ");
    //        Console.ResetColor();

    //        int labelX = 4;
    //        int inputX = 25;

    //        // --- INPUT CONTA ---
    //        Console.SetCursorPosition(labelX, 3);
    //        Console.Write("Número da conta:");

    //        string accountInput = ReadInput(inputX, 3);

    //        if (accountInput == "__ESC__")
    //            currentScreen = ScreenEnum.MainMenu;


    //        if (!int.TryParse(accountInput, out int accountNumber))
    //        {
    //            ShowError("Conta inválida. Pressione qualquer tecla...");
    //            Console.ReadKey(true);
    //            continue;
    //        }

    //        // --- INPUT SENHA ---
    //        Console.SetCursorPosition(labelX, 5);
    //        Console.Write("Senha:");

    //        string password = ReadInput(inputX, 5, true);

    //        if (password == "__ESC__")
    //            return;

    //        // --- SIMULAÇÃO DE VALIDAÇÃO ---
    //        if (accountNumber == 123 && password == "123")
    //        {
    //            ShowSuccess("Login realizado com sucesso!");
    //            Console.ReadKey(true);
    //            return;
    //        }
    //        else
    //        {
    //            ShowError("Credenciais inválidas!");
    //            Console.ReadKey(true);
    //        }
    //    }
    //}

    //static string ReadInput(int x, int y, bool isPassword = false)
    //{
    //    Console.SetCursorPosition(x, y);

    //    string input = "";

    //    while (true)
    //    {
    //        var key = Console.ReadKey(true);

    //        if (key.Key == ConsoleKey.Enter)
    //            break;

    //        if (key.Key == ConsoleKey.Escape)
    //            return "__ESC__";

    //        if (key.Key == ConsoleKey.Backspace && input.Length > 0)
    //        {
    //            input = input[..^1];

    //            Console.SetCursorPosition(x + input.Length, y);
    //            Console.Write(" ");
    //            Console.SetCursorPosition(x + input.Length, y);
    //        }
    //        else if (!char.IsControl(key.KeyChar))
    //        {
    //            input += key.KeyChar;

    //            Console.SetCursorPosition(x + input.Length - 1, y);
    //            Console.Write(isPassword ? "*" : key.KeyChar);
    //        }
    //    }

    //    return input;
    //}

    //static void ShowError(string message)
    //{
    //    Console.SetCursorPosition(4, Console.WindowHeight - 4);
    //    Console.ForegroundColor = ConsoleColor.Red;
    //    Console.Write(message.PadRight(Console.WindowWidth - 6));
    //    Console.ResetColor();
    //}

    //static void ShowSuccess(string message)
    //{
    //    Console.SetCursorPosition(4, Console.WindowHeight - 4);
    //    Console.ForegroundColor = ConsoleColor.Green;
    //    Console.Write(message.PadRight(Console.WindowWidth - 6));
    //    Console.ResetColor();
    //}

    //static void ExecuteSubMenu()
    //{
    //    if (subSelectedIndex == 0) // Escrever
    //    {
    //        Console.Clear();

    //        DrawBox(0, 0, Console.WindowWidth - 2, Console.WindowHeight - 2);

    //        Console.SetCursorPosition(4, 4);
    //        Console.Write("Executando ação...");

    //        Console.SetCursorPosition(4, 6);
    //        Console.ForegroundColor = ConsoleColor.Green;
    //        Console.Write("Texto exemplo sendo exibido no console.");
    //        Console.ResetColor();

    //        Console.SetCursorPosition(4, 8);
    //        Console.Write("Pressione qualquer tecla para voltar...");
    //        Console.ReadKey(true);
    //    }
    //    else if (subSelectedIndex == 1) // Voltar
    //    {
    //        currentScreen = ScreenEnum.MainMenu;
    //    }
    //}

    //static void DrawBox(int x, int y, int width, int height)
    //{
    //    Console.SetCursorPosition(x, y);
    //    Console.Write("┌" + new string('─', width - 2) + "┐");

    //    for (int i = 1; i < height - 1; i++)
    //    {
    //        Console.SetCursorPosition(x, y + i);
    //        Console.Write("│" + new string(' ', width - 2) + "│");
    //    }


    //    Console.SetCursorPosition(x, y + height - 1);
    //    Console.Write("└" + new string('─', width - 2) + "┘");
    //}
}
