using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Repository;



namespace WebApplication3.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public class Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string NombreUsuario { get; set; }
            public string Contraseña { get; set; }
            public string Mail { get; set; }

        }
        [HttpGet (Name ="GetUsuarios") ]
              
        
        public List<Usuario> Get()
        {
            return ADO_Usuario.DevolverUsuarios();
        }


    }
}
