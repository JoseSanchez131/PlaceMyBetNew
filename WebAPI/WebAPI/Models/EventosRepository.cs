using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebAPI.Models
{
    public class EventosRepository
    {

        internal List<Evento> Retrieve()
        {

            List<Evento> evento = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.Eventos.ToList();
            }

            return evento;

        }


        internal void Save(Evento d)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Eventos.Add(d);
            context.SaveChanges();

        }

    }
}