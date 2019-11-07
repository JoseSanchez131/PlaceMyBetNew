using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EventosRepository
    {

        private MySqlConnection Connect()
        {

            String connString = "Server=localhost;Port=3306;Database=ejercicio1_accesodatos;Uid=root;password='';SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal List <Eventos> Retrieve()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from eventos";

            try { 

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Eventos e = null;
                List<Eventos> eventos = new List<Eventos>();
                while (res.Read())
            {

                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetInt32(3));

                e = new Eventos(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetInt32(3));

                    eventos.Add(e);
                }

            con.Close();
            return eventos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }

    }
}