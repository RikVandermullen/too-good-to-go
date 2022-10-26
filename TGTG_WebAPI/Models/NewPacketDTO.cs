﻿using Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TGTG_WebAPI.Models
{
    public class NewPacketDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime PickUpTime { get; set; }

        [Required]
        public DateTime LastestPickUpTime { get; set; }

        [Required]
        public City City { get; set; }

        public int CanteenId { get; set; }

        public Student? ReservedBy { get; set; }

        [Required]
        public MealType MealType { get; set; }

        public List<NewProductDTO> Products { get; set; }

        [Required]
        public bool ContainsAlcohol { get; set; }
    }
}
