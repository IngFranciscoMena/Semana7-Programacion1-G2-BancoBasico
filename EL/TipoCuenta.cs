using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class TipoCuenta
    {
        public int TipoCuentaId { get; set; }
        public string Nombre { get; set; } = "";
        public string Moneda { get; set; } = "USD";
        public bool Activa { get; set; } = true;
    }
}
