using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ApuestaRepository
    {


        private MySqlConnection Connect()
        {

            String connString = "Server=localhost;Port=3306;Database=ejercicio1_accesodatos;Uid=root;password='';SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }

        internal List<Apuesta> Retrieve()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuesta";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta a = null;
                List<Apuesta> apuesta = new List<Apuesta>();
                while (res.Read())
                {

                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetString(2) + " " + res.GetInt32(3) + " " + res.GetDouble(4) + " " + res.GetInt32(5));

                    //a = new Apuesta(res.GetInt32(0), res.GetInt32(1), res.GetString(2), res.GetInt32(3), res.GetDouble(4), res.GetInt32(5));
                }

                con.Close();
                return apuesta;
            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }

        internal List<ApuestaDTO> RetrieveDTO()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuesta";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuesta = new List<ApuestaDTO>();
                while (res.Read())
                {

                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetString(2) + " " + res.GetInt32(3) + " " + res.GetDouble(4) + " " + res.GetInt32(5));

                    a = new ApuestaDTO(res.GetString(2), res.GetInt32(3), res.GetDouble(4), res.GetInt32(5));
                }

                con.Close();
                return apuesta;
            }

            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }

        internal void insertarApuesta(Apuesta a)
        {

            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");

            culInfo.NumberFormat.NumberDecimalSeparator = ".";

            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;


            Debug.WriteLine("apuesta vale " + a);

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into apuesta(id_apuesta,email_fk,id_mercado_fk, tipo_apuesta, cuota, dinero_apostado) values ('"+a.IdApuesta+"','" +a.EmailFk+ "' ,'" +a.IdMercado+ "' ,'" +a.TipoApuesta+ "' ,'" +a.Cuota+ "' ,'" +a.DineroApostado+"');";
            Debug.WriteLine("comando " + command.CommandText);

           

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();

            }
            catch (MySqlException e)
            {

                Debug.WriteLine("Se ha producido un error de conexión");
                con.Close();
            }


            con.Open();

            command.CommandText = "select dinero_apostado_over from mercado where id_mercado=" + a.IdMercado + "; ";

            Debug.WriteLine("COMMAND " + command.CommandText);

            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();
           

            double dineroOver = reader.GetDouble(0);

            reader.Close();

            con.Close();



            con.Open();

            command.CommandText = "select dinero_apostado_under from mercado where id_mercado=" + a.IdMercado + "; ";

            reader = command.ExecuteReader();
           
            reader.Read();

            double dineroUnder = reader.GetDouble(0);

            reader.Close();

            con.Close();

            if(a.TipoApuesta == 1)
            {
                dineroOver = dineroOver + a.DineroApostado;
            }
            else
            {
                dineroUnder = dineroUnder + a.DineroApostado;
            }

            Debug.WriteLine(dineroOver);
            Debug.WriteLine(dineroUnder);

            double po = dineroOver / (dineroOver + dineroUnder);

            double pu = dineroUnder / (dineroUnder + dineroOver);

            Debug.WriteLine(po);
            Debug.WriteLine(pu);

            double co = Convert.ToDouble((1 / po) * 0.95);

            double cu = Convert.ToDouble((1 / pu) * 0.95);



            if (a.TipoApuesta == 1)
            {

                command.CommandText = "update mercado set CUOTA_OVER = '" + co + "', DINERO_APOSTADO_OVER = '" + dineroOver + "' where ID_MERCADO =" + a.IdMercado + ";";

                try

                {

                    con.Open();

                    command.ExecuteNonQuery();



                }

                catch (MySqlException e)

                {

                    Console.WriteLine("Error " + e);

                }

                con.Close();

            }
            else
            {

                command.CommandText = "update mercado set CUOTA_UNDER = '" + cu + "', DINERO_APOSTADO_UNDER = '"+dineroUnder+"' where ID_MERCADO =" + a.IdMercado + "; ";

                try

                {

                    con.Open();

                    command.ExecuteNonQuery();



                }

                catch (MySqlException e)

                {

                    Console.WriteLine("Error " + e);

                }

                con.Close();

            }

        }

      
    }
}