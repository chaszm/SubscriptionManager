using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubscriptionManager.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string name { get; set; }

        public string logo { get; set; }

        public int amount { get; set; }

        public DateTime length { get; set; }

        public DateTime startDate { get; set; }

        public string status { get; set; }

        public string siteLink { get; set; }


        public Subscription()
        {


        }



    }
}