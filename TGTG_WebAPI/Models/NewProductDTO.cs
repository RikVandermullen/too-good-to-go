using Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TGTG_WebAPI.Models
{
    public class NewProductDTO
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public bool HasAlcohol { get; set; }

        [Required]
        public string? Image { get; set; }

    }
}
