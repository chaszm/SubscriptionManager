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
        public ActionResult Index(string sortField, string currentSortField, string currentSortOrder, string SearchString)
        {

        var subscriptions = db.Subscriptions.ToList();


            if (!String.IsNullOrEmpty(SearchString))
            {
                string lowerCaseSearchString = SearchString.ToLower();
                subscriptions = subscriptions.Where(s => s.name.ToLower().Contains(lowerCaseSearchString)).ToList();
            }

         var monthlyAmounts = subscriptions
         .GroupBy(s => s.startDate.Month)
         .Select(g => new
         {
             Month = g.Key,
             TotalAmount = g.Sum(s => s.amount)
         })
         .ToDictionary(x => x.Month, x => x.TotalAmount);

            // Store monthly amounts
            ViewBag.JanuaryAmount = monthlyAmounts.ContainsKey(1) ? monthlyAmounts[1] : 0;
            ViewBag.FebruaryAmount = monthlyAmounts.ContainsKey(2) ? monthlyAmounts[2] : 0;
            ViewBag.MarchAmount = monthlyAmounts.ContainsKey(3) ? monthlyAmounts[3] : 0;
            ViewBag.AprilAmount = monthlyAmounts.ContainsKey(4) ? monthlyAmounts[4] : 0;
            ViewBag.MayAmount = monthlyAmounts.ContainsKey(5) ? monthlyAmounts[5] : 0;
            ViewBag.JuneAmount = monthlyAmounts.ContainsKey(6) ? monthlyAmounts[6] : 0;
            ViewBag.JulyAmount = monthlyAmounts.ContainsKey(7) ? monthlyAmounts[7] : 0;
            ViewBag.AugustAmount = monthlyAmounts.ContainsKey(8) ? monthlyAmounts[8] : 0;
            ViewBag.SeptemberAmount = monthlyAmounts.ContainsKey(9) ? monthlyAmounts[9] : 0;
            ViewBag.OctoberAmount = monthlyAmounts.ContainsKey(10) ? monthlyAmounts[10] : 0;
            ViewBag.NovemberAmount = monthlyAmounts.ContainsKey(11) ? monthlyAmounts[11] : 0;
            ViewBag.DecemberAmount = monthlyAmounts.ContainsKey(12) ? monthlyAmounts[12] : 0;

            var totalAmount = subscriptions.Sum(s => s.amount); //total monthly
            var formatted = String.Format("{0:0.00}", totalAmount);
            ViewBag.TotalAmount = formatted;



            //Totals by Category
            var categoryAmounts = subscriptions
                .GroupBy(s => s.category)
                .Select(g => new
                {
                    Category = g.Key,
                    total = g.Sum(s => s.amount)
                })
                .ToDictionary(x => x.Category, x => x.total);

            ViewBag.EntertainmentAmount = categoryAmounts.ContainsKey("Entertainment") ? categoryAmounts["Entertainment"] : 0;
            ViewBag.FoodAmount = categoryAmounts.ContainsKey("Food Delivery/Meal Kits") ? categoryAmounts["Food Delivery/Meal Kits"] : 0;
            ViewBag.HealthAmount = categoryAmounts.ContainsKey("Health and Fitness") ? categoryAmounts["Health and Fitness"] : 0;
            ViewBag.TechAmount = categoryAmounts.ContainsKey("Technologies") ? categoryAmounts["Technologies"] : 0;
            ViewBag.OtherAmount = categoryAmounts.ContainsKey("Other") ? categoryAmounts["Other"] : 0;




            return View(this.sortData(subscriptions, sortField,currentSortField,currentSortOrder));


        }

        private List<Subscription> sortData(List<Subscription> subscriptions,string sortField, string currentSortField, string currentSortOrder)
        {
            if (string.IsNullOrEmpty(sortField))
            {
                ViewBag.SortField = "name";
                ViewBag.SortOrder = "Asc";
            }
            else
            {
                if (currentSortField == sortField)
                {
                    ViewBag.SortOrder = currentSortOrder == "Asc" ? "Desc" : "Asc";
                }
                else
                {
                    ViewBag.SortOrder = "Asc";
                }
                ViewBag.SortField = sortField;
            }

            var propertyInfo = typeof(Subscription).GetProperty(ViewBag.SortField);
            if (ViewBag.SortOrder == "Asc")
            {
                subscriptions = subscriptions.OrderBy(s => propertyInfo.GetValue(s, null)).ToList();
            }
            else
            {
                subscriptions = subscriptions.OrderByDescending(s => propertyInfo.GetValue(s, null)).ToList();
            }
            return subscriptions;




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
