using EL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDALADO
    {
        /*
         * ArrayList, Array, Stack, Queue, List<> 
         *
         */


        // método para obtener el listado de cliente 
        public List<Cliente> ObtenerListadoClientes()
        {
            // crear una lista vacia
            List<Cliente> clientes = new List<Cliente>();

            // select * from Clientes

            // 1. objeto SqlConnection
            SqlConnection conn = new SqlConnection(DbSettings.connectionString); // objeto de conexión SqlClient

            try
            {
                //2. Crear la consulta
                string query = "SP_Seleccionar_Clientes";

                //3. Crear el comando a ejecutar
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //4. Abrir la conexión hacia Sql
                conn.Open();

                //5. Ejecutar el comando y almacenar el resultado
                SqlDataReader reader = cmd.ExecuteReader();

                //6. Procesar el resultado
                while (reader.Read())
                {
                    var cliente = new Cliente() 
                    { 
                        ClienteId = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                        Nombres = reader.GetString(reader.GetOrdinal("Nombres")),
                        Apellidos = reader.GetString(reader.GetOrdinal("Apellidos")),
                        Documento = reader.GetString(reader.GetOrdinal("Documento")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                        FechaRegistro = reader.GetDateTime(reader.GetOrdinal("FechaRegistro"))
                    };

                    //7. Almacenar el objeto en el listado de clientes
                    clientes.Add(cliente);
                }

                //8. cerrar el reader
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally // ayudar a cerrar la conexión
            {
                if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            // retornar el listado de clientes
            return clientes;
        }
    }
}
