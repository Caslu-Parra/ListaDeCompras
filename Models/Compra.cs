using System.ComponentModel.DataAnnotations.Schema;

namespace ListaDeCompras.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime DtHr { get; set; }
        
        public Usuario Responsavel { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

    }
}