using System.Collections.Generic;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EventosController : ApiController
    {
   
        // GET: api/Eventos
        public IEnumerable <Eventos> Get()
        {
            var repo = new EventosRepository();
            List <Eventos> e = repo.Retrieve();
            return e;
        }

        // POST: api/Eventos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
