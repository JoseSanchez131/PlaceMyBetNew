using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using WebAPI.Models;
using WebApplication2.Models;

namespace WebApplication1.Models
{

    public class ApuestasRepository
    {


        internal List<Apuesta> Retrieve()
        {

            List<Apuesta> apuestas;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.Include(m => m.Mercado).ToList();
            }
            return apuestas;


        }




        public ApuestasDTO ToDTO(Apuesta a)
        {
            return new ApuestasDTO(a.UsuarioId, a.Mercado.EventoId, a.TipoApuesta, a.Cuota, a.DineroApostado);
        }

        internal List<ApuestasDTO> RetrieveDTO()
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            List<ApuestasDTO> apuestasDTO = new List<ApuestasDTO>();
            

            apuestasDTO = context.Apuestas.Include(a => a.Mercado).Select(m => ToDTO(m)).ToList();
            return apuestasDTO;
        }



        internal Apuesta RetrieveById(int id)
        {
            Apuesta apuestas;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas
                    .Where(s => s.ApuestaId == id)
                    .FirstOrDefault();
            }
            return apuestas;
        }


        internal void Save(Apuesta a)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Apuestas.Add(a);
            context.SaveChanges();

            Mercado mer = new Mercado();
            mer = context.Mercados
                        .Where(m => m.MercadoId == a.MercadoId).FirstOrDefault();


            if (a.TipoApuesta == 0)
            {
                mer.Dinero_under += a.DineroApostado;

            }
            else
            {
                mer.Dinero_over += a.DineroApostado;
            }

            var probabilidadOver = mer.Dinero_over / (mer.Dinero_under + mer.Dinero_over);
            var probabilidadUnder = mer.Dinero_under / (mer.Dinero_over + mer.Dinero_under);

            mer.Cuota_under = Math.Round(Convert.ToDouble((1 / probabilidadOver) * 0.95));
            mer.Cuota_over = Math.Round(Convert.ToDouble((1 / probabilidadUnder) * 0.95));

            context.Mercados.Update(mer);
            context.SaveChanges();
        }

    }
}