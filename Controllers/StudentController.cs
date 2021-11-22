using ICEP_System.Models;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace ICEP_System.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        private StoreContextcs storeContextcs;


        public StudentController()
        {
            storeContextcs = new StoreContextcs();

        }
        // GET: Student

        //view Transport Informations
        public ActionResult Index()
        {
            var bus = storeContextcs.Buss.ToList();

            return View(bus);
        }
        //search buses
        public ActionResult Search(string search)
        {
            var buses = storeContextcs.Buss.Where(p => p.FromDestination == search).ToList();
            return View("Index", buses);
        }
        //View Updated documents

        public ActionResult ViewInformation()
        {
            var doc = storeContextcs.Documents.ToList();
            return View(doc);
        }

        //Requesting link button

        public ActionResult BusRequest(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var bus = storeContextcs.Buss.Find(id);
            if (bus == null)
                return HttpNotFound();
            bus.TotalRequest = bus.TotalRequest + 1;
            if (bus.TotalRequest == bus.PickUpCount + 1)
            {
                var driver = storeContextcs.BussDriver;

                foreach (var item in driver)
                { //Email
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("TUT Transport", "molepollefentse121@gmail.com"));
                    message.To.Add(new MailboxAddress(item.EmailUsername, item.Email));
                    message.Subject = "Number of Bus to send";
                    message.Body = new TextPart("plain")
                    {
                        Text = "Two Buses are needed in   " + bus.FromDestination + " for " + bus.ToDestination + "   Location"

                    };
                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("molepollefentse121@gmail.com", "fefe@121");
                        client.Send(message);
                        client.Disconnect(true);
                    }
              } 

        }
            
            storeContextcs.SaveChanges();
            return Content("Bus has been Requested successfully");
        }
    }
}