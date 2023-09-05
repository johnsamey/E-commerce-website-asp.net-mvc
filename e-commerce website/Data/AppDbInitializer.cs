using e_commerce_website.Models;

namespace e_commerce_website.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationbuilder)
        {
            using (var serviceScope = applicationbuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<Context>();
                context.Database.EnsureCreated();

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Product 1",
                            Description = "Printed Cotton T-Shirt First Rate For Men - Black",
                            Price = 185.00,
                            ProductType = ProductType.T_Shirt,
                            ImageUrl = "1.jpg",
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
