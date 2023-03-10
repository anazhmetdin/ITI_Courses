using CustomerOrders.Areas.Orders.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CustomerOrders.Models;

namespace CustomerOrders.Areas.Customers.Data
{
    public enum Gender
    {
        Male, Female
    }

    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Customer Name")]
        [MinLength(3, ErrorMessage = "Minimum Length of Name is 3")]
        [MaxLength(16, ErrorMessage = "Maximum Length of Name is 16")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Customer Gender")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Enter Customer Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Customer Phone Number")]
        [PhoneNumber(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}