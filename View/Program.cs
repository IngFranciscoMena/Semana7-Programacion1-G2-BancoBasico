using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class Program
    {
        // instancia de la clase ClienteBLL
        static ClienteBLL _clienteBLL;

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
            // inicializar la instancia de la clase ClienteBLL
            _clienteBLL = new ClienteBLL();

            // obtener los clientes

            var clientes = _clienteBLL.ObtenerClientes();

            foreach (var item in clientes)
            {
                Console.WriteLine(item.Nombres + " " + item.Apellidos);
            }
        }
    }
}
