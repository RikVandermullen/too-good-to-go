using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Packet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        public double? Price { get; set; }

        [Required]
        public DateTime? PickUpTime { get; set; }

        [Required]
        public DateTime? LastestPickUpTime { get; set; }

        public Student? ReservedBy { get; set; }

        [Required]
        public City? City { get; set; }

        [Required]
        public Canteen? Canteen { get; set; }

        [Required]
        public MealType? MealType { get; set; }

        [Required]
        public bool HasAlcohol { get => HasAlcohol; set => DoesPacketContainAlcohol(); }

        [Required]
        public ICollection<Product>? Products { get; set; }

        public bool DoesPacketContainAlcohol()
        {
            if (Products == null || Products.Count == 0) return false;

            foreach (var product in Products)
            {
                if (product.HasAlcohol)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
