using Dapper;
using EL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewDapper
{
    public class Program
    {

        static readonly string connectionString = "Data Source=DESKTOP-G40T8T8\\SQLEXPRESS;Initial Catalog=BancoBasicoDB;Integrated Security=True;";

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Ingrese Opcion:");
                Console.WriteLine("1. Obtener Clientes");
                Console.WriteLine("0. Salir");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 0:
                            Console.WriteLine("Hast pronto!");
                            return;
                        case 1:
                            ObtenerClientes();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida intentelo de nuevo.");
                }
            }
            while (true);
        }

        static void ObtenerClientes()
        {
            string query = "select * from Clientes";

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    var listado = conn.Query<Cliente>(query).ToList();

                    foreach (var item in listado)
                    {
                        Console.WriteLine(item.Nombres + " " + item.Apellidos);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
