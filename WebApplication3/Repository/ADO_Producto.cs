using static WebApplication3.Controllers.ProductoController;
using System.Data.SqlClient;

namespace WebApplication3.Repository
{
    public class ADO_Producto
    {
        public static List<Producto> DevolverProductos()
        {
            var listaProductos = new List<Producto>();
            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "TULUM/SQLEXPRESS";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;

            var cs = connectionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "Select * from Producto";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var producto = new Producto();
                    producto.Id = Convert.ToInt32(reader2.GetValue(0));
                    producto.Descripcion = Convert.ToString(reader2.GetValue(1));
                    producto.Costo = Convert.ToDouble(reader2.GetValue(2));
                    producto.PrecioVenta = Convert.ToDouble (reader2.GetValue(3));
                    producto.Stock = Convert.ToInt32(reader2.GetValue(4));
                    producto.IdUsuario = Convert.ToInt32(reader2.GetValue(5));

                    listaProductos.Add(producto);

                }
                reader2.Close();
                connection.Close();
            }

            return listaProductos;

        }







    }
}
