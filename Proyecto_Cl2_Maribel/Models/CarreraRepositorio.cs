using Microsoft.Data.SqlClient; //para los sp
using System.Data; // para los tipos de sp (command)

namespace Proyecto_Cl2_Maribel.Models
{
    public class CarreraRepositorio : ICarrera
    {
        string cadena; // 1. variable donde esta nuestra cadena de conexion

        // 2. Constructor donde inicializamos la conexion
        public CarreraRepositorio()
        {
            cadena = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("connection");
        }


        public IEnumerable<Carrera> GetCarreras()
        {
            List<Carrera> carreras = new List<Carrera>();
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                //sp para obtener carreras
                SqlCommand command = new SqlCommand("sp_GetCarreras", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    carreras.Add(new Carrera
                    {
                        idCarrera = dr.GetInt32(0),
                        nombreCarrera = dr.GetString(1),
                    });
                }

            }
            return carreras;
        }
    }
}
