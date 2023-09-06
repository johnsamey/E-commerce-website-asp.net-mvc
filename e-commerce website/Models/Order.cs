﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_website.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
