using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Models
{
    public class Guest
    {
        [Key]
        [Column("guest_id")]
        public int guest_id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("first_name")]
        public string first_name { get; set; }

        [Required]
        [StringLength(50)]
        [Column("last_name")]
        public string last_name { get; set; }

        [StringLength(50)]
        [Column("middle_name")]
        public string? middle_name { get; set; }

        [Required]
        [StringLength(20)]
        [Column("phone_number")]
        public string phone_number { get; set; }

        [StringLength(100)]
        [EmailAddress]
        [Column("email")]
        public string? email { get; set; }

        [StringLength(20)]
        [Column("passport_number")]
        public string? passport_number { get; set; }

        [Column("address")]
        public string? address { get; set; }

        [Column("date_of_birth", TypeName = "date")]
        public DateTime? date_of_birth { get; set; }

        [Required]
        [Column("registration_date")]
        public DateTime registration_date { get; set; } = DateTime.Now;

        public virtual ICollection<Booking> bookings { get; set; }
    }
}