using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore04.Models
{
    public class Manager
    {
        public int Id { get; set; }
        [Required, MaxLength(100)] public string FullName { get; set; } = null!;
        [Required, MaxLength(150)] public string Email { get; set; } = null!;
        [MaxLength(20)] public string PhoneNumber { get; set; } = null!;
        public DateTime HireDate { get; set; }

        public Branch? Branch { get; set; }                 // 1:1
    }
}
