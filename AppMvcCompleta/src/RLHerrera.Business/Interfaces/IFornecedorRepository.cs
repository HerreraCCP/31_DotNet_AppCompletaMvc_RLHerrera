using System;
using System.Threading.Tasks;
using RLHerrera.Business.Models;

namespace RLHerrera.Business.Interfaces;

public interface IFornecedorRepository : IRepository<Fornecedor>
{
    Task<Fornecedor> ObterFornecedorEndereco(Guid id);

    Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
}