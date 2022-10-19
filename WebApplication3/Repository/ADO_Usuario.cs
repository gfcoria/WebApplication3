using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel;
using System.Data.SqlClient;
using static WebApplication3.Controllers.UsuarioController;


namespace WebApplication3.Repository
{
    public class ADO_Usuario
    {
        public static List<Usuario> DevolverUsuarios()
        {
            var listaUsuarios = new List<Usuario>();
            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "TULUM/SQLEXPRESS";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;

            var cs = connectionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "Select * from Usuario";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var usuario = new Usuario();
                    usuario.Id = Convert.ToInt32(reader2.GetValue(0));
                    usuario.Nombre = reader2.GetValue(1).ToString();
                    usuario.Apellido = reader2.GetValue(2).ToString();
                    usuario.NombreUsuario = reader2.GetValue(3).ToString();
                    usuario.Contraseña = reader2.GetValue(4).ToString();
                    usuario.Mail = reader2.GetValue(5).ToString();

                    listaUsuarios.Add(usuario);

                }
                reader2.Close();
                connection.Close();
            }

            return listaUsuarios;

        }






    }
}
