using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaDeCompras.Pages
{
    public class Sobre : PageModel
    {
        private readonly ILogger<Sobre> _logger;

        public Sobre(ILogger<Sobre> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}