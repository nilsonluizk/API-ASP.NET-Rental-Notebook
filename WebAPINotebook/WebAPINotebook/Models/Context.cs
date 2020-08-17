using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPINotebook.Models
{
    public class Context : DbContext
    {

        public DbSet<AlugarNotebook> AlugarNotebooks { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WebAPISenff;Integrated Security=true");
        }
    }
}
