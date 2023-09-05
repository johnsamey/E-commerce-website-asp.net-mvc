using e_commerce_website.Data;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_website.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public ProductType? ProductType { get; set; }
        public string? ImageUrl { get; set; }
    }
}
