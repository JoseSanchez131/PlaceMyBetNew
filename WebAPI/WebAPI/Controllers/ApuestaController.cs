using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ApuestaController : ApiController
    {
     
        // GET: api/Apuesta/
        public IEnumerable <ApuestaDTO> Get()
        {
            var repo = new ApuestaRepository();
            // List <Apuesta> a = repo.Retrieve();
            List<ApuestaDTO> a = repo.RetrieveDTO();
            return a;
        }

        // POST: api/Apuesta
        public void Post([FromBody]Apuesta apuesta)
        {
            Debug.WriteLine("DENTRO de post apuesta vale " + apuesta);
            var repo = new ApuestaRepository();
            repo.insertarApuesta(apuesta);
        }

        // PUT: api/Apuesta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuesta/5
        public void Delete(int id)
        {
        }
    }
}
