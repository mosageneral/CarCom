﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarCom.Models
{
    public class ContactModel
    {
        [Required]
        public string  Name { get; set; }
        [Required]

        public string Message { get; set; }
        [Required]

        public string Subject { get; set; }
        [Required]

        public string Email { get;  set; }
    }
}