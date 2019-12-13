using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class ApuestasController : ApiController
    {
        public IEnumerable<Apuesta> Get()
        {
            var repo = new ApuestasRepository();
            //List<Apuestas> Apuestas = repo.Retrieve();
            List<Apuesta> Apuestas = repo.Retrieve();
            return Apuestas;
        }


        public Apuesta Get(int ApuestaId)
        {
            var repo = new ApuestasRepository();
            Apuesta a = repo.RetrieveById(ApuestaId);
            return a;
        }

        public void Post([FromBody]Apuesta a)
        {
            var repo = new ApuestasRepository();
            repo.Save(a);

        }
    }

}