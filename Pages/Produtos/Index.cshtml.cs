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

        public Produto Obter(int pId) => _conexao.Produtos.FirstOrDefault(c => c.Id == pId);
        public IActionResult OnGet() => Page();
        public void Criar(Produto produto)
        {
            try
            {
                _conexao.Produtos.Add(produto);
                _conexao.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }
        public void Editar(Produto produto)
        {
            Produto cAux = this.Obter(produto.Id);
            if (cAux != null)
            {
                cAux.Nome = produto.Nome;
                cAux.Referencia = produto.Referencia;
                cAux.Responsavel = produto.Responsavel;
            }
            else new Exception($"Houve um erro ao tentar atualizar o Produto");
            _conexao.SaveChangesAsync();
        }
        public List<Produto> Listar() => _conexao.Produtos.Include(p => p.Responsavel).ToList();

        public void Delete(int idProduto)
        {
            _conexao.Produtos.Remove(_conexao.Produtos.First(p => p.Id == idProduto));
            _conexao.SaveChangesAsync();
        }
    }
}