using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMSYSDemo.Models.Demo
{
    public class UserEditViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Team1 { get; set; }

        [Required]
        public string Team2 { get; set; }
    }
}