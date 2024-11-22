using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolutionsET.Models
{
    [Table("GS_ET_ENDERECO")]
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(255)]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(10)]
        public string Cep
        {
            get => _cep;
            set
            {
                if (!ValidarCep(value))
                    throw new ArgumentException("CEP inválido.");
                _cep = value;
            }
        }
        private string _cep;

        [Required]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required]
        [MaxLength(255)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(2)]
        public string Uf { get; set; }



        public static bool ValidarCep(string cep)
        {

            cep = new string(cep.Where(char.IsDigit).ToArray());


            return cep.Length == 8;
        }
    }
}
