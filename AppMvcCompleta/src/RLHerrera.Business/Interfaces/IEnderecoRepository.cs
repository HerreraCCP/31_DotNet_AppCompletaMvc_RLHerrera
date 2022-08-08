using System;
using System.Threading.Tasks;
using RLHerrera.Business.Models;

namespace RLHerrera.Business.Interfaces;

public interface IEnderecoRepository : IRepository<Endereco>
{
    Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
}