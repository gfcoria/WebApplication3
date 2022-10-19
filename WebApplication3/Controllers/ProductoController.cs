using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static WebApplication3.Controllers.UsuarioController;
using WebApplication3.Repository;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public class Producto
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public double Costo { get; set; }
            public double PrecioVenta { get; set; }
            public int Stock { get; set; }
            public int IdUsuario { get; set; }

            [HttpGet(Name = "GetProductos")]


            public List<Producto> Get()
            {
                return ADO_Producto.DevolverProductos();
            }

        }
    }
}
