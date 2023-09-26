using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ListaDeCompras.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Referencia { get; set; }
        public UsuarioModel Responsavel { get; set; }
        public DateTime DtHrInclusao { get; set; }
        
    }
}