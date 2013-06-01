using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace KnifeStore.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public ICollection<BillingInfo> BillingInfo { get; set; }
        public string Email { get; set; }
        public bool Subscribed { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}