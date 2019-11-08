using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Mercado
    {
    
            public int MercadoId { get; set; }
            public int Tipo_mercado { get; set; }
            public double Cuota_over { get; set; }
            public double Cuota_under { get; set; }
            public double Dinero_over { get; set; }
            public double Dinero_under { get; set; }
            public int EventoId { get; set; }
            public Evento Evento { get; set; }

            public List<Apuesta> Apuestas { get; set; }

        public Mercado()
        {


        }

        public Mercado (int MercadoId, int Tipo_mercado, double Cuota_over, double Cuota_under, double Dinero_over, double Dinero_under, int EventoId)
        {
            this.MercadoId = MercadoId;
            this.Tipo_mercado = Tipo_mercado;
            this.Cuota_over = Cuota_over;
            this.Cuota_under = Cuota_under;
            this.Dinero_over = Dinero_over;
            this.Dinero_under = Dinero_under;
            this.EventoId = EventoId;
        }
    }
    }