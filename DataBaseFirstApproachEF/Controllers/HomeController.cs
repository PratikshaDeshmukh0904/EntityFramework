using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBaseFirstApproachEF.Models;
using System.Data.Entity;
namespace DataBaseFirstApproachEF.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DatabaseFirstEFEntities db = new DatabaseFirstEFEntities();
        public ActionResult Index()
        {
            var data = db.students.ToList();

            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(student s)
        {
            if(ModelState.IsValid == true)
            {
            db.students.Add(s);
            int a=db.SaveChanges();
            if (a > 0)
            {
                TempData["InsertMessage"] = "<script>alert('Data Inserted Successfully')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                
                    TempData["InsertMessage"] = "<script>alert('Data Not Inserted Successfully')</script>";
                    return RedirectToAction("Index");
                
            }
        }
            return View();
        }

        //Edit Action Method With id Parameter
        public ActionResult Edit(int id)
        {
            var row = db.students.Where(model => model.id == id).FirstOrDefault();    
            return View(row);
        }
        //When we click on save button this method will call

        [HttpPost]
        public ActionResult Edit(student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully')</script>";
                    return RedirectToAction("Index");
                }
                else
                {

                    TempData["UpdateMessage"] = "<script>alert('Data Not Updated')</script>";
                    return RedirectToAction("Index");

                }
            }
            return View();
        }

        //ActionMethod for Delete
        public ActionResult Delete(int id)
        {
            var Deleterow = db.students.Where(model => model.id == id).FirstOrDefault();
            return View(Deleterow);
        }

        //HttpPost Version For Delete
        [HttpPost]
        public ActionResult Delete(student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["DeleteMessage"] = "<script>alert('Data Deleted Successfully')</script>";
                    return RedirectToAction("Index");
                }
                else
                {

                    TempData["DeleteMessage"] = "<script>alert('Data Not Deleted')</script>";
                    return RedirectToAction("Index");

                }
            }
            return View();
        }

        //Action Method For Details
        public ActionResult Details(int id)
        {
            var Detailrow = db.students.Where(model => model.id == id).FirstOrDefault();
            return View(Detailrow);
        }
    }
}