using AppCrudWeb.Model;
using AppCrudWeb.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppCrudWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        //operazione Read (GET) - Restituisce singolo prodotto per ID
        [HttpGet("Get/{id}")]
        public ActionResult<ProductDto> GetProduct(int id)
        {
            var product = _productService.Read(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        //operazione Read (GETALL) - restituisce tutti i prodotti
        [HttpGet("GetAll")]
        public ActionResult<UserDto> GeAll()
        {
            var product = _productService.GetAll();
            return Ok(product);
        }

        //operazione Create (POST) - Crea nuovo prodotto
        [HttpPost("Create")]
        public ActionResult<ProductDto> CreateProduct(ProductDto productDto)
        {
            var product = _productService.Create(productDto);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        //operazione Update (PUT) - Aggiorna prodotto per id
        [HttpPut("Update/{id}")]
        public ActionResult<ProductDto> UpdateProduct(int id, ProductDto productDto)
        {
            var product = _productService.Update(id, productDto);
            if (UpdateProduct == null) return NotFound();
            return Ok(product);
        }

        //operazione Delete (DELETE) - Elimina prodotto per id
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {

            var success = _productService.Delete(id);
            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
