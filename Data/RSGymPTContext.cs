using Microsoft.EntityFrameworkCore;
using RSGymPT.ClientManagement.Models;
using System.Collections.Generic;

namespace RSGymPT.ClientManagement.Data
{
    public class RSGymPTContext : DbContext
    {
        public RSGymPTContext(DbContextOptions<RSGymPTContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
