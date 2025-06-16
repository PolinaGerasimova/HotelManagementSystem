using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Models
{
    public class Room
    {
        [Key]
        [Column("room_id")]
        public int room_id { get; set; }

        [Required]
        [StringLength(10)]
        [Column("room_number")]
        public string room_number { get; set; }

        [Required]
        [Column("category_id")]
        public int category_id { get; set; }

        [Column("description")]
        public string? description { get; set; }


        [Required]
        [Column("max_occupancy")]
        public int max_occupancy { get; set; }

        [Required]
        [Column("base_price_per_night")]
        public decimal base_price_per_night { get; set; }

        [Required]
        [Column("status")]
        // 0 - Свободен, 1 - Занят, 2 - Уборка, 3 - На ремонте, 4 - Не в работе
        public string status { get; set; } = "Available";

        // Навигационные свойства   
        [ForeignKey("category_id")]
        public RoomCategory category { get; set; }


        public virtual ICollection<Booking> bookings { get; set; }
        public virtual ICollection<CleaningTask> cleaningTask { get; set; }
        public virtual ICollection<MaintenanceTask> maintenanceTask { get; set; }
    }
}
