using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using KnifeStore.Models;
using System.Web.Security;
using WebMatrix.WebData;

namespace KnifeStore.DataAccess
{
    public class KnifeStoreInitializer : DropCreateDatabaseIfModelChanges<KnifeStoreContext>
    {
        protected override void Seed(KnifeStoreContext context)
        {
            //var addresses = new List<Address>
            //{
            //    new Address { AddressLine1 = "120 Twinkle Way NW", City="Gold Coast", State=States.WA, Zip="11111" },
            //    new Address { AddressLine1 = "121 Twinkle Way NW", City="Gold Coast", State=States.WA, Zip="11111" },
            //    new Address { AddressLine1 = "122 Twinkle Way NW", City="Gold Coast", State=States.WA, Zip="11111" },
            //    new Address { AddressLine1 = "123 Twinkle Way NW", City="Gold Coast", State=States.WA, Zip="11111" },
            //    new Address { AddressLine1 = "124 Twinkle Way NW", City="Gold Coast", State=States.WA, Zip="11111" },
            //    new Address { AddressLine1 = "125 Twinkle Way NW", City="Gold Coast", State=States.WA, Zip="11111" }
            //};
            //addresses.ForEach(a => context.Addresses.Add(a));
            //context.SaveChanges();

            //var billingInfo = new List<BillingInfo>
            //{
            //    new BillingInfo { AddressId=1, BillingName="Mary Perkins", CreditCardNumber="1233515663454523", SecurityCode=100, ExpirationMonth=10, ExpirationYear=2016, CustomerId=1 },
            //    new BillingInfo { AddressId=2, BillingName="Jimmy Perkins", CreditCardNumber="1233515663454523", SecurityCode=100, ExpirationMonth=10, ExpirationYear=2016, CustomerId=2 },
            //    new BillingInfo { AddressId=3, BillingName="Johnny Perkins", CreditCardNumber="1233515663454523", SecurityCode=100, ExpirationMonth=10, ExpirationYear=2016, CustomerId=3 },
            //    new BillingInfo { AddressId=4, BillingName="Mindy Perkins", CreditCardNumber="1233515663454523", SecurityCode=100, ExpirationMonth=10, ExpirationYear=2016, CustomerId=4 },
            //    new BillingInfo { AddressId=5, BillingName="Bob Perkins", CreditCardNumber="1233515663454523", SecurityCode=100, ExpirationMonth=10, ExpirationYear=2016, CustomerId=5 },
            //};
            //billingInfo.ForEach(bi => context.BillingInfo.Add(bi));
            //context.SaveChanges();

            //var customers = new List<Customer>
            //{
            //    new Customer { Email="mary@perkins.com", FirstName="Mary", LastName="Perkins", Subscribed=true },
            //    new Customer { Email="Jimmy@perkins.com", FirstName="Jimmy", LastName="Perkins", Subscribed=false },
            //    new Customer { Email="Johnny@perkins.com", FirstName="Johnny", LastName="Perkins", Subscribed=true },
            //    new Customer { Email="Mindy@perkins.com", FirstName="Mindy", LastName="Perkins", Subscribed=false },
            //    new Customer { Email="Bob@perkins.com", FirstName="Bob", LastName="Perkins", Subscribed=true }
            //};
            //customers.ForEach(c => context.Customers.Add(c));
            //context.SaveChanges();

            var products = new List<Product>
            {
                new Product { Country="Japan", Name="Awesome-o Knife", Price=999.99, ShippingWeight=10.5, ProductType=ProductTypes.KNIF, DateAdded=DateTime.Now },
                new Product { Country="Germany", Name="Stienbringer", Price=499.99, ShippingWeight=10.5, ProductType=ProductTypes.KNIF, DateAdded=DateTime.Today },
                new Product { Country="France", Name="DABOMB Knife", Price=99.99, ShippingWeight=10.5, ProductType=ProductTypes.KNIF, DateAdded=DateTime.Now },
            };

            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }
    }
}