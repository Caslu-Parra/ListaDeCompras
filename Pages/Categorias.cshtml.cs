using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaDeCompras.Pages
{
    public class Categorias : PageModel
    {

        public List<Categoria> lCategorias { get; set; } = new List<Categoria>();

        public void OnGet()
        {
            var nomes = new[] { "Lucas", "Carlos", "Maria", "Bruna", "Julia" };

            for (int i = 0; i <= 50; i++)
                lCategorias.Add(new Categoria(i, nomes[new Random().Next(0, nomes.Length)], i * 12.75M));
        } 

    }

    public record Categoria(
        int Id,
        string Titulo,
        decimal Preco
    );
}