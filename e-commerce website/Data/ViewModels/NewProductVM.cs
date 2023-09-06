using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace e_commerce_website.Data.ViewModels
{
    public class NewProductVM
    {
        public int Id { get; set; }

        [Display(Name = "Brand name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Product description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Product category is required")]
        public ProductType ProductType { get; set; }

        [Display(Name = "Product Image URL")]
        [AllowNull]
        public string? ImageURL { get; set; }

    }
}
