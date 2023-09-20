using ListaDeCompras.Controllers.Produtos;
using ListaDeCompras.Database;
using ListaDeCompras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ListaDeCompras.Pages.Produtos
{
    public class Edit : PageModel
    {
        private readonly BancoContext _conexao;
        private readonly ILogger<Create> _logger;

        [BindProperty]
        public Produto Produto { get; set; }

        public List<Usuario> GetUsuarios() => _conexao.Usuarios.ToList();

        public Edit(ILogger<Create> logger, BancoContext dbContext)
        {
            _conexao = dbContext;
            _logger = logger;
        }
        public async Task<IActionResult> OnGetAsync(int? pId)
        {
            Produto prod = _conexao.Produtos.Include(p => p.Responsavel).First(p => p.Id == pId);

            if (pId == null || prod == null)
            {
                return NotFound();
            }
            else Produto = prod;
            
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