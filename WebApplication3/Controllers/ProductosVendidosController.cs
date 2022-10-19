using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Repository;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosVendidosController : ControllerBase
    {
        public class ProductosVendidos
        {
            public int Id { get; set; }
            public int IdProductos { get; set; }
            public int Stock { get; set; }
            public int IdVenta { get; set; }


            [HttpGet(Name = "GetProductosVendidos")]


            public List<ProductosVendidos> Get()
            {
                return ADO_ProductosVendidos.DevolverProductosVendidos();
            }
        }
    }
}
