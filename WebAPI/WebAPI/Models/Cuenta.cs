using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Cuenta
    {
        public String CuentaId { get; set; }
        public String SaldoActual { get; set; }
        public String NombreBanco { get; set; }
        public int NumeroTarjeta { get; set; }

        public String UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Cuenta ()
        { }
    }
}