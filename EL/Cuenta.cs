using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EL.Enums;

namespace EL
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public string NumeroCuenta { get; set; } = "";

        // propiedades de navegacion - nombre, apellido, direccion, etc
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int TipoCuentaId { get; set; } // - Nombre
        public TipoCuenta TipoCuenta { get; set; }

        public decimal Saldo { get; set; }
        public EstadoCuenta Estado { get; set; }
        public DateTime FechaApertura { get; set; }
    }
}
