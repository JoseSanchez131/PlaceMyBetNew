using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using static WebAPI.Models.Mercado;

namespace WebAPI.Models
{
    public class MercadoRepository
    {
        internal List<Mercado> Retrieve()
        {

            List<Mercado> mercado = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados.ToList();
            }

            return mercado;

        }

        internal Mercado Retrieve(int id)
        {
            Mercado mercado;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados
                    .Where(s => s.MercadoId == id)
                    .FirstOrDefault();
            }


            return mercado;
        }

        internal void Save(Mercado d)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Mercados.Add(d);
            context.SaveChanges();

        }

    }
}