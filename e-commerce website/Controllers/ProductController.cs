using e_commerce_website.Data;
using e_commerce_website.Data.Services;
using e_commerce_website.Data.Static;
using e_commerce_website.Data.ViewModels;
using e_commerce_website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_website.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductController : Controller
    {
        //Context _context = new Context();
        private readonly IProductService _service;

        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(IWebHostEnvironment environment, IProductService service)
        {
            webHostEnvironment = environment;
            _service = service;
        }
        [AllowAnonymous]
        public  async Task<IActionResult> Index()
        {

            var product = await _service.GetAllAsync();
            return View(product);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _service.GetProductByIdAsync(id);
            return View(productDetail);
        }
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product, IFormFile ImageURL)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create", product);
            }
            if (ImageURL != null && ImageURL.Length > 0)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/T-shirts");
                string uniqueFileName = $"{product.Name.Replace(" ", "_")}{Path.GetExtension(ImageURL.FileName)}";
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
					ImageURL.CopyTo(stream);
                }

                product.ImageURL = uniqueFileName;
            }
            await _service.AddNewProductAsync(product);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            var response = new NewProductVM()
            {
                Id = productDetails.Id,
                Name = productDetails.Name,
                Description = productDetails.Description,
                Price = productDetails.Price,
                ImageURL = productDetails.Image,
                ProductType = (ProductType)productDetails.ProductType,
            };

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM product)
        {
            if (id != product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {

                return View(product);
            }
            await _service.UpdateProductAsync(product);
            return RedirectToAction("Index");
        }
    }
}
