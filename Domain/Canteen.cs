using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Canteen
    {
        public int Id { get; set; }

        [Required]
        public City? City { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public bool? WarmMeals { get; set; }
    }
}
