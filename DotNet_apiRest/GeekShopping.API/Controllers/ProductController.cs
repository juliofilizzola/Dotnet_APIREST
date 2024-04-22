using GeekShopping.API.Model.Data.Dto;
using GeekShopping.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController(IProductRepository repository) : ControllerBase {
        private readonly IProductRepository _productRepository =
            repository ?? throw new ArgumentNullException(nameof(repository));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> FindAll() {
            var products = await _productRepository.FindAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> FindById(long id) {
            var product = await _productRepository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Create(ProductDTO dto) {
            if (dto == null) return BadRequest();
            var product = _productRepository.Create(dto);
            return Ok(product);
        }


    }
}