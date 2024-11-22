using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Routing.Constraints;

namespace GlobalSolutionsET.Models
{
    [Table("GS_ET_ANUNCIO")]
    public class Anuncio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Status { get; set; }

        [Required]
        public DateTime DataAnuncio { get; set; }

        [Required]
        public int Energia { get; set; }

        [Required]
        public int Valor { get; set; }

        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        public int CompradorId { get; set; }
        public Usuario Comprador { get; set; }
    }
}
