using System.ComponentModel.DataAnnotations;

namespace TGTG_GraphQL.Models
{
    public class NewCanteenDTO
    {
        [Required]
        public City City { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public bool WarmMeals { get; set; }
    }
}
