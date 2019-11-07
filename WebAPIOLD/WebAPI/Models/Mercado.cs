using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Mercado
    {
        public Mercado(int id_mercado, double cuota_over, double cuota_under, double dinero_over, double dinero_under, int id_evento)
        {
            Id_mercado = id_mercado;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
            Dinero_over = dinero_over;
            Dinero_under = dinero_under;
            Id_evento = id_evento;
        }

        public int Id_mercado { get; set; }
        public double Cuota_over { get; set; }
        public double Cuota_under { get; set; }
        public double Dinero_over { get; set; }
        public double Dinero_under { get; set; }
        public int Id_evento { get; set; }
    }
}