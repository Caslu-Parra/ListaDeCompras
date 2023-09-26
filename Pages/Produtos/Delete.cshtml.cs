using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeCompras.Database;
using ListaDeCompras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ListaDeCompras.Pages.Produtos
{
    public class Delete : PageModel
    {
        private readonly ILogger<Delete> _logger;
        private readonly BancoContext _conexao;
        public Delete(ILogger<Delete> logger, BancoContext dbContext)
        {
            _conexao = dbContext;
            _logger = logger;
        }
        public async Task<IActionResult> OnGet(int pId)
        {
            ProdutoModel? produto = await _conexao.Produtos.FindAsync(pId);
            if (produto == null)
            {
                return NotFound(produto);
            }

            _conexao.Produtos.Remove(produto);
            await _conexao.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}