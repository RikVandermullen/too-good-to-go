using System.ComponentModel.DataAnnotations;

namespace TGTG_GraphQL.Models
{
    public class NewProductDTO
    {
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public bool HasAlcohol { get; set; }

        [Required]
        public string? Image { get; set; }
    }
}
