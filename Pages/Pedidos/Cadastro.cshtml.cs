using ListaDeCompras.BindingViews.Pedidos;
using ListaDeCompras.Database;
using ListaDeCompras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ListaDeCompras.Pages.Pedidos
{
    public class Cadastro : PageModel
    {
        private readonly ILogger<Cadastro> _logger;
        private readonly BancoContext _conexao;
        public Cadastro(BancoContext dbContext, ILogger<Cadastro> log)
        {
            _conexao = dbContext;
            _logger = log;
        }
        [BindProperty]
        public PedidoBindView PedidoBind { get; set; }
        public async Task<List<UsuarioModel>> GetUsuarios() => await _conexao.Usuarios.ToListAsync();
        public async Task<List<ProdutoModel>> GetProdutos()
            => await _conexao.Produtos.Include(p => p.Responsavel).OrderBy(col => col.Nome).ToListAsync();
        public async Task<IActionResult> OnGetAsync(int? pId)
        {
            if (pId is not null)
            {
                var lPedidos = _conexao.Pedidos.Include(p => p.Produto).Include(p => p.Responsavel)
                                               .Where(p => p.Id == pId).ToList();

                PedidoModel ped = lPedidos.Find(p => p.Id == pId);

                if (ped is null) return NotFound();
                else PedidoBind = new PedidoBindView()
                {
                    Id = ped.Id,
                    DtHr = ped.DtHr,
                    ProdutoId = ped.Produto.Id,
                    Quantidade = ped.Quantidade,
                    ResponsavelId = ped.Responsavel.Id
                };
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            PedidoModel ped = await _conexao.Pedidos.FindAsync(PedidoBind.Id, PedidoBind.ProdutoId);

            if (ped is null)
            {
                await _conexao.Pedidos.AddAsync(new PedidoModel
                {
                    // Id = PedidoBind.Id, -> Auto Increment
                    DtHr = PedidoBind.DtHr,
                    Responsavel = await _conexao.Usuarios.FindAsync(PedidoBind.ResponsavelId),
                    Produto = await _conexao.Produtos.FindAsync(PedidoBind.ProdutoId),
                    Quantidade = PedidoBind.Quantidade
                });
            }
            else
            {
                ped.Responsavel = await _conexao.Usuarios.FindAsync(PedidoBind.ResponsavelId);
                ped.Produto = await _conexao.Produtos.FindAsync(PedidoBind.ProdutoId);
                ped.Quantidade = PedidoBind.Quantidade;
                _conexao.Pedidos.Update(ped);
            }
            await _conexao.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}