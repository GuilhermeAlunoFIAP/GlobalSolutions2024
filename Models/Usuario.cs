using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolutionsET.Models
{
    [Table("GS_ET_USUARIO")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11)]
        public string Cpf
        {
            get => _cpf;
            set
            {
                if (!ValidarCpf(value))
                    throw new ArgumentException("CPF inválido.");
                _cpf = value;
            }
        }
        private string _cpf;

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [MaxLength(9)]
        public string Rg
        {
            get => _rg;
            set
            {
                if (!ValidarRG(value))
                    throw new ArgumentException("RG inválido.");
                _rg = value;
            }
        }
        private string _rg;

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(255)]
        public string Senha { get; set; }

        [Required]
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }


        public static bool ValidarCpf(string cpf)
        {

            cpf = new string(cpf.Where(char.IsDigit).ToArray());


            if (cpf.Length != 11)
                return false;



            return true;
        }

        public static bool ValidarRG(string rg)
        {

            rg = new string(rg.Where(char.IsDigit).ToArray());


            if (rg.Length != 9)
                return false;



            return true;
        }




    }
}
