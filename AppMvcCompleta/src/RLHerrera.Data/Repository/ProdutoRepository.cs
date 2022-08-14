using Microsoft.EntityFrameworkCore;
using RLHerrera.Business.Interfaces;
using RLHerrera.Business.Models;
using RLHerrera.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RLHerrera.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context) { }

        public async Task<Produto> ObterProdutoFornecedor(Guid id) 
            => await Db.Produtos
            .AsNoTracking()
            .Include(f => f.Fornecedor)
            .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores() =>
            await Db.Produtos
            .AsNoTracking()
            .Include(f => f.Fornecedor)
            .OrderBy(p => p.Nome)
            .ToListAsync();

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId) 
            => await Buscar(p => p.FornecedorId == fornecedorId);
    }
}