using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Models
{
    public class Service
    {
        [Key]
        [Column("service_id")]
        public int service_id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("service_name")]
        public string service_name { get; set; }

        [Required]
        [Column("price")]
        public decimal price { get; set; }

        [Column("description")]
        public string description { get; set; }

        [Required]
        [Column("is_active")]
        public bool is_active { get; set; } = true;

        // Навигационные свойства
        public virtual ICollection<BookingServiceItem> booking_services { get; set; }
    }
}
