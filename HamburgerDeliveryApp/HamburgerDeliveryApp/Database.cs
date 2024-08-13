using SQLite;
using System;

namespace HamburgerDeliveryApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
    }

    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int UserId { get; set; }  // Foreign Key to User

        public DateTime OrderDate { get; set; }

        public string Items { get; set; }  // Store as JSON or CSV

        public double TotalAmount { get; set; }
    }

}

