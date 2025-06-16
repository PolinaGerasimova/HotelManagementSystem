using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Models
{
    [Table("cleaning_tasks")]
    public class CleaningTask
    {
        [Key]
        [Column("task_id")]
        public int task_id { get; set; }

        [Required]
        [Column("room_id")]
        public int room_id { get; set; }

        [Required]
        [Column("employee_id")]
        public int employee_id { get; set; }

        [Required]
        [Column("task_type")]
        public string task_type { get; set; } = "Standard";

        [Required]
        [Column("scheduled_date", TypeName = "date")]
        public DateTime scheduled_date { get; set; }

        [Column("completed_date", TypeName = "date")]
        public DateTime? completed_date { get; set; }

        [Required]
        [Column("status")]
        public string status { get; set; } = "Scheduled";

        [Column("notes")]
        public string? notes { get; set; }

        [Column("estimated_duration")]
        public int? estimated_duration { get; set; }

        // Навигационные свойства
        [ForeignKey("room_id")]
        public Room room { get; set; }

        [ForeignKey("employee_id")]
        public Employee employee { get; set; }

    }
}