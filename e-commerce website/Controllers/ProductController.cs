using e_commerce_website.Data;
using e_commerce_website.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_website.Controllers
{
    public class ProductController : Controller
    {
        Context _context = new Context();
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(IWebHostEnvironment environment)
        {
            webHostEnvironment = environment;
        }
        public async Task<IActionResult> Index()
        {

            var product = await _context.Products.ToListAsync();
            return View(product);
        }
    }
}
