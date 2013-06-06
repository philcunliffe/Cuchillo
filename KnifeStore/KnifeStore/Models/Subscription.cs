using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnifeStore.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public int UserProfileId { get; set; }
        public int ProductId { get; set; }
    }
}