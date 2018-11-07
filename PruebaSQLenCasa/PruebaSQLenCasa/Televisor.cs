using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using System.Data;//Requerido para base de datos

namespace PruebaSQLenCasa
{
    public class Televisor
    {
        public int id;
        public string marca;
        public double precio;
        public int pulgadas;
        public string pais;

        public Televisor()
        {

        }

        public Televisor(int id, string marca, double precio, int pulg, string rancho)
        {
            this.id = id;
            this.marca = marca;
            this.precio = precio;
            this.pulgadas = pulg;
            this.pais = rancho;
        }

        public bool Insertar()
        {
            bool retValue = false;
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            SqlCommand comando = new SqlCommand();

            comando.CommandText = "Insert into Televisores values (" + this.id + ",'" + this.marca + "'," + this.precio + "," + this.pulgadas + ",'" + this.pais + "' )";
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
                retValue = true;
            }
            catch (System.Exception)
            {

                throw;
            }


            return retValue;
        }

        public static Boolean Borrar(Televisor tele)
        {
            Boolean retorno = false;
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion); //Se instancia el SqlConnection para poder utilizar la base

            try
            {
                conexion.Open(); //Se abre la conexción con la base

                SqlCommand comandosSQL = new SqlCommand("DELETE FROM Televisores WHERE [codigo] = " + tele.id, conexion); //Se instancia el objeto capaz de ejecutar comandos, pero se cambia la orden, siendo esta vez usada para borrar datos
                /*DELETE borra todo el registro completo, sin importar el campo. De no tener con condicion WHERE, borra TODA LA BASE*/

                int registrosAfectados = comandosSQL.ExecuteNonQuery();
                //Console.WriteLine("RegistrosAfectados: {0}", registrosAfectados);

                if (registrosAfectados > 0)
                { retorno = true; }
            }
            catch (Exception e) { }
            finally { conexion.Close(); }
            return retorno;
        }

        public Boolean Modificar()
        {
            Boolean retorno = false;
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion); //Se instancia el SqlConnection para poder utilizar la base

            try
            {
                conexion.Open(); //Se abre la conexción con la base

                SqlCommand comandosSQL = new SqlCommand("UPDATE Televisores SET [codigo] = " + this.id+ ", [marca] = '" + this.marca + "' , [precio] = " + this.precio + " WHERE [codigo] = 3", conexion); //Se instancia el objeto capaz de ejecutar comandos, pero se cambia la orden, siendo esta vez usada para actualizar datos
                /*UPDATE cambia datos del registro, SET es quien hace los cambios. De nuevo, sin la condición, va a cambiar TODOS LOS REGISTROS DE LA BASE*/

                int registrosAfectados = comandosSQL.ExecuteNonQuery();
                //Console.WriteLine("RegistrosAfectados: {0}", registrosAfectados);

                if (registrosAfectados > 0) { retorno = true; }
            }
            catch (Exception e) { }
            finally { conexion.Close(); }
            return retorno;
        }
    }
}
