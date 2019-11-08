using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebAPI.Models
{
    public class ApuestaRepository
    {

        internal List<Apuesta> Retrieve()
        {

            List<Apuesta> apuesta = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuesta = context.Apuestas.ToList();
            }

            return apuesta;
            
        }

        internal Apuesta Retrieve(int id)
        {
            Apuesta apuesta;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuesta = context.Apuestas
                    .Where(s => s.ApuestaId == id)
                    .FirstOrDefault();
            }


            return apuesta;
        }

        internal void Save(Apuesta d)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Apuestas.Add(d);
            context.SaveChanges();

        }

    }
}


