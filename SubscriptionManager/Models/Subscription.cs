using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubscriptionManager.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string name { get; set; }

        public string logo { get; set; }

        public float amount { get; set; }

        public int length { get; set; }

        public DateTime startDate { get; set; }

        public string status { get; set; }

        public IEnumerable<SelectListItem> statusOptions { get; set; }

        public string siteLink { get; set; }


        public Subscription()
        {


        }



    }
}