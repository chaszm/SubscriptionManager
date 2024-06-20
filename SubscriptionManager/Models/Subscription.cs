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



        [Display(Name = "Category")]
        public string category { get; set; }

        public IEnumerable<SelectListItem> categories { get; set; }

        [Display(Name = "Amount")]
        public float? amount { get; set; }



        [Display(Name = "Date of Subscription")]
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; } // MAKE SHOW CALANDER




        [Display(Name = "Length")]
        public string length { get; set; }

        public IEnumerable<SelectListItem> lengthOptions { get; set; }


        [Display(Name = "Status")]
        public string status { get; set; }

        public IEnumerable<SelectListItem> statusOptions { get; set; }

        [Display(Name = "Link")]
        public string siteLink { get; set; }

        

        public Subscription()
        {


        }



    }
}