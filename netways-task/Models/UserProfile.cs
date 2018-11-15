using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace netways_task.Models
{
    public class UserProfile
    {
        [Key]
        public string LoginName { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public DateTime BirthDate { get; set; }
        public Country Country { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
        public double Salary { get; set; }
        public byte?[] image { get; set; }
    }
}