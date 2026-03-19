using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDAL
    {
        // instancia de nuestro DbContext
        BancoDbContext _db;

        // method para guardar un cliente
        public int Guardar(Cliente cliente, int id = 0, bool esEdicion = false)
        {
            int resultado = 0;

            try
            {
                // inicializar nuestro DbContext
                _db = new BancoDbContext();

                if (esEdicion)
                {
                    // vincular el id del cliente al objeto modificado
                    cliente.ClienteId = id; 

                    // indicar que el objeto fue modificado
                    _db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;

                    // guardar los cambios en la BD
                    _db.SaveChanges();
                }
                else
                {
                    // insertar nuestro primer Cliente
                    _db.Clientes.Add(cliente);

                    // guardar los cambios
                    _db.SaveChanges();

                    resultado = cliente.ClienteId;
                }
            }
            catch (Exception ex)
            {
                resultado = -1;
            }

            return resultado;
        }

        // Obtener todos los clientes
        public List<Cliente> MostrarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                // inicializar nuestro DbContext
                _db = new BancoDbContext();

                // Obtener el listado de clientes
                clientes = _db.Clientes.ToList();
            }
            catch (Exception ex)
            {

            }

            return clientes;
        }
    }    
}
