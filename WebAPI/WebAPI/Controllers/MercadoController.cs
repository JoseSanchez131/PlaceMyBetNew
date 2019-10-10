using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using static WebAPI.Models.Mercado;

namespace WebAPI.Controllers
{
    public class MercadoController : ApiController
    {

        // GET: api/Mercado/
        public IEnumerable <MercadoDTO> Get()
        { 
            var repo = new MercadoRepository();
            // List<Mercado> m = repo.Retrieve();
            List<MercadoDTO> m = repo.RetrieveDTO();
            return m;
        }

        // POST: api/Mercado
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercado/5
        public void Delete(int id)
        {
        }
    }
}
