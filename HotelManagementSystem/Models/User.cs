using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int user_id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("username")]
        public string username { get; set; }

        [Required]
        [StringLength(255)]
        [Column("password_hash")]
        public string password_hash { get; set; }

        [Required]
        [Column("role")]
        public string role { get; set; }

        [Column("employee_id")]
        public int? employee_id { get; set; }

        [Required]
        [Column("is_active")]
        public bool is_active { get; set; } = true;

        [Required]
        [Column("created_at")]
        public DateTime created_at { get; set; } = DateTime.Now;

        // Навигационные свойства
        [ForeignKey("employee_id")]
        public Employee employee { get; set; }
    }
} 