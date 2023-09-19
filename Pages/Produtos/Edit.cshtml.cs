using ListaDeCompras.Database;
using ListaDeCompras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaDeCompras.Pages.Produtos
{
    public class Edit : PageModel
    {
        private readonly BancoContext _conexao;
        public Produto Produto { get; set; }
        private readonly ILogger<Create> _logger;

        public Edit(ILogger<Create> logger, BancoContext dbContext)
        {
            _conexao = dbContext;
            _logger = logger;
        }
        public async Task<IActionResult> OnGetAsync(int? pId)
        {
            if (pId == null || _conexao.Produtos.FindAsync(pId) == null)
                return NotFound();
       
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var prodToUpdate = await _conexao.Produtos.FindAsync(id);

            if (prodToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(
                prodToUpdate,
                "produto",
                p => p.Nome, p => p.Responsavel, p => p.DtHrInclusao))
            {
                await _conexao.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}