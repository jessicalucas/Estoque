using System.ComponentModel.DataAnnotations;

namespace EstoqueAPI.Models
{
    public class Produto
    {
        [KeyAttribute]
        public int Id { get; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public double ValorUnitario { get; set; }
    }
}