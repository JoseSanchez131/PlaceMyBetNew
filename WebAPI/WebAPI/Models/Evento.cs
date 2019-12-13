using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Evento
    {

        public int EventoId { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
        public int Goles { get; set; }

        public List<Mercado> Mercados { get; set; }


        public Evento()
        {



        }

        public Evento(int EventoId, string Local, string Visitante, int Goles)
        {
            this.EventoId = EventoId;
            this.Local = Local;
            this.Visitante = Visitante;
            this.Goles = Goles;
        }
    }

public class EventosDTO
    {
        public EventosDTO(string Local, string Visitante)
        {

            this.Local = Local;
            this.Visitante = Local;
        }
        public string Local { get; set; }
        public string Visitante { get; set; }

    }
}