using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pluralize.NET.Core;
using RLHerrera.Business.Models;

namespace RLHerrera.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            //I need to check why ?
            
            // foreach (var property in modelBuilder.Model.GetEntityTypes()
            //              .SelectMany(e => e.GetProperties()
            //                  .Where(p => p.ClrType == typeof(string))))
            //     property.Relational().ColumnType = "varchar(100)";

            base.OnModelCreating(modelBuilder);
        }
    }
}