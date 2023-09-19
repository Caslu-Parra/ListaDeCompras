using ListaDeCompras.Database;
using ListaDeCompras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaDeCompras.Pages.Produtos
{
    public class Create : PageModel
    {
        private readonly BancoContext _conexao;
        private readonly ILogger<Create> _logger;
        public Create(ILogger<Create> logger, BancoContext dbContext)
        {
            _conexao = dbContext;
            _logger = logger;
        }


        [BindProperty]
        public Produto Produto { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Usuario user = _conexao.Usuarios.FirstOrDefault(x => x.Id == Produto.Responsavel.Id);

            if (!ModelState.IsValid)
            {
                _logger.LogError("Not valid");
                return Page();
            }

            // var entry = _conexao.Add(new Produto());
            // entry.CurrentValues.SetValues(this.Produto);
            // await _conexao.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}