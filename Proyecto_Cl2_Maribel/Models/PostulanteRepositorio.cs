using Microsoft.Data.SqlClient; //para los sp
using System.Data; // para los tipos de sp (command)


namespace Proyecto_Cl2_Maribel.Models
{
    public class PostulanteRepositorio : IPostulante
    {
        string cadena; // 1. variable donde esta nuestra cadena de conexion

        // 2. Constructor donde inicializamos la conexion
        public PostulanteRepositorio()
        {
            cadena = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("connection");
        }


        public IEnumerable<Postulante> GetPostulantes()
        {
            //3. Agregamos nuestra lista de postulante
            List<Postulante> postulantes = new List<Postulante>();

            // 4. Agregamos la cadena de conexion
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                //sp para pbtener categoria clientes
                SqlCommand command = new SqlCommand("sp_GetPostulantes", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    postulantes.Add(new Postulante
                    {
                        idPostulante = dr.GetInt32(0),
                        dniPostulante = dr.GetString(1),
                        nombresPostulante = dr.GetString(2),
                        apellidosPostulante = dr.GetString(3),
                        nombreColegio = dr.GetString(4),
                        anioEgreso = dr.GetInt32(5),
                        nombreCarrera = dr.GetString(6)
                    });
                }

            }

            //5 . retornamos la lista de postulantes
            return postulantes;
        }

        // 6. IMPLEMENTAMOS EL metodo agregar :
        public string Agregar(Postulante postulante)
        {
            string mensaje = "";

            using (SqlConnection connection = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertPostulante", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmDniPostulante", postulante.dniPostulante);
                    cmd.Parameters.AddWithValue("@prmNombresPostulante", postulante.nombresPostulante);
                    cmd.Parameters.AddWithValue("@prmApellidosPostulante", postulante.apellidosPostulante);
                    if (postulante.nombreColegio != null)
                    {
                        cmd.Parameters.AddWithValue("@prmNombreColegio", postulante.nombreColegio);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@prmNombreColegio", " ");
                    }

                    cmd.Parameters.AddWithValue("@prmAnioEgreso", postulante.anioEgreso);
                    cmd.Parameters.AddWithValue("@prmIdCarrera", postulante.idCarrera);

                    connection.Open();
                    int filas = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha agregado {filas} postulante.";
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }

            }

            return mensaje;
        }


        public string Editar(Postulante postulante)
        {
            string mensaje = "";

            using (SqlConnection connection = new SqlConnection(cadena))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_UpdatePostulante", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmIdPostulante", postulante.idPostulante);
                    cmd.Parameters.AddWithValue("@prmDniPostulante", postulante.dniPostulante);
                    cmd.Parameters.AddWithValue("@prmNombresPostulante", postulante.nombresPostulante);
                    cmd.Parameters.AddWithValue("@prmApellidosPostulante", postulante.apellidosPostulante);
                    if (postulante.nombreColegio != null)
                    {
                        cmd.Parameters.AddWithValue("@prmNombreColegio", postulante.nombreColegio);
                    }
                    else 
                    { 
                        cmd.Parameters.AddWithValue("@prmNombreColegio", " "); 
                    }
                        
                    cmd.Parameters.AddWithValue("@prmAnioEgreso", postulante.anioEgreso);
                    cmd.Parameters.AddWithValue("@prmIdCarrera", postulante.idCarrera);


                    connection.Open();
                    int filas = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha editado {filas} postulante.";
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }

            }

            return mensaje;
        }

        public string Delete(Postulante postulante)
        {
            string mensaje = "";

            using (SqlConnection connection = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DeletePostulante", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmIdPostulante", postulante.idPostulante);

                    connection.Open();
                    int filas = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha editado {filas} postulante.";
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }

            }

            return mensaje;
        }
    }
}
