using ICEP_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ICEP_System.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        private StoreContextcs _context;
        public AdminController()
        {
            _context = new StoreContextcs();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //Creating form for bus
        public ActionResult CreateBus()
        {
            return View(new Bus { Id = 0 });
        }
        [HttpPost]
        //Save Bus Information into database
        public ActionResult CreateBus(Bus bus)
        {
            if (!ModelState.IsValid)// validate 
            {
                return View("CreateBus", bus);
            }
            if (bus.Id > 0)

                _context.Entry(bus).State = System.Data.Entity.EntityState.Modified;

            else
                bus.TotalRequest = 0;   
                _context.Buss.Add(bus);
            _context.SaveChanges();

            return RedirectToAction("ViewBuses", "Admin");
        }
        //searching method for bus class
        public ActionResult Search(string search)
        {
            var buses = _context.Buss.Where(p => p.FromDestination == search).ToList();
            return View("ViewBuses", buses);
        }
        // display View Buses
        public ActionResult ViewBuses()
        {
            var buses = _context.Buss.ToList();
            return View(buses);
        }
        //delete functionality for buses class
        public ActionResult DeleteBus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = _context.Buss.Find(id);
            if (bus == null)
                return HttpNotFound();
            _context.Buss.Remove(bus);
            _context.SaveChanges();
            return RedirectToAction("ViewBuses");
        }
        // Editing for bus class
        //go html.begin ("Action Name holding the save method" , " itsControllerName")
        public ActionResult EditBus(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var bus = _context.Buss.Find(id);
            if (bus == null)
                return HttpNotFound();
            return View("CreateBus", bus);
        }

        //Reset Bus Requests

        public ActionResult ResetRequest(int? id)
        { if(id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var bus = _context.Buss.Find(id);
            if (bus == null)
                return HttpNotFound();
            bus.TotalRequest = 0;
            _context.SaveChanges();
            return RedirectToAction("ViewBuses");

        }

        //=====================================Driver===================================================================

        //form for Driver
        public ActionResult CreateDriver()
        {
            return View(new BusDriver { Id = 0 });
        }
        //Save data into Database
        [HttpPost]
        public ActionResult CreateDriver(BusDriver busdriver)
        {
            if (!ModelState.IsValid)// validate 
            {
                return View("CreateDriver", busdriver);
            }
            if (busdriver.Id > 0)

                _context.Entry(busdriver).State = System.Data.Entity.EntityState.Modified;

            else
                _context.BussDriver.Add(busdriver);
            _context.SaveChanges();

            return RedirectToAction("ViewDriver", "Admin");
        }

        //view Driver Details
        public ActionResult ViewDriver()
        {
            var busdriver = _context.BussDriver.ToList();
            return View(busdriver);
        }

        //searching method for bus class
        public ActionResult SearchDriver(string search)
        {
            var busdriver = _context.BussDriver.Where(p => p.IDNumber == search).ToList();
            return View("ViewDriver", busdriver);
        }


        //delete functionality for buses class
        public ActionResult DriverDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusDriver busdriver = _context.BussDriver.Find(id);
            if (busdriver == null)
                return HttpNotFound();
            _context.BussDriver.Remove(busdriver);
            _context.SaveChanges();
            return RedirectToAction("ViewDriver");
        }
        // Editing for bus class
        //go html.begin ("Action Name holding the save method" , " itsControllerName")
        public ActionResult DriverEdit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var busdriver = _context.BussDriver.Find(id);
            if (busdriver == null)
                return HttpNotFound();
            return View("CreateDriver", busdriver);
        }

        //==============================Students===============================================================

        //view students information
        public ActionResult ViewStudents()
        {
            var stud = _context.Students.ToList();
            return View(stud);
        }
        public ActionResult SearchStudent(string search)
        {
            var student = _context.Students.Where(p => p.StudentNumber == search).ToList();
            return View("ViewStudents", student);
        }

        //delete functionality for Students class
        public ActionResult DeleteStudent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _context.Students.Find(id);
            if (student == null)
                return HttpNotFound();
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("ViewStudents");
        }
        //==========================================Post Informations=======================================================
        public ActionResult CreateDocument()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateDocument(Document document, HttpPostedFileBase picture)

        {


            // image name
            string documentName = (picture == null) ? null : System.IO.Path.GetFileName(picture.FileName);
            //set path to image
            string documentPath = "~/Uploads/" + documentName;
            //saving image into sever defined location

            picture.SaveAs(Server.MapPath(documentPath));

            document.DocumentName = documentName;
            document.FilePath = documentPath;
            document.DatePosted = DateTime.Now;
            _context.Documents.Add(document);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult ViewUpdates()
        {
            var update = _context.Documents.ToList();
            return View(update);
        }
        public ActionResult DeleteUpdate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = _context.Documents.Find(id);
            if (document == null)
                return HttpNotFound();
            _context.Documents.Remove(document);
            _context.SaveChanges();
            return RedirectToAction("ViewUpdates");
        }
    }
}