using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnifeStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public ICollection<Product> Products { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        //public int BillingInfoId { get; set; }
        //public virtual BillingInfo Billinginfo { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        public DateTime OrderDateTime { get; set; }
    }
}