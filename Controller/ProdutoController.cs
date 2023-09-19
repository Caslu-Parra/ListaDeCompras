using ListaDeCompras.Database;
using ListaDeCompras.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompras.Controller
{
    public class ProdutoController
    {
        private readonly BancoContext _conexao;
        public ProdutoController(BancoContext dbContext)
        {
            _conexao = dbContext;
        }

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
            try
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
            catch (Exception) { throw; }
        }

        public Produto Obter(int pId) => _conexao.Produtos.FirstOrDefault(c => c.Id == pId);
        public List<Produto> Listar()
        {
            try
            {
                return _conexao.Produtos.ToList();
            }
            catch (Exception) { throw; }
        }
        public void Excluir(int idProduto)
        {
            try
            {
                _conexao.Produtos.Remove(_conexao.Produtos.First(p => p.Id == idProduto));
                _conexao.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }
    }
}