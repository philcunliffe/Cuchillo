using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using KnifeStore.Models;

namespace KnifeStore.DataAccess
{
    public class KnifeStoreContext : DbContext
    {
        //public DbSet<Address> Addresses { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        //public DbSet<BillingInfo> BillingInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}