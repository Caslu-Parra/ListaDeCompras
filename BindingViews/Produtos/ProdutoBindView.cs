using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeCompras.Database;
using ListaDeCompras.Models;

namespace ListaDeCompras.Controllers.Produtos
{
    public record ProdutoBindView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Marca { get; set; }

        public int ResponsavelId { get; set; }
        public DateTime DtHrInclusao { get; set; }
    }
}