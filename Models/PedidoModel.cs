using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListaDeCompras.Models
{
    [Table("pedidos")]
    public class PedidoModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DtHr { get; set; }
        [Key]
        public UsuarioModel Responsavel { get; set; }
        public ProdutoModel Produto { get; set; }
        public int Quantidade { get; set; }
    }
}