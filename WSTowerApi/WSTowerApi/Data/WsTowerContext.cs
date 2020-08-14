using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowerApi.Models;

namespace WSTowerApi.Data
{
    public class WsTowerContext : DbContext
    {
        public WsTowerContext(DbContextOptions<WsTowerContext> options) : base(options) { }

        public DbSet<Funcao> Funcao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Relato> Relatos { get; set; }
    }
}
