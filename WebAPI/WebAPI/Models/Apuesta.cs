using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebApplication1.Models
{
    public class Apuesta
    {

        public int ApuestaId { get; set; }


        public int TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public int DineroApostado { get; set; }

        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; }
        public int MercadoId { get; set; }
        public Mercado Mercado { get; set; }

      

        public Apuesta(int ApuestaId, int MercadoId, int UsuarioId, int TipoApuesta, double Cuota, int DineroApostado)
        {
            this.MercadoId = MercadoId;
            this.ApuestaId = ApuestaId;
            this.UsuarioId = UsuarioId;
            this.TipoApuesta = TipoApuesta;
            this.Cuota = Cuota;
            this.DineroApostado = DineroApostado;

        }

    }


    public class ApuestasDTO
        {
            public ApuestasDTO(int UsuariosId, int eventoId, int TipoApuesta, double Cuota, int DineroApostado)
            {
                this.UsuariosId = UsuariosId;
                EventoId = eventoId;
                this.TipoApuesta = TipoApuesta;
                this.Cuota = Cuota;
                this.DineroApostado = DineroApostado;

            }

            public int UsuariosId { get; set; }
            public int EventoId { get; set; }
            public int TipoApuesta { get; set; }
            public double Cuota { get; set; }
            public int DineroApostado { get; set; }

            public Mercado mercado { get; set; }
            public Usuarios Usuario { get; set; }



        }

    }