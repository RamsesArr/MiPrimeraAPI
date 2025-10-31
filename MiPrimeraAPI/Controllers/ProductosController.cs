using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI.Models;

namespace MiPrimeraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private static readonly List<Models.Producto> productos = new()
        {
            new Models.Producto { Id = 1, Nombre = "Producto A", Precio = 10.99m, Stock = 100 },
            new Models.Producto { Id = 2, Nombre = "Producto B", Precio = 15.49m, Stock = 50 },
            new Models.Producto { Id = 3, Nombre = "Producto C", Precio = 7.99m, Stock = 200 }
        };
        [HttpGet]
        public ActionResult<List<Producto>> GetProductos()
        {
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GetProducto(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }
        [HttpPost]
        public ActionResult<Producto> CrearProducto([FromBody] Producto nuevoProducto)
        {
            nuevoProducto.Id = productos.Max(p => p.Id) + 1;
            productos.Add(nuevoProducto);
            return CreatedAtAction(nameof(GetProducto), new { id = nuevoProducto.Id }, nuevoProducto);
        }

        [HttpPut("{id}")]
        public ActionResult ActualizarProducto(int id, [FromBody] Producto productoActualizado)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            producto.Nombre = productoActualizado.Nombre;
            producto.Precio = productoActualizado.Precio;
            producto.Stock = productoActualizado.Stock;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarProducto(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            productos.Remove(producto);
            return NoContent();
        }
    }
}
