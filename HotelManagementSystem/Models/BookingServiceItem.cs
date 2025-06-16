using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    [Table("booking_services")]
    public class BookingServiceItem
    {
        [Key]
        [Column("booking_service_id")]
        public int booking_service_id { get; set; }

        [Required]
        [Column("booking_id")]
        public int booking_id { get; set; }

        [Required]
        [Column("service_id")]
        public int service_id { get; set; }

        [Required]
        [Column("quantity")]
        public int quantity { get; set; } = 1;

        [Required]
        [Column("total_price")]
        public decimal total_price { get; set; }


        // Навигационные свойства
        [ForeignKey("booking_id")]
        public virtual Booking booking { get; set; }

        [ForeignKey("service_id")]
        public virtual Service service { get; set; }
    }
} 