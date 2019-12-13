using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Usuarios
    {
        public Usuarios(int UsuarioId, string email, string nombre, string apellido, int edad)
        {
            this.UsuarioId = UsuarioId;
            this.email = email;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }

        public string email { get; set; }
        public int UsuarioId { get; set; }
        public string nombre { get; set; }

        public string apellido { get; set; }
        public int edad { get; set; }

        public Cuentas Cuenta { get; set; }
        public List<Cuentas> Cuentas { get; set; }

    }




}