using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using RLHerrera.Business.Models;

namespace RLHerrera.App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key] 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Descricao { get; set; }
        
        public IFormFile ImagemUpload { get; set; }
        
        public string Imagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [ScaffoldColumn(false)] 
        public DateTime DataCadastro { get; set; } // = DateTime.UtcNow;

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        /* EF Relational */
        public FornecedorViewModel Fornecedor { get; set; }
    }
}