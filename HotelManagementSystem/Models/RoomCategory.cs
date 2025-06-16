using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Models
{
    [Table("room_categories")]
    public class RoomCategory
    {
        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("category_name")]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        // Навигационные свойства
        public ICollection<Room> Rooms { get; set; }
    }
}
