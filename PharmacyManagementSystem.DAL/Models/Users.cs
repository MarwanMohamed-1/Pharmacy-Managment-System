using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(255)]
        public string UserPassword { get; set; }

        [Required]
        [MaxLength(100)]
        public string Role { get; set; }

        public bool IsActive { get; set; }
    }
}
