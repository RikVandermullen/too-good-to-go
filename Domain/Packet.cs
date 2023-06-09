﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Packet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime? PickUpTime { get; set; }

        [Required]
        public DateTime? LastestPickUpTime { get; set; }

        [ForeignKey("Student")]
        public Student? ReservedBy { get; set; }

        [Required]
        public City City { get; set; }

        public int CanteenId { get; set; }

        public Canteen? Canteen { get; set; }

        [Required]
        public MealType MealType { get; set; }

        public IList<Product> Products { get; set; }

        [Required]
        public bool ContainsAlcohol { get; set; }

    }
}
