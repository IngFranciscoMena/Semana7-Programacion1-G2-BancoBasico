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
        public int Guardar(Cliente cliente, int id = 0, bool isUpdate = false)
        {
            int resultado = 0;

            try
            {
                // inicializar nuestro DbContext
                _db = new BancoDbContext();

                if (isUpdate)
                {

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


    }
}
