using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeCompras.BindingViews.Pedidos
{
    public class PedidoBindView
    {
        public int? Id { get; set; }
        public DateTime DtHr { get; set; }
        public int ResponsavelId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}