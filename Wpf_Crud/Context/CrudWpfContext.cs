using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Crud.Models;

namespace Wpf_Crud.Context
{
    public class CrudWpfContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ASSTI10\\SQLEXPRESS01;Database=CrudWpf;Trusted_Connection=True;");
        }
    }
}
