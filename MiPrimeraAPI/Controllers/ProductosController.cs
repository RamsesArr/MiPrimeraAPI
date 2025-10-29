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
    }
}
