using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace KnifeStore.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double ShippingWeight { get; set; }
        public string Country { get; set; }
        public ProductTypes ProductType { get; set; }
        public virtual ICollection<UserProfile> Subscritions { get; set; }
    }

    public class Knife : Product
    {
        public string Type { get; set; }
        public string SteelType { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
    }
}