using BLL;
using EL;
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
                Console.WriteLine("1. Obtener Clientes.");
                Console.WriteLine("2. Crear Cliente.");
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
                        case 2:
                            GuardarCliente();
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

        static void GuardarCliente() 
        {
            // crear un objeto Cliente
            Cliente cliente = new Cliente();

            // ingrese los campos
            Console.WriteLine("Ingresa los nombres del cliente: ");
            cliente.Nombres = Console.ReadLine();

            Console.WriteLine("Ingresa los apellidos del cliente: ");
            cliente.Apellidos = Console.ReadLine();

            Console.WriteLine("Ingresa el documento de identidad del cliente: ");
            cliente.Documento = Console.ReadLine().Trim().Replace("-", "");

            Console.WriteLine("Ingrese el correo del cliente: ");
            cliente.Email = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono del cliente: ");
            cliente.Telefono = Console.ReadLine();

            cliente.FechaRegistro = DateTime.Now;

            // inicializar la instancia de la clase ClienteBLL
            _clienteBLL = new ClienteBLL();

            // llamar al metodo Guardar
            int resultado = _clienteBLL.Guardar(cliente);

            if (resultado > 0)
            {
                Console.WriteLine("Cliente registrado con exito ID: " + resultado);
            }
            else
            {
                Console.WriteLine("Ocurrio un error al guardar el cliente");                
            }
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
