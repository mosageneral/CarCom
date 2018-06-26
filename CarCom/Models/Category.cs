using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarCom.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="نوع الفئة")]
        
        public string CategoryName { get; set; }
        [Required]
        [Display(Name = "وصف الفئة")]
        public string CategoryDiscription { get; set; }
        public virtual  ICollection <Car> Cars { get; set; }
    }
}