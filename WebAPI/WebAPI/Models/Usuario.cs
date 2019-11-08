using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Usuario
    {

        public String UsuarioId { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int Edad { get; set; }

        public Cuenta Cuenta { get; set; }

        public List<Apuesta> Apuesta { get; set; }

        public Usuario ()
            {

            }
    }
}