using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace cardMage.Models
{
    public class MainContext : DbContext
    {
        public MainContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Carta> Cartas { get; set; }
        public DbSet<TipoCarta> TiposCarta { get; set; }
    }
}