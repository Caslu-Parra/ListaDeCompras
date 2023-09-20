using ListaDeCompras.Controllers.Produtos;
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
        public ProdutoBindView Produto { get; set; } = null;
        public List<Usuario> GetUsuarios() => _conexao.Usuarios.ToList();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _conexao.Produtos.Add(new Produto
            {
                Nome = this.Produto.Nome,
                DtHrInclusao = this.Produto.DtHrInclusao,
                Referencia = this.Produto.Referencia,
                Responsavel = _conexao.Usuarios.First(u => u.Id == this.Produto.ResponsavelId)
            });
            await _conexao.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}