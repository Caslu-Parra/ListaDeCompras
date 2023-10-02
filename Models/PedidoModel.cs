using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListaDeCompras.Models
{
    [Table("pedidos")]
    public class PedidoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DtHr { get; set; }
        public UsuarioModel Responsavel { get; set; }
        [Key]
        public ProdutoModel Produto { get; set; }
        public int Quantidade { get; set; }
    }
}