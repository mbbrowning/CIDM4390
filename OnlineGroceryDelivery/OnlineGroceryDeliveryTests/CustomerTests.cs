using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using OnlineGroceryDelivery;
using OnlineGroceryDelivery.Models;

namespace OnlineGroceryDeliveryTests
{
    public class CustomerTests
    {
        [Fact]
        public void Add_customer_to_database()
        {
            var options = new DbContextOptionsBuilder<OnlineGroceryDeliveryContext>()
                .UseInMemoryDatabase(databaseName: "Add_customer_to_database")
                .Options;

            // Run the test against one instance of the context
            using (var context = CreateContext(options))
            {
                var customer1 = new Customer();

                customer1.LoginId = "customer1";
                customer1.Password = "Test1234!";
                customer1.Name = "Customer 1";
                customer1.Address = "1234 Address, Amarillo, TX 79119";
                customer1.Phone = "(123) 456-7890";
                customer1.Email = "customer1@email.com";

                context.Customers.Add(customer1);
                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = CreateContext(options))
            {
                Assert.Equal(1, context.Customers.Count());
                Assert.Equal("Customer 1", context.Customers.Single().Name);
            }
        }

        [Fact]
        public void Find_customer()
        {
            var options = new DbContextOptionsBuilder<OnlineGroceryDeliveryContext>()
                .UseInMemoryDatabase(databaseName: "Find_customer")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = CreateContext(options))
            {
                //adding customer 1
                var customer1 = new Customer();
                customer1.LoginId = "customer1";
                customer1.Password = "Test1234!";
                customer1.Name = "Customer 1";
                customer1.Address = "1234 Address, Amarillo, TX 79119";
                customer1.Phone = "(123) 456-7890";
                customer1.Email = "customer1@email.com";
                context.Customers.Add(customer1);

                //adding customer 2
                var customer2 = new Customer();
                customer2.LoginId = "customer2";
                customer2.Password = "Test2341!";
                customer2.Name = "Customer 2";
                customer2.Address = "2345 Address, Amarillo, TX 79119";
                customer2.Phone = "(234) 567-8901";
                customer2.Email = "customer2@email.com";
                context.Customers.Add(customer2);

                //adding customer 3
                var customer3 = new Customer();
                customer3.LoginId = "customer3";
                customer3.Password = "Test3412!";
                customer3.Name = "Customer 3";
                customer3.Address = "3456 Address, Amarillo, TX 79119";
                customer3.Phone = "(345) 678-9012";
                customer3.Email = "customer3@email.com";
                context.Customers.Add(customer3);

                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = CreateContext(options))
            {
                var result = context.Customers.Where(cust => cust.Name.Contains("Customer 1"));
                Assert.Equal(1, result.Count());
            }
        }

        [Fact]
        public void Return_all_customers()
        {
            var options = new DbContextOptionsBuilder<OnlineGroceryDeliveryContext>()
                .UseInMemoryDatabase(databaseName: "Return_all_customers")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = CreateContext(options))
            {
                //adding customer 1
                var customer1 = new Customer();
                customer1.LoginId = "customer1";
                customer1.Password = "Test1234!";
                customer1.Name = "Customer 1";
                customer1.Address = "1234 Address, Amarillo, TX 79119";
                customer1.Phone = "(123) 456-7890";
                customer1.Email = "customer1@email.com";
                context.Customers.Add(customer1);

                //adding customer 2
                var customer2 = new Customer();
                customer2.LoginId = "customer2";
                customer2.Password = "Test2341!";
                customer2.Name = "Customer 2";
                customer2.Address = "2345 Address, Amarillo, TX 79119";
                customer2.Phone = "(234) 567-8901";
                customer2.Email = "customer2@email.com";
                context.Customers.Add(customer2);

                //adding customer 3
                var customer3 = new Customer();
                customer3.LoginId = "customer3";
                customer3.Password = "Test3412!";
                customer3.Name = "Customer 3";
                customer3.Address = "3456 Address, Amarillo, TX 79119";
                customer3.Phone = "(345) 678-9012";
                customer3.Email = "customer3@email.com";
                context.Customers.Add(customer3);

                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = CreateContext(options))
            {
                var result = context.Customers;
                Assert.Equal(3, result.Count());
            }
        }

        private static OnlineGroceryDeliveryContext CreateContext(DbContextOptions<OnlineGroceryDeliveryContext> options) => new OnlineGroceryDeliveryContext(options, (context, modelBuilder) =>
        {
            modelBuilder.Entity<Customer>()
                .ToInMemoryQuery(() => context.Customers.Select(b => new Customer { CustomerId = b.CustomerId }));
        });
    }
}
