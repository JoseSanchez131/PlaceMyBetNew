using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Apuesta
    {

        public int ApuestaId { get; set; }
        
       
        public int TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public int DineroApostado { get; set; }

        public String UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int MercadoId { get; set; }
        public Mercado Mercado { get; set; }

        public Apuesta ()
        {


        }

        public Apuesta (int ApuestaId, int MercadoId, String UsuarioId, int TipoApuesta, double Cuota, int DineroApostado)
        {
            this.MercadoId = MercadoId;
            this.ApuestaId = ApuestaId;
            this.UsuarioId = UsuarioId;
            this.TipoApuesta = TipoApuesta;
            this.Cuota = Cuota;
            this.DineroApostado = DineroApostado;
            
        }

    }
}
