using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarCom.Models
{
    public class Car
    {
        public int CarId { get; set; }
        [Required]
        [Display(Name = "موديل السيارة")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "ثمن السيارة")]
        public int price { get; set; }
       
        [Display(Name = "صورة السيارة")]
        public string Image { get; set; }
        [Required]
        [Display(Name = "المسافة المقطوعة ب الكيلومتر ")]
        public int Distance { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }
        public virtual  Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}