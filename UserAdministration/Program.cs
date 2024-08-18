using RSGymPT.UserAdministration.Models;
using RSGymPT.UserAdministration.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RSGymPT.UserAdministration
{
    class Program
    {
        static void Main(string[] args)
        {
            Utility.SetUnicodeConsole(); // Configura a codificação do console
            RunApplication();

        }

        #region RunApplication
        static void RunApplication()
        {
            var utilizadorService = new UtilizadorService();
            Utilizador utilizadorLogado = null;

            while (true)
            {
                if (utilizadorLogado == null)
                {
                    Console.ResetColor(); // Reseta a cor para a padrão ao fazer logout
                    Console.Clear();
                    Utility.WriteTitle("RSGymPT.UserAdministration - Login");
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = UtilsService.ReadPassword(); // Usando a função ReadPassword para capturar a senha
                    Console.Write("\n");

                    utilizadorLogado = utilizadorService.Login(nome, password);
                    if (utilizadorLogado != null)
                    {
                        UtilsService.SetConsoleColorForRole(utilizadorLogado.Perfil); // Define a cor baseada no role
                    }
                    else
                    {
                        Utility.WriteMessage("Credenciais inválidas. Tente novamente.", "", "\n");
                        Utility.PauseConsole();
                    }
                }

                if (utilizadorLogado != null)
                {
                    switch (utilizadorLogado.Perfil)
                    {
                        case "Admin":
                            MenuAdmin(utilizadorService, ref utilizadorLogado);
                            break;
                        case "PowerUser":
                            MenuPowerUser(utilizadorService, ref utilizadorLogado);
                            break;
                        case "SimpleUser":
                            MenuSimpleUser(utilizadorService, ref utilizadorLogado);
                            break;
                    }
                }
            }
        }
        #endregion

        #region MenuAdmin
        static void MenuAdmin(UtilizadorService utilizadorService, ref Utilizador utilizadorLogado)
        {
            while (true)
            {
                UtilsService.DisplayUserInfo(utilizadorLogado); // Exibe o nome e o perfil do utilizador logado em cada loop
                Utility.WriteTitle("Menu Admin:");
                Utility.WriteMessage("1. Criar Utilizador");
                Utility.WriteMessage("2. Alterar Utilizador");
                Utility.WriteMessage("3. Listar Utilizadores");
                Utility.WriteMessage("4. Pesquisar Utilizador");
                Utility.WriteMessage("5. Logout");
                Utility.WriteMessage("6. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("User: ");
                        string nome = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = UtilsService.ReadPassword(); // Usando ReadPassword para capturar a senha
                        Console.Write("\nPerfil (Quadrimenstral, Mensal ou Pontual) : ");
                        string perfil = Console.ReadLine();
                        utilizadorService.CriarUtilizador(nome, password, perfil);
                        break;
                    case "2":
                        Console.Write("Id do Utilizador: ");
                        int id = Console.Read();
                        Console.Write("Nova Password: ");
                        string novaPassword = UtilsService.ReadPassword(); // Usando ReadPassword para capturar a nova senha
                        Console.Write("Novo Perfil: ");
                        string novoPerfil = Console.ReadLine();
                        utilizadorService.AlterarUtilizador(id, novaPassword, novoPerfil);
                        break;
                    case "3":
                        utilizadorService.ListarUtilizadores();
                        break;
                    case "4":
                        Console.Write("Pesquisar por Nome: ");
                        string nomePesquisa = Console.ReadLine();
                        utilizadorService.PesquisarUtilizador(nomePesquisa);
                        break;
                    case "5":
                        utilizadorLogado = null; // Faz logout
                        Console.ResetColor(); // Reseta a cor para a padrão ao fazer logout
                        return; // Retorna ao loop principal para novo login
                    case "6":
                        Utility.TerminateConsole(); // Encerra a aplicação
                        Environment.Exit(0);
                        break;
                    default:
                        Utility.WriteMessage("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        #endregion

        #region MenuPowerUser
        static void MenuPowerUser(UtilizadorService utilizadorService, ref Utilizador utilizadorLogado)
        {
            while (true)
            {
                UtilsService.DisplayUserInfo(utilizadorLogado);
                Utility.WriteTitle("Menu Power User:");
                Utility.WriteMessage("1. Listar Utilizadores");
                Utility.WriteMessage("2. Pesquisar Utilizador");
                Utility.WriteMessage("5. Logout");
                Utility.WriteMessage("6. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        utilizadorService.ListarUtilizadores();
                        break;
                    case "2":
                        Console.Write("User: ");
                        string nomePesquisa = Console.ReadLine();
                        utilizadorService.PesquisarUtilizador(nomePesquisa);
                        break;
                    case "5":
                        utilizadorLogado = null; // Faz logout
                        Console.ResetColor(); // Reseta a cor para a padrão ao fazer logout
                        return; // Retorna ao loop principal para novo login
                    case "6":
                        Utility.TerminateConsole(); // Encerra a aplicação
                        Environment.Exit(0);
                        break;
                    default:
                        Utility.WriteMessage("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
        #endregion

        #region MenuSimpleUser
        static void MenuSimpleUser(UtilizadorService utilizadorService, ref Utilizador utilizadorLogado)
        {
            while (true)
            {
                UtilsService.DisplayUserInfo(utilizadorLogado);
                Utility.WriteTitle("Menu Simple User:");
                Utility.WriteMessage("1. Listar Utilizadores");
                Utility.WriteMessage("5. Logout");
                Utility.WriteMessage("6. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        utilizadorService.ListarUtilizadores();
                        break;
                    case "5":
                        utilizadorLogado = null; // Faz logout
                        Console.ResetColor(); // Reseta a cor para a padrão ao fazer logout
                        return; // Retorna ao loop principal para novo login
                    case "6":
                        Utility.TerminateConsole(); // Encerra a aplicação
                        Environment.Exit(0);
                        break;
                    default:
                        Utility.WriteMessage("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
        #endregion

       
    }
}
