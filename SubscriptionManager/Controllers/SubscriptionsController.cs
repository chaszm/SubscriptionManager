using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SubscriptionManager.Data;
using SubscriptionManager.Models;

namespace SubscriptionManager.Controllers
{
    public class SubscriptionsController : Controller
    {
        private SubscriptionManagerContext db = new SubscriptionManagerContext();

        // GET: Subscriptions

        [Authorize]
        public ActionResult Index()
        {
           





            return View(db.Subscriptions.ToList());


        }

        [Authorize]
        public ActionResult Analytics()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult History()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }




        // GET: Subscriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }


        [Authorize]
        // GET: Subscriptions/Create
        public ActionResult Create()
        {
            
            var model = new Subscription {
                
                
                amount = null,


                statusOptions = new List<SelectListItem>
                {

                    new SelectListItem { Value = "Active", Text = "Active", Selected = true },
                    new SelectListItem { Value = "Cancelled", Text = "Cancelled" }
                },

                categories = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Selected = true, Disabled = true, Text = "Select an Option" },
                    new SelectListItem { Value = "Entertainment", Text = "Entertainment" },
                    new SelectListItem { Value = "Food Delivery/Meal Kits", Text = "Food Delivery/Meal Kits" },
                    new SelectListItem { Value = "Health and Fitness", Text = "Health and Fitness" },
                    new SelectListItem { Value = "Technologies", Text = "Technologies" },
                    new SelectListItem { Value = "Other", Text = "Other" }
                },

                lengthOptions = new List<SelectListItem>
                {

                    new SelectListItem { Value = "", Selected = true, Disabled = true, Text = "Select an Option" },
                    new SelectListItem { Value = "7 Days", Text = "7 Days" },
                    new SelectListItem { Value = "15 Days", Text = "15 Days" },
                    new SelectListItem { Value = "1 Month", Text = "1 Month" },
                    new SelectListItem { Value = "2 Months", Text = "2 Months" },
                    new SelectListItem { Value = "3 Months", Text = "3 Months" },
                    new SelectListItem { Value = "4 Months", Text = "4 Months" },
                    new SelectListItem { Value = "5 Months", Text = "5 Months" },
                    new SelectListItem { Value = "6 Months", Text = "6 Months" },
                    new SelectListItem { Value = "1 Year", Text = "1 Year" }
                }

             


            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,category,amount,length,startDate,status,siteLink")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Subscriptions.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subscription);
        }




        [Authorize]
        // GET: Subscriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }





        // POST: Subscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,category,amount,length,startDate,status,siteLink")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subscription);
        }


        [Authorize]
        // GET: Subscriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // POST: Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            db.Subscriptions.Remove(subscription);
            db.SaveChanges();
            return RedirectToAction("Index");
        }












        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
