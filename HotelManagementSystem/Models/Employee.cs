using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Models
{
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public int employee_id { get; set; }

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
        [StringLength(100)]
        [Column("role")]
        public string role { get; set; }

        [StringLength(20)]
        [Column("phone_number")]
        public string phone_number { get; set; }

        [Required]
        [Column("employment_date", TypeName = "date")]
        public DateTime employment_date { get; set; }

        [Required]
        [Column("work_schedule")]
        public string? work_schedule { get; set; }

        // Навигационные свойства
        public virtual ICollection<CleaningTask> cleaningTask { get; set; }
        public virtual ICollection<MaintenanceTask> maintenanceTask { get; set; }

        public virtual User user { get; set; }
    }
}

