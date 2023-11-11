using AplicacionMoodle.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionMoodle.Controllers
{
    public class ProductoController : ControllerBase
    {
        private readonly ProductosInterface _productosInterface;

        public ProductoController(ProductosInterface productosInterface)
        {
            _productosInterface = productosInterface;
        }

        [HttpGet]
        [Route("getProductos")]
        public async Task<IActionResult> GetProductos()
        {
            var resultado = await _productosInterface.GetProductos();
            return Ok(resultado);
        }


        [HttpGet]
        [Route("getProducto/{id}")]

        public async Task<IActionResult> GetProducto(int id)
        {
            var resultado = await _productosInterface.GetProductoId(id);
            return Ok(resultado);
        }


        [HttpGet]
        [Route("getProductoTipo/{id}")]
        public async Task<IActionResult> GetProductoTipo(int id)
        {
            var resultado = await _productosInterface.GetProductoTipo(id);
            return Ok(resultado);
        }

    }
}
