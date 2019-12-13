using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebAPI.Models;
using WebApplication2.Models;

namespace WebApplication1.Models
{
    public class MercadosRepository
    {

        internal List<Mercado> Retrieve()
        {
            List<Mercado> todos = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                todos = context.Mercados.ToList();
            }
            return todos;
        }


        public MercadosDTO ToDTO(Mercado m)
        {
            return new MercadosDTO(m.Tipo_mercado, m.Cuota_under, m.Cuota_over);
        }
        internal List<MercadosDTO> RetrieveDTO()
        {
            List<MercadosDTO> mercados;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.Select(p => ToDTO(p)).ToList();
            }
            return mercados;
        }

        internal Mercado RetrieveById(int id)
        {
            Mercado mercados;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercados
                    .Where(s => s.MercadoId == id)
                    .FirstOrDefault();
            }
            return mercados;
        }

        internal void Save(Mercado m)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Mercados.Add(m);
            context.SaveChanges();
        }

     
    }
}