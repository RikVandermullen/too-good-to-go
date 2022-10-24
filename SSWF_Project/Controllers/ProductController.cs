using Domain;
using DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TGTG_Portal.ViewModels;

namespace TGTG_Portal.Controllers
{
    [Authorize(Policy = "OnlyPowerUsersAndUp")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult AdminPanelProducts()
        {
            var products = _productRepository.GetProducts();
            if (products != null)
            {
                var viewModel = new ProductsViewModel
                {
                    Products = products
                };
                return View("AdminPanel-Products", viewModel);
            }
            return View("AdminPanel-Products");
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _productRepository.AddProduct(product);
            return RedirectToAction("AdminPanelProducts");
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
            return RedirectToAction("AdminPanelProducts");
        }

        [HttpPost]
        public IActionResult DeleteProduct(Product product)
        {
            _productRepository.DeleteProduct(product);
            return RedirectToAction("AdminPanelProducts");
        }
    }
}
