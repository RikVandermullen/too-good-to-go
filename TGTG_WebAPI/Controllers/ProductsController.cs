using Domain;
using DomainServices;
using Microsoft.AspNetCore.Mvc;
using TGTG_WebAPI.Models;

namespace TGTG_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return Ok(_productRepository.GetProducts().ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return Ok(_productRepository.GetProductById(id));
        }

        [HttpPost]
        public ActionResult<Product> AddProduct(NewProductDTO product)
        {
            var Product = new Product { Name = product.Name, Image = product.Image, HasAlcohol = product.HasAlcohol };
            return _productRepository.AddProduct(Product);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var Product = _productRepository.GetProductById(id);
            _productRepository.DeleteProduct(Product);

            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public ActionResult<Product> Update(int id, [FromBody] NewProductDTO product)
        {
            var Product = _productRepository.GetProductById(id);

            if (Product == null || id != product.Id)
            {
                return BadRequest();
            }
            var UpdatedProduct = new Product { Id = product.Id, Name = product.Name, Image = product.Image, HasAlcohol = product.HasAlcohol };

            return _productRepository.UpdateProduct(UpdatedProduct);
        }
    }
}
