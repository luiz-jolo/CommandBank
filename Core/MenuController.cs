using CommandBank.UI;

namespace CommandBank.Core
{
    public class MenuController
    {
        //manter estado
        //processar input

        public List<string> options { get; set; }
        public int selectedIndex { get; set; }

        public MenuController(List<string> options, int selectedIndex)
        {
            this.options = options;
            this.selectedIndex = selectedIndex;
        }

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

        public void HandleInput(ConsoleKey key)
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write($"Tecla pressionada: {key}   ");

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex - 1 + options.Count  ) % options.Count;
                    Console.Write($"index: {selectedIndex}   ");
                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % options.Count;
                    Console.Write($"index: {selectedIndex}   ");
                    break;

                case ConsoleKey.Enter:
                    BaseRenderer b = new BaseRenderer();
                    b.DrawMenu(selectedIndex);
                    //ExecuteSubMenu();
                    break;
            }
        }
        public int RetornaIndexSelecionado(ConsoleKey key)
        {
            
            AtualizaIndexSelecionado(key);
            
            return selectedIndex;
        }

        public void AtualizaIndexSelecionado(ConsoleKey key)
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write($"Tecla pressionada: {key}   ");

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex - 1 + options.Count) % options.Count;
                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % options.Count;
                    break;
            }
        }


    }
}
