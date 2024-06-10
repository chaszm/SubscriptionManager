using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SubscriptionManager.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }


        public string category { get; set; }

        public IEnumerable<SelectListItem> categories { get; set; }

        public float? amount { get; set; }



        public DateTime startDate { get; set; } // MAKE SHOW CALANDER





        public string length { get; set; }

        public IEnumerable<SelectListItem> lengthOptions { get; set; }

        public string status { get; set; }

        public IEnumerable<SelectListItem> statusOptions { get; set; }

        public string siteLink { get; set; }


        public Subscription()
        {


        }



    }
}