using e_commerce_website.Data;
using e_commerce_website.Data.Base;
using e_commerce_website.Data.ViewModels;
using e_commerce_website.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace e_commerce_website.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductService
    {
        private readonly Context _context;
        public ProductsService(Context context) : base(context)
        {
            _context = context;
        }
        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newMovie = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                Image = data.ImageURL,
                ProductType = data.ProductType,
            };
            await _context.Products.AddAsync(newMovie);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products
    .FirstOrDefaultAsync(n => n.Id == id);

            return productDetails;
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProduct != null)
            {
                dbProduct.Name = data.Name;
                dbProduct.Description = data.Description;
                dbProduct.Price = data.Price;
                dbProduct.Image = data.ImageURL;
                await _context.SaveChangesAsync();
            }
        }
    }
}
