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
        public ClienteDALADO _clienteDAL;

        // obtener el listado de cliente, manipularlo (opcional) retornar el resultado a la vista
        public List<Cliente> ObtenerClientes()
        {
            // inicializar la instancia de ClienteDAL
            _clienteDAL = new ClienteDALADO();

            // expresion lambda
            var listado = _clienteDAL.ObtenerListadoClientes();

            return listado;
        }
    }
}
