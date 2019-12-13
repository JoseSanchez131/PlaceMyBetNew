using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Cuentas
    {
        public Cuentas(int CuentaId, string NombreBanco, string NumeroTarjeta, int SaldoActual, int usuariosId)
        {
            this.CuentaId = CuentaId;
            this.NombreBanco = NombreBanco;
            this.NumeroTarjeta = NumeroTarjeta;
            this.SaldoActual = SaldoActual;
            this.UsuariosId = usuariosId;
        }

        public int CuentaId { get; set; }
        public string NombreBanco { get; set; }
        public string NumeroTarjeta { get; set; }
        public int SaldoActual { get; set; }

        public int UsuariosId { get; set; }
        public Usuarios Usuarios { get; set; }



    }
}