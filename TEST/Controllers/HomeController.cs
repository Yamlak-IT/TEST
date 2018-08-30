using TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace TEST.Controllers
{
    public class HomeController : Controller
    {
        private Context db = new Context();
        // GET: Home
        public ActionResult Index()
        {
            var Product = db.Product;
            return View(Product.ToList());
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchName)
        {
            var result = db.Product.Where(a => a.Name.Contains(searchName)
            || a.Description.Contains(searchName)).ToList();

            ViewBag.SearchValue = searchName;
            return View(result);
        }

        //public JsonResult SearchAjax(string searchName)        
        //{                             

        //    var ProductList = (from N in db.Product
        //                    where N.Name.Contains(searchName)
        //                    select new { N.Name });
        //    return Json(ProductList, JsonRequestBehavior.AllowGet);
        //}    



        public ActionResult Search2()
        {
            return View(db.Product.ToList());
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {            

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel contact)
        {
            //We Can Use Our E-Mail            


            //var mail = new MailMessage();
            //var LoginInfo = new NetworkCredential("example@gmail.com", "password");
            //mail.From = new MailAddress(contact.Email);
            //mail.To.Add(new MailAddress("example@gmail.com"));
            //mail.Subject = contact.Subject;
            //mail.IsBodyHtml = true;

            //string body = "اسم المرسل: " + contact.Name + "<br>" +
            //              "بريد المرسل: " + contact.Email + "<br>" +
            //              "عنوان الرسالة: " + contact.Subject + "<br>" +
            //              "نص الرسالة: <b>" + contact.Message + "</b>";

            //mail.Body = body;

            //var SmtpClient = new SmtpClient("smtp.gmail.com", 587);//For Gmail mail server
            //SmtpClient.EnableSsl = true;
            //SmtpClient.Credentials = LoginInfo;

            //// Here We Will Send The EMail
            //SmtpClient.Send(mail);
            

            return RedirectToAction("Index");
        }
    }
}