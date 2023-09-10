namespace ListaDeCompras.Models
{
    public record Compra
    {
        public int Id { get; set; }
        public DateTime DtHr { get; set; }
        public Usuario Responsavel { get; set; }
        public Produto Produto { get; set; }
    }
}