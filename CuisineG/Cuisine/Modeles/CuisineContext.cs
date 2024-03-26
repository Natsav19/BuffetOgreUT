using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cuisine.Modeles
{
    public class CuisineContext : DbContext
    {
        public virtual DbSet<Plats> Plat { get; set; }
        public virtual DbSet<TypePlat> TypePlats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
=> options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CuisineEtOgre;Trusted_Connection=True;");
    }
}
