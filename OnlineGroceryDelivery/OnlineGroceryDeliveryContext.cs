using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using OnlineGroceryDelivery.Models;

namespace OnlineGroceryDelivery
{
    public class OnlineGroceryDeliveryContext : DbContext
    {
        private readonly Action<OnlineGroceryDeliveryContext, ModelBuilder> _customizeModel;

        public OnlineGroceryDeliveryContext(DbContextOptions<OnlineGroceryDeliveryContext> options) : base(options) { }

        public OnlineGroceryDeliveryContext(DbContextOptions<OnlineGroceryDeliveryContext> options, Action<OnlineGroceryDeliveryContext, ModelBuilder> customizeModel)
    : base(options)
        {
            // customizeModel must be the same for every instance in a given application.
            // Otherwise a custom IModelCacheKeyFactory implementation must be provided.
            _customizeModel = customizeModel;
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<DeliveryPerson> DeliveryPerson { get; set; }
    }
}
