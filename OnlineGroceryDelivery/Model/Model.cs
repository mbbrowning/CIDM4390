using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace OnlineGroceryDelivery.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        
        [StringLength(20, MinimumLength = 5)]
        [Required]
        [Display(Name = "Username")]
        public string LoginId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<Order> Orders { get; } = new List<Order>();
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string StatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }

        public List<ItemsInOrder> ItemsOrdered { get; } = new List<ItemsInOrder>();
    }

    public class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public string Name { get; set; }

    }

    public class ItemsInOrder
    {
        [Key]
        public int ItemsOrderedId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Cart
    {
        public int CartId { get; set; }
        public List<ItemsInCart> Items { get; } = new List<ItemsInCart>();
    }

    public class ItemsInCart
    {
        public int ItemsOrderedId { get; set; }
        public int CartId { get; set; }
        public Cart Order { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Delivery
    {
        public int DeliveryId { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public int DeliveryPersonId { get; set; }
        public DeliveryPerson DeliveryPerson { get; set; }
    }

    public class DeliveryPerson
    {
        public int DeliveryPersonId { get; set; }
        public string Name { get; set; }
    }
}

