using CommandBank.UI.Structure;

namespace CommandBank.Domain.Screens
{
    public class LoginScreen : IScreen
    {
        public void StartScreen()
        {

            while (true)
            {
                Console.Clear();

                int width = Console.WindowWidth - 2;
                int height = Console.WindowHeight - 2;

                ConsoleLayout.DrawBox(0, 0, width, height);

                Console.SetCursorPosition(2, 0);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" L O G I N ");
                Console.ResetColor();

                int labelX = 4;
                int inputX = 25;

                // --- INPUT CONTA ---
                Console.SetCursorPosition(labelX, 3);
                Console.Write("Número da conta:");

                string accountInput = ConsoleInput.ReadInput(inputX, 3);

                //if (accountInput == "__ESC__")
                //    currentScreen = ScreenEnum.MainMenu;


                if (!int.TryParse(accountInput, out int accountNumber))
                {
                    ConsoleMessage.ShowError("Conta inválida. Pressione qualquer tecla...");
                    Console.ReadKey(true);
                    continue;
                }

                // --- INPUT SENHA ---
                Console.SetCursorPosition(labelX, 5);
                Console.Write("Senha:");

                string password = ConsoleInput.ReadInput(inputX, 5, true);

                if (password == "__ESC__")
                    return;

                // --- SIMULAÇÃO DE VALIDAÇÃO ---
                if (accountNumber == 123 && password == "123")
                {
                    ConsoleMessage.ShowSuccess("Login realizado com sucesso!");
                    Console.ReadKey(true);
                    return;
                }
                else
                {
                    ConsoleMessage.ShowError("Credenciais inválidas!");
                    Console.ReadKey(true);
                }
            }
            
        }
    }
}