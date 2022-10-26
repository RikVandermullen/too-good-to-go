using System.ComponentModel.DataAnnotations;

namespace TGTG_GraphQL.Models
{
    public class NewProductDTO2
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
