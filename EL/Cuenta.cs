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

        public int ClienteId { get; set; }
        public int TipoCuentaId { get; set; }

        public decimal Saldo { get; set; }
        public EstadoCuenta Estado { get; set; }
        public DateTime FechaApertura { get; set; }
    }
}
