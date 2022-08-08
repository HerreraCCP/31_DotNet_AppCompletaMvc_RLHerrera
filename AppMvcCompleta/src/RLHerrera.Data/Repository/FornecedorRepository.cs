using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RLHerrera.Business.Interfaces;
using RLHerrera.Business.Models;
using RLHerrera.Data.Context;

namespace RLHerrera.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores
                .AsNoTracking()
                .Include(f => f.Endereco)
                .OrderBy(f => f.Nome)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores
                .AsNoTracking()
                .Include(f => f.Produtos)
                .Include(f => f.Produtos)
                .OrderBy(f => f.Nome)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}