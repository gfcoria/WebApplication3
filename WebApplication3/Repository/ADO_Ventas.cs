using static WebApplication3.Controllers.VentasController;
using System.Data.SqlClient;

namespace WebApplication3.Repository
{
    public class ADO_Ventas
    {
            public static List<Venta> DevolverVentas()
            {
                var listaVentas = new List<Venta>();
                SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
                connectionbuilder.DataSource = "TULUM/SQLEXPRESS";
                connectionbuilder.InitialCatalog = "SistemaGestion";
                connectionbuilder.IntegratedSecurity = true;

                var cs = connectionbuilder.ConnectionString;

                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand cmd2 = connection.CreateCommand();
                    cmd2.CommandText = "Select * from Venta";
                    var reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {
                        var venta = new Venta();
                        venta.Id = Convert.ToInt32(reader2.GetValue(0));
                        venta.Comentarios = reader2.GetValue(1).ToString();
                        venta.IdUsuario = Convert.ToInt32(reader2.GetValue(2));

                        listaVentas.Add(venta);

                    }
                    reader2.Close();
                    connection.Close();
                }

                return listaVentas;

            }


        }
}
