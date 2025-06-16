using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Models
{
    public class Booking
    {
        [Key]
        [Column("booking_id")]
        public int booking_id { get; set; }

        [Required]
        [Column("guest_id")]
        public int guest_id { get; set; }

        [Required]
        [Column("room_id")]
        public int room_id { get; set; }

        [Column("tariff_id")]
        public int? tariff_id { get; set; }

        [Required]
        [Column("check_in_date", TypeName = "date")]
        public DateTime check_in_date { get; set; }

        [Required]
        [Column("check_out_date", TypeName = "date")]
        public DateTime check_out_date { get; set; }

        [Required]
        [Column("number_of_guests")]
        public int number_of_guests { get; set; }

        [Required]
        [Column("total_cost")]
        public decimal total_cost { get; set; }

        [Required]
        [Column("total_summ")]
        public decimal total_summ { get; set; }

        [Required]
        [Column("status")]
        public string status { get; set; } = "Confirmed";

        [Required]
        [Column("booking_date")]
        public DateTime booking_date { get; set; } = DateTime.Now;

        [Column("notes")]
        public string? notes { get; set; }

        // Навигационные свойства
        [ForeignKey("guest_id")]
        public Guest guest { get; set; }

        [ForeignKey("room_id")]
        public Room room { get; set; }

        [ForeignKey("tariff_id")]
        public Tariff tariff { get; set; }

        public virtual ICollection<BookingServiceItem> booking_services { get; set; }
    }
}