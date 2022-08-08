using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RLHerrera.Business.Models;

namespace RLHerrera.Business.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid id);

    Task<IEnumerable<Produto>> ObterProdutosFornecedores();

    Task<Produto> ObterProdutoFornecedor(Guid fornecedorId);


}