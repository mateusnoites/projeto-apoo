using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.Models.ViewModels;

namespace WebApplication.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(
            new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Secretario> Secretarios { get; set; }
        public virtual DbSet<ConsultaExame> ConsultaExames { get; set; }
    }
}