using static WebApplication3.Controllers.ProductosVendidosController;
using System.Data.SqlClient;

namespace WebApplication3.Repository
{
    public class ADO_ProductosVendidos
    {
        public static List<ProductosVendidos> DevolverProductosVendidos()
        {
            var listaProductosVendidos = new List<ProductosVendidos>();
            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "TULUM/SQLEXPRESS";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;

            var cs = connectionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "Select * from ProductoVendido";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var ProductoVendido = new ProductosVendidos();
                    ProductoVendido.Id = Convert.ToInt32(reader2.GetValue(0));
                    ProductoVendido.IdProductos = Convert.ToInt32(reader2.GetValue(1));
                    ProductoVendido.Stock = Convert.ToInt32(reader2.GetValue(2));
                    ProductoVendido.IdVenta = Convert.ToInt32(reader2.GetValue(3));
                    

                    listaProductosVendidos.Add(ProductoVendido);

                }
                reader2.Close();
                connection.Close();
            }

            return listaProductosVendidos;

        }










    }
}
