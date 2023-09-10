namespace ListaDeCompras.Models
{
    public record Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string? Referencia { get; set; }
    }
}