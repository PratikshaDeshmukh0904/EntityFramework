using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirstApproach.Models;
using System.Data.Entity;

namespace EFCodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        StudentContext db = new StudentContext();
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //To transfer data from one actionmethod of controller to view
                    //ViewBag.InsertMessage = "<script>alert('Data Inserted Successfully')</script>";
                    TempData["InsertMessage"] = "<script>alert('Data Inserted Successfully')</script>";
                    //ModelState.Clear();
                    return RedirectToAction("Index");  
                    
                    //TempData is to send data from one action method of controller to another action method of controller 
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Data Not Inserted Successfully')</script>";
                    return RedirectToAction("Index");
                }

            }
            return View();

        }

        public ActionResult Edit(int Id)
        {
            var row = db.Students.Where(model => model.Id == Id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if(ModelState.IsValid==true)
            {

            
            db.Entry(s).State = EntityState.Modified;
            int a= db.SaveChanges();
                if(a>0)
                {
                    TempData["UpdateM"] = "<script>alert('Data Updated')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateM"] = "<script>alert('Data Not Updated')</script>";
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
        //Delete
        public ActionResult Delete(int Id)
        {
            var deleterow = db.Students.Where(model => model.Id == Id).FirstOrDefault();
            return View(deleterow);
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["Delete"] = "<script>alert('Data Deleted')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Delete"] = "<script>alert('Not  Deleted')</script>";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public ActionResult Details(int Id)
        {
            var detailrow = db.Students.Where(model => model.Id == Id).FirstOrDefault();
            return View(detailrow);
        }
        
    }
}