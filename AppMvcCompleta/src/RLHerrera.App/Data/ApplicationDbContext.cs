using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RLHerrera.App.ViewModels;

namespace RLHerrera.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RLHerrera.App.ViewModels.FornecedorViewModel> FornecedorViewModel { get; set; }
        public DbSet<RLHerrera.App.ViewModels.ProdutoViewModel> ProdutoViewModel { get; set; }
    }
}
