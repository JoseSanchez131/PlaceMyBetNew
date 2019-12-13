using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class MercadosController : ApiController
    {
        /* public IEnumerable<Mercados> Get()
         {
             var repo = new MercadosRepository();
             List<Mercados> Mercados = repo.Retrieve();
             return Mercados;
         }*/

        public IEnumerable<MercadosDTO> Get()
        {
            var repo = new MercadosRepository();
            List<MercadosDTO> Mercados = repo.RetrieveDTO();
            return Mercados;
        }

        public Mercado Get(int MercadoId)
        {
            var repo = new MercadosRepository();
            Mercado m = repo.RetrieveById(MercadoId);
            return m;
        }

        public void Post([FromBody]Mercado m)
        {
            var repo = new MercadosRepository();
            repo.Save(m);
        }

    }
}