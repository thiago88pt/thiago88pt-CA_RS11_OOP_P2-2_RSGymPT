using System;
using System.Collections.Generic;
using System.Linq;
using RSGymPT.UserAdministration.Models;
using RSGymPT.UserAdministration.Services;

namespace RSGymPT.UserAdministration.Services
{
    public class UtilizadorService
    {
        
        private List<Utilizador> utilizadores = new List<Utilizador>();
        private int currentId = 1;

        #region InicialUsers
        public UtilizadorService()
        {
            // Criação de utilizadores iniciais
            utilizadores.Add(new Utilizador { Id = currentId++, Nome = "admin", Password = "adminpass", Perfil = "Admin" });
            utilizadores.Add(new Utilizador { Id = currentId++, Nome = "poweruser", Password = "powerpass", Perfil = "PowerUser" });
            utilizadores.Add(new Utilizador { Id = currentId++, Nome = "simpleuser", Password = "simplepass", Perfil = "SimpleUser" });
        }
        #endregion

        #region Login
        public Utilizador Login(string nome, string password)
        {
            return utilizadores.FirstOrDefault(u => u.Nome == nome && u.Password == password);
        }
        #endregion

        #region CriarUtilizador
        public void CriarUtilizador(string nome, string password, string perfil)
        {
            utilizadores.Add(new Utilizador { Id = currentId++, Nome = nome, Password = password, Perfil = perfil });
            Utility.WriteMessage("Utilizador criado com sucesso.");
        }
        #endregion

        #region AlterarUtilizador
        public void AlterarUtilizador(int id, string password, string perfil)
        {
            var utilizador = utilizadores.FirstOrDefault(u => u.Id == id);
            if (utilizador != null)
            {
                utilizador.Password = password;
                utilizador.Perfil = perfil;
                Utility.WriteMessage("Utilizador alterado com sucesso.");
            }
            else
            {
                Utility.WriteMessage("Utilizador não encontrado.");
            }
        }
        #endregion

        #region ListarUtilizadores
        public void ListarUtilizadores()
        {
            foreach (var utilizador in utilizadores)
            {
                Utility.WriteMessage($"ID: {utilizador.Id}, Nome: {utilizador.Nome}, Perfil: {utilizador.Perfil}");
            }
        }
        #endregion

        #region PesquisarUtilizadorNome
        public void PesquisarUtilizador(string nome)
        {
            var utilizador = utilizadores.FirstOrDefault(u => u.Nome == nome);
            if (utilizador != null)
            {
                Utility.WriteMessage($"ID: {utilizador.Id}, Nome: {utilizador.Nome}, Perfil: {utilizador.Perfil}");
            }
            else
            {
                Utility.WriteMessage("Utilizador não encontrado.");
            }
        }
        #endregion

        #region PesquisarUtilizadorId
        public void PesquisarUtilizador(int id)
        {
            var utilizador = utilizadores.FirstOrDefault(u => u.Id == id);
            if (utilizador != null)
            {
                Utility.WriteMessage($"ID: {utilizador.Id}, Nome: {utilizador.Nome}, Perfil: {utilizador.Perfil}");
            }
            else
            {
                Utility.WriteMessage("Utilizador não encontrado.");
            }
        }
        #endregion

       
        


    }
}
