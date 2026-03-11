using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace LocatemApi.Model
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Logradouro é um valor obrigatório")]
        public string Logradouro { get; set; } = string.Empty;

        [Required(ErrorMessage = "Número é obrigatório")]
        [StringLength(10)]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bairro é um valor obrigatório")]
        [StringLength(100)]
        public string Bairro { get; set; } = string.Empty;

        [StringLength(150)]
        public string Complemento { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cidade é um valor obrigatório")]
        [StringLength(100)]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "Estado é um valor obrigatório")]
        [StringLength(50)]
        public string Estado { get; set; } = string.Empty;

            [Required(ErrorMessage = "CEP é um valor obrigatório")]
            [StringLength(9)]
           public string CEP { get; set; } = string.Empty;

        public int ClienteId { get; set; }
        
        [ForeignKey(nameof(ClienteId))]
        [JsonIgnore]
        public Cliente Cliente { get; set; } = null!;
    }
}
