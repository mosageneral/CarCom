using CarCom.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarCom.Models
{
    public class BuyTheCar
    {
        public int Id { get; set; }
        [Display(Name="تاريخ الطلب")]
        public DateTime  BuyingDate { get; set; }
        [Display(Name = "رسالة الطلب")]
        public string Message { get; set; }
        public string UserId { get; set; }
        public int CarId { get; set; }
        public virtual  Car  Car { get; set; }
        public ApplicationUser  User { get; set; }

    }
}