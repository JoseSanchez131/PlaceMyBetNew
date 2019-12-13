
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
    public class EventosController : ApiController
    {

        public void Post([FromBody]Evento evento)
        {
            var repo = new EventosRepository();
            repo.Save(evento);
        }

        public IEnumerable<EventosDTO> Get()
        {
            var repo = new EventosRepository();
            List<EventosDTO> Evento = repo.RetrieveDTO();
            return Evento;
        }

        public void Put(int EventoId, [FromBody]Evento ev)
        {
            var repo = new EventosRepository();
            repo.Update(EventoId, ev);
        }


        public void Delete(int EventoId)
        {
            var repo = new EventosRepository();
            repo.Delete(EventoId);
        }

    }
}