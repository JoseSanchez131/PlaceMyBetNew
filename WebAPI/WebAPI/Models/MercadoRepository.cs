using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using static WebAPI.Models.Mercado;

namespace WebAPI.Models
{
    public class MercadoRepository
    {


        private MySqlConnection Connect()
        {

            String connString = "Server=localhost;Port=3306;Database=ejercicio1_accesodatos;Uid=root;password='';SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal List < Mercado> Retrieve()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";

        try { 
            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Mercado m = null;
                List<Mercado> mercado = new List<Mercado>();
            while (res.Read())
            {

                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " "+ res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetInt32(6));

                m = new Mercado(res.GetInt32(0), res.GetInt32(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));

                    mercado.Add(m);
            }

            con.Close();
            return mercado;

            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }

        internal List<MercadoDTO> RetrieveDTO()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadoDTO m = null;
                List<MercadoDTO> mercado = new List<MercadoDTO>();
                while (res.Read())
                {

                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetInt32(6));

                    m = new MercadoDTO(res.GetInt32(1), res.GetInt32(2), res.GetDouble(3));

                    mercado.Add(m);
                }

                con.Close();
                return mercado;

            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }

        }


    }
}