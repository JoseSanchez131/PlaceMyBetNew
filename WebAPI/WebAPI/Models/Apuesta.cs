using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Apuesta
    {
        public Apuesta(int id_apuesta, int id_mercado, string email, double tipo_apuesta, double cuota, int dinero_apostado)
        {
            Id_apuesta = id_apuesta;
            Id_mercado = id_mercado;
            Email = email;
            Tipo_apuesta = tipo_apuesta;
            Cuota = cuota;
            Dinero_apostado = dinero_apostado;
        }

        public int Id_apuesta { get; set; }
        public int Id_mercado { get; set; }
        public string Email { get; set; }
        public double Tipo_apuesta { get; set; }
        public double Cuota { get; set; }
        public int Dinero_apostado { get; set; }
    }

    public class ApuestaDTO
    {
        public ApuestaDTO(string email, double tipo_apuesta, double cuota, int dinero_apostado)
        {
            
            Email = email;
            Tipo_apuesta = tipo_apuesta;
            Cuota = cuota;
            Dinero_apostado = dinero_apostado;
        }

    
        public string Email { get; set; }
        public double Tipo_apuesta { get; set; }
        public double Cuota { get; set; }
        public int Dinero_apostado { get; set; }
    }
}