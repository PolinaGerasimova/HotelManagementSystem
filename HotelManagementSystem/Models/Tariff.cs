using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Models
{
    public class Tariff
    {
        [Key]
        [Column("tariff_id")]
        public int tariff_id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("tariff_name")]
        public string tariff_name { get; set; }

        [Required]
        [Column("discount_percentage")]
        public decimal discount_percentage { get; set; }

        [Column("description")]
        public string description { get; set; }

        [Required]
        [Column("is_active")]
        public bool is_active { get; set; } = true;

        // Навигационные свойства
        public virtual ICollection<Booking> bookings { get; set; }
    }
}
