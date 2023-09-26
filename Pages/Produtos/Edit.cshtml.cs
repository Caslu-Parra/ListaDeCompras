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
        public ProdutoBindView ProdutoBind { get; set; }
        public List<UsuarioModel> GetUsuarios() => _conexao.Usuarios.ToList();
        public Edit(ILogger<Create> logger, BancoContext dbContext)
        {
            _conexao = dbContext;
            _logger = logger;
        }
        public async Task<IActionResult> OnGetAsync(int? pId)
        {
            ProdutoModel prod = await _conexao.Produtos.Include(p => p.Responsavel).FirstAsync(p => p.Id == pId);

            if (pId == null || prod == null)
            {
                return NotFound();
            }
            else ProdutoBind = new ProdutoBindView()
            {
                Id = prod.Id,
                Nome = prod.Nome,
                DtHrInclusao = prod.DtHrInclusao,
                Referencia = prod.Referencia,
                ResponsavelId = prod.Responsavel.Id
            };

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ProdutoModel ProdUpdate = await _conexao.Produtos.FindAsync(ProdutoBind.Id);

            ProdUpdate.Nome = ProdutoBind.Nome;
            ProdUpdate.Referencia = ProdutoBind.Referencia;
            ProdUpdate.Responsavel = await _conexao.Usuarios.FindAsync(ProdutoBind.ResponsavelId);

            _conexao.Produtos.Update(ProdUpdate);
            await _conexao.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}