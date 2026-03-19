using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteBLL
    {
        // instancia de la clase ClienteDAL
        public ClienteDAL _clienteDAL;

        public int Guardar(Cliente cliente, int id = 0, bool esEdicion = false)
        {
            // inicializar la instancia de ClienteDAL
            _clienteDAL = new ClienteDAL();

            // llamar al metodo Guardar de la clase ClienteDAL
            int resultado = _clienteDAL.Guardar(cliente, id, esEdicion);

            return resultado;
        }

        // obtener el listado de cliente, manipularlo (opcional) retornar el resultado a la vista
        public List<Cliente> ObtenerClientes()
        {
            // inicializar la instancia de ClienteDAL
            _clienteDAL = new ClienteDAL();

            // retornarmos el resultado del metodo MostrarClientes
            return _clienteDAL.MostrarClientes();            
        }
    }
}
