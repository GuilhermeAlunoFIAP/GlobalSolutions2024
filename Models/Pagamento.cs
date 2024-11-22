using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolutionsET.Models
{
    [Table("GS_ET_PAGAMENTO")]
    public class Pagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Valor { get; set; }

        [Required]
        public DateTime DataPagamento { get; set; }

        [Required]
        [MaxLength(255)]
        public string TipoPagamento { get; set; }

        [Required]
        [MaxLength(255)]
        public string StatusPagamento { get; set; }

        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        public int AnuncioId { get; set; }
        public Anuncio Anuncio { get; set; }
    }
}
