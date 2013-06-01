using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace KnifeStore.Models
{
    public class BillingInfo
    {
        [Key]
        public int BillingInfoId { get; set; }
        public string CreditCardNumber { get; set; }
        public int SecurityCode { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public string BillingName { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}