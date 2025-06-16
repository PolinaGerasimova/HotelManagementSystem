using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    [Table("maintenance_tasks")]
    public class MaintenanceTask
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
        [Column("task_description")]
        public string task_description { get; set; }

        [Required]
        [Column("priority")]
        public string priority { get; set; } = "Medium";

        [Required]
        [Column("scheduled_date", TypeName = "date")]
        public DateTime scheduled_date { get; set; }

        [Column("completed_date", TypeName = "date")]
        public DateTime? completed_date { get; set; }

        [Required]
        [Column("status")]
        public string status { get; set; } = "Scheduled";

        [Column("cost")]
        public decimal? cost { get; set; }

        [Column("notes")]
        public string? notes { get; set; }

        // Навигационные свойства
        [ForeignKey("room_id")]
        public Room room { get; set; }

        [ForeignKey("employee_id")]
        public Employee employee { get; set; }
    }
}