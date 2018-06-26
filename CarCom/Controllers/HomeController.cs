using CarCom.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CarCom.Controllers
{
   
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult Details (int CarId)
        {
            var Car = db.Cars.Find(CarId);
            if (Car ==null )
            {
                return HttpNotFound();
            }

            Session["CarId"] = CarId;
                return View(Car);
           
        }
        public ActionResult GetCarsByUser()
        {
            var UserId = User.Identity.GetUserId();
            var Cars = db.BuyTheCars.Where(a => a.UserId == UserId);
            return View(Cars.ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize ]
        public ActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Apply(string Message)
        {
            var UserId = User.Identity.GetUserId();
            var CarId =(int)Session ["CarId"];
            var check = db.BuyTheCars.Where(a => a.CarId == CarId && a.UserId == UserId).ToList();
            if (check.Count < 1)
            {

                var Car = new BuyTheCar();
                Car.CarId = CarId;
                Car.UserId = UserId;
                Car.Message = Message;
                Car.BuyingDate = DateTime.Now;
                db.BuyTheCars.Add(Car);
                db.SaveChanges();
                ViewBag.Result = "تمت اضافة طلبك";
            }
            else
            {
                ViewBag.Result = "حدث خطأ إما أنك قد تقدمت بالطلب مسبقا";
            }
           
            return View();
        }


       
        [HttpGet ]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost ]
        public ActionResult Contact(ContactModel Contact)
        {
            var Mail = new MailMessage();
            var LoginInfo = new NetworkCredential("mosageneral@gmail.com", "12581258");
            Mail.From = new MailAddress(Contact.Email);
            Mail.To.Add(new MailAddress("mosageneral@gmail.com"));
            Mail.Subject = Contact.Subject;
            Mail.Body = Contact.Message;
            var smtpClinte = new SmtpClient("smtp.gmail.com", 587);
            smtpClinte.EnableSsl = true;
            smtpClinte.Credentials = LoginInfo;
            smtpClinte.Send(Mail);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var Car = db.BuyTheCars.Find(id);
            if (Car==null)
            {
                return HttpNotFound();
            }
            return View(Car );
        }

        [Authorize ]
        public ActionResult GetCarsBySeller()
        {
            var UserId = User.Identity.GetUserId();
            var cars = from app in db.BuyTheCars
                       join Car in db.Cars
                       on app.CarId equals Car.CarId
                       where Car.User.Id == UserId
                       select app;
             return View(cars.ToList ());
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(BuyTheCar  Car)
        {
            try
            {
                // TODO: Add delete logic here
                var mycar = db.BuyTheCars.Find(Car.Id);
                db.BuyTheCars .Remove(mycar);
                db.SaveChanges();
                return RedirectToAction("GetCarsByUser");
            }
            catch
            {
                return View(Car);
            }
        }
    }
}