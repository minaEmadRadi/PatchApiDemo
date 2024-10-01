using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductApiDemo.Models;
using ProductApiDemo.Repository;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // PUT: api/products/{id} - Full update
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            if (id != updatedProduct.Id)
            {
                return BadRequest();
            }

            _productRepository.UpdateProduct(updatedProduct);

            return NoContent(); // 204 No Content
        }

        // PATCH: api/products/{id} - Partial update
        [HttpPatch("{id}")]
        public IActionResult PatchProduct(int id, [FromBody] JsonPatchDocument<Product> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(product, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productRepository.UpdateProduct(product);

            return NoContent(); // 204 No Content
        }
    }
}
