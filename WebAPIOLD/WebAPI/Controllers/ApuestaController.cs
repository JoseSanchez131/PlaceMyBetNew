using System;
using System.Collections.Generic;
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
        public IEnumerable <Apuesta> Get()
        {
            var repo = new ApuestaRepository();
            List <Apuesta> a = repo.Retrieve();
            return a;
        }

        // POST: api/Apuesta
        public void Post([FromBody]string value)
        {
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
