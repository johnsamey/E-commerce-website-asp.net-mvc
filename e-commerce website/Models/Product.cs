using e_commerce_website.Data;
using e_commerce_website.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_website.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public ProductType? ProductType { get; set; }
        public string? Image { get; set; }
    }
}
