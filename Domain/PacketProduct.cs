﻿using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class PacketProduct
    {
        [Key]
        public int Id { get; set; }

        public int PacketId { get; set; }

        public Packet Packet { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
