using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using OnlineGroceryDelivery;
using OnlineGroceryDelivery.Models;

namespace OnlineGroceryDeliveryTests
{
    public class DeliveryPersonTests
    {
        [Fact]
        public void Add_deliveryperson_to_database()
        {
            var options = new DbContextOptionsBuilder<OnlineGroceryDeliveryContext>()
                .UseInMemoryDatabase(databaseName: "Add_deliveryperson_to_database")
                .Options;

            // Run the test against one instance of the context
            using (var context = CreateContext(options))
            {
                var deliverPerson1 = new DeliveryPerson();

                deliverPerson1.Name = "Delivery Person 1";

                context.DeliveryPerson.Add(deliverPerson1);
                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = CreateContext(options))
            {
                Assert.Equal(1, context.DeliveryPerson.Count());
                Assert.Equal("Delivery Person 1", context.DeliveryPerson.Single().Name);
            }
        }

        [Fact]
        public void Find_DeliveryPerson()
        {
            var options = new DbContextOptionsBuilder<OnlineGroceryDeliveryContext>()
                .UseInMemoryDatabase(databaseName: "Find_DeliveryPerson")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = CreateContext(options))
            {
                //Adding Delivery persons to the database
                context.DeliveryPerson.Add(new DeliveryPerson { Name = "Delivery Person 1" });
                context.DeliveryPerson.Add(new DeliveryPerson { Name = "Delivery Person 2" });
                context.DeliveryPerson.Add(new DeliveryPerson { Name = "Delivery Person 3" });

                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = CreateContext(options))
            {
                var result = context.DeliveryPerson.Where(cust => cust.Name.Contains("Delivery Person 2"));
                Assert.Equal(1, result.Count());
            }
        }

        [Fact]
        public void Return_All_DeliveryPersons()
        {
            var options = new DbContextOptionsBuilder<OnlineGroceryDeliveryContext>()
                .UseInMemoryDatabase(databaseName: "Return_All_DeliveryPersons")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = CreateContext(options))
            {
                //Adding Delivery persons to the database
                context.DeliveryPerson.Add(new DeliveryPerson { Name = "Delivery Person 1" });
                context.DeliveryPerson.Add(new DeliveryPerson { Name = "Delivery Person 2" });
                context.DeliveryPerson.Add(new DeliveryPerson { Name = "Delivery Person 3" });

                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = CreateContext(options))
            {
                var result = context.DeliveryPerson;
                Assert.Equal(3, result.Count());
            }
        }

        private static OnlineGroceryDeliveryContext CreateContext(DbContextOptions<OnlineGroceryDeliveryContext> options) => new OnlineGroceryDeliveryContext(options, (context, modelBuilder) =>
        {
            modelBuilder.Entity<DeliveryPerson>()
                .ToInMemoryQuery(() => context.DeliveryPerson.Select(b => new DeliveryPerson { DeliveryPersonId  = b.DeliveryPersonId }));
        });
    }
}
