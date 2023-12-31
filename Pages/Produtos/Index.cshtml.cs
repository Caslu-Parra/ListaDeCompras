using ListaDeCompras.Database;
using ListaDeCompras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ListaDeCompras.Pages.Produtos
{
    public class Index : PageModel
    {
        private readonly BancoContext _conexao;
        public Index(BancoContext dbContext)
        {
            _conexao = dbContext;
        }
        public IActionResult OnGet() => Page();
        public List<ProdutoModel> Listar() => _conexao.Produtos.Include(p => p.Responsavel).ToList();
    }
}