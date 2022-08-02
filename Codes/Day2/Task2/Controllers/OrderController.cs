using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;
using Task2.Models;


namespace Task2.Controllers
{
    public class OrderController : Controller
    {
        private AssignmentDBEntities context = new AssignmentDBEntities();
        
        public ActionResult Index()
        {
            return View(context.Orders.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,CustomerName,OrderDate,OrderAmount")] Order orderObj)
        {
            if (ModelState.IsValid)
            {
                context.Orders.Add(orderObj);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderObj);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order orderObj = context.Orders.Find(id);
            if (orderObj == null)
            {
                return HttpNotFound();
            }
            return View(orderObj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,CustomerName,OrderDate,OrderAmount")] Order orderObj)
        {
            if (ModelState.IsValid)
            {
                context.Entry(orderObj).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderObj);
        }
    }
}