using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static WebApplication3.Controllers.ProductoController;
using WebApplication3.Repository;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        public class Venta
        {
            public int Id { get; set; }
            public string Comentarios { get; set; }
            public int IdUsuario { get; set; }

            [HttpGet(Name = "GetVenta")]


            public List<Venta> Get()
            {
                return ADO_Ventas.DevolverVenta();
            }
        }



    }
}
