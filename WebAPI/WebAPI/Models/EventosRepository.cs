using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
using WebApplication2.Models;

namespace WebApplication1.Models
{


    public class EventosRepository
    {
        internal List<Evento> Retrieve()
        {


            List<Evento> todos = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                todos = context.Eventos.ToList();
            }
            return todos;


        }

        internal List<EventosDTO> RetrieveDTO()
        {
            List<EventosDTO> evento;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.Eventos.Select(p => ToDTO(p)).ToList();
            }
            return evento;
        }

        internal void Save(Evento e)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Eventos.Add(e);
            context.SaveChanges();
        }


        public EventosDTO ToDTO(Evento e)
        {
            return new EventosDTO(e.Local, e.Visitante);
        }

        internal void Update(int id, Evento ev)
        {
            Evento evento;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.Eventos.Where(e => e.EventoId == id).FirstOrDefault();
                evento.Local = ev.Local;
                evento.Visitante = ev.Visitante;
                context.SaveChanges();
            }
        }


        internal void Delete(int EventoId)
        {
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                context.Eventos.Remove(context.Eventos.Where(e => e.EventoId == EventoId).FirstOrDefault());
                context.SaveChanges();
            }
        }

    }

}
