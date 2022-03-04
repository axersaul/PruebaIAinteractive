using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnica.Services;
using PruebaTecnica.Services.Models;
using PruebaTecnica.WebApi.Models;

namespace PruebaTecnica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
    
        public ProductController()
        {

        }
        /// <summary>
        /// Returns all Product List
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public ActionResult<List<Product>>GetAll()
        {

            try
            {
                var products = AppCache.ProductsInstance;
                if(products.Count < 1)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        /// <summary>
        /// Create a new product and return 0 on success
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<int> CreateProduct(ProductResquest product)
        {
            try
            {
                int response = ProductService.Add(new Product(product.Sku,product.Name));
                if (response == 1)
                    return BadRequest("Ya existe un Producto con ese SKU registrado");

                return Ok(response);
            }
            catch (Exception)
            {

                return BadRequest(1);
            }
        }
        /// <summary>
        /// Modify a product and return 0 on success
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<int> ModifyProduct(ProductResquest product)
        {
            try
            {
                int result =ProductService.Modify(product.Sku, new Product(product.Sku, product.Name));
                if (result == 1)
                    return BadRequest("Ocurrio un error al modificar el producto");

                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(1);
            }
        }
        /// <summary>
        /// Delete a product
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<int> DeleteProduct([FromQuery]string sku)
        {
            try
            {
                int result = ProductService.Delete(sku);
                if (result == 1)
                    return BadRequest("Ocurrio un error al eliminar el producto");

                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(1);
            }
        }
    }
}
