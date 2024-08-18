using RSGymPT.UserAdministration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT.UserAdministration.Services
{
    public static class UtilsService
    {
        
        #region SetConsoleColorForRole
        // Função para definir a cor do console de acordo com o perfil do utilizador
        public static void SetConsoleColorForRole(string role)
        {
            switch (role)
            {
                case "Admin":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "PowerUser":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "SimpleUser":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }
        #endregion

        #region DisplayUserInfo
        // Função para exibir o nome do utilizador logado no topo do menu
        public static void DisplayUserInfo(Utilizador user)
        {
            //Console.Clear(); // Limpa o ecrã
            Utility.WriteMessage($"Logado como: {user.Nome} ({user.Perfil})");
            Console.WriteLine(); // Linha em branco para espaçamento
        }
        #endregion

        #region ReadPassword
        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true); // Captura a tecla pressionada, mas não exibe no console

                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    // Apaga o último caractere da senha e remove o último asterisco do console
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b"); // Remove o asterisco da tela
                }
                else if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace && !char.IsControl(key.KeyChar))
                {
                    // Adiciona o caractere à senha e exibe um asterisco
                    password += key.KeyChar;
                    Console.Write("*");
                }

            } while (key.Key != ConsoleKey.Enter); // Continua até o usuário pressionar Enter

            return password;
        }
        #endregion


    }
}
