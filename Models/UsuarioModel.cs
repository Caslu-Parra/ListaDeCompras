using System.ComponentModel.DataAnnotations;

namespace ListaDeCompras.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public Acesso Acesso { get; set; }
    }
}