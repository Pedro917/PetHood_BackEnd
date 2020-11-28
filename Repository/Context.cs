using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class Context : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Breed> Breeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PetHood;Data Source=DESKTOP-ATOQSQ0", b => b.MigrationsAssembly("ApiPetHoodEF"));
        }
    }
}
