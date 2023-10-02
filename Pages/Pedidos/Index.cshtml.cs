using ListaDeCompras.Database;
using ListaDeCompras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ListaDeCompras.Pages.Pedidos
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly BancoContext _conexao;
        public Index(BancoContext dbContext, ILogger<Index> log)
        {
            _conexao = dbContext;
            _logger = log;
        }
        public IActionResult OnGet() => Page();
        public async Task<List<PedidoModel>> Listar() 
            => await _conexao.Pedidos.Include(p => p.Produto).Include(p => p.Responsavel).OrderBy(x => x.Id).ToListAsync();
    }
}