using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace netways_task.Models
{
    public class Account
    {
        [Key]
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}