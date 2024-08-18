using System;

namespace RSGymPT.UserAdministration.Models
{
    public class Utilizador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public string Perfil { get; set; } // Admin, PowerUser, SimpleUser
    }
}
