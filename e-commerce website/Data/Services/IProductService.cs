using e_commerce_website.Data.Base;
using e_commerce_website.Data.ViewModels;
using e_commerce_website.Models;

namespace e_commerce_website.Data.Services
{
    public interface IProductService : IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);

        Task AddNewProductAsync(NewProductVM data);
        Task UpdateProductAsync(NewProductVM data);
    }
}
