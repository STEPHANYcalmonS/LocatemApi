using System.ComponentModel.DataAnnotations;
namespace LocatemApi.Model
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome é um valor obrigatório")] //-> anotaçao para obrigatorio
        [StringLength(100, ErrorMessage ="O nome pode conter até 100 caracteres")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage ="campo obrigatório")]
        [EmailAddress(ErrorMessage ="O email deve ser um endereço de email válido")]
        public string Email { get; set; } = string.Empty;
       
        [Required(ErrorMessage ="CPF obrigatório")]
        [StringLength(14, ErrorMessage = "O CPF deve conter 14 caracteres no formato XXX.XXX.XXX-XX")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve estar no formato XXX.XXX.XXX-XX")]
        public string CPF { get; set; } = string.Empty;

        public DateTime DataCadastro { get; set; } 
        public bool Ativo { get; set; } // Define o cliente como ativo por padrão

        public List<Endereco> Enderecos { get; set; } = [];

        public Cliente()
        {
            DataCadastro = DateTime.UtcNow; // Define a data de cadastro como a data atual no momento da criação do cliente
            Ativo = true; // Define o cliente como ativo por padrão
        }
       
    }
}
