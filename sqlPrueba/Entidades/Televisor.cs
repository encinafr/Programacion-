using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using System.Data;//Requerido para base de datos



namespace sqlPrueba
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

            comando.CommandText = "Insert into Televisores values ("+this.id+",'"+this.marca+"',"+this.precio+","+this.pulgadas+",'"+this.pais+"' )";
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

    public bool Modificar()
    {
      bool retorno = false;
      SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);//Se instancia el SqlConnection para poder utilizar la base

      try
      {
        conexion.Open(); //Se abre la conexción con la base

        SqlCommand comandosSQL = new SqlCommand("UPDATE Televisores SET [codigo] = " + this.id + ", [marca] = '" + this.marca + "' , [precio] = " + this.precio + " WHERE [codigo] = "+this.id, conexion); //Se instancia el objeto capaz de ejecutar comandos, pero se cambia la orden, siendo esta vez usada para actualizar datos
                                                                                                                                                                                                    /*UPDATE cambia datos del registro, SET es quien hace los cambios. De nuevo, sin la condición, va a cambiar TODOS LOS REGISTROS DE LA BASE*/

        int registrosAfectados = comandosSQL.ExecuteNonQuery();
        //Console.WriteLine("RegistrosAfectados: {0}", registrosAfectados);

        if (registrosAfectados > 0) { retorno = true; }
      }
      catch (Exception e) { }
      finally { conexion.Close(); }
      return retorno;
    }


    public static List<Televisor> TraerTodos()
    {
      List<Televisor> listaRetorno = new List<Televisor>();

      try
      {
        SqlConnection connectionSQL = new SqlConnection(Properties.Settings.Default.Conexion); //requiere string de collecion, que tiene ciertos parametros para hacer la conexión, eso es una serie de caracteres a modo de cadena con permisos, etc.
                                                                                               /*Properties.Settings.Default.conexion permite acceder a las propiedades del proyecto y la aplicacion*/

        connectionSQL.Open(); //Esto requiere el objeto instanciado, abre la conexion a la base de datos
                              /*A partir de aqui se debe usar el lenguaje de SQL*/
        SqlCommand comandosSQL = new SqlCommand("SELECT [codigo],[marca],[precio],[pulgadas],[pais] FROM [Productos].[dbo].[Televisores]", connectionSQL); //Pide string a ejecutar (los comandos de consulta de SQL en modo de cadena) y el objeto de conexion
        SqlDataReader dataReaderSQL = comandosSQL.ExecuteReader(); //No tiene constructor accesible, solo puede asignarse por este comando, ExecuteReader ejecuta el comando que estaba en el parametro al instanciarl*/

        while (dataReaderSQL.Read()) //Mientras el dataReader tenga objetos para leer
        {
          //string string1 = dataReaderSQL[0].ToString(); /*el [0] es el orden de cambios EN LA CONSULTA, esto retorna un object encapsulado, debido a que pueden variar los tipos. Esto es un array indexado*/
          //int id = ((int)dataReaderSQL["id"]); /*Array asociativo de SQL*/          
          listaRetorno.Add(new Televisor(((int)dataReaderSQL["codigo"]), dataReaderSQL["marca"].ToString(), (double)dataReaderSQL["precio"], ((int)dataReaderSQL["pulgadas"]),dataReaderSQL["pais"].ToString())); //Por cada objeto leido, añadelo a la lista, utilizando como parametros lo obtenido del dataReader y casteado a su respectivo tipo
        }

        /*Se deben cerrar ambas conexiones o habrà problema al intentar volver a leerlos*/
        dataReaderSQL.Close(); //Primero el SqlDataReader
        connectionSQL.Close(); //Luego la conexión con la base de datos
      }
      catch (Exception e) { Console.WriteLine(e.Message); }

      return listaRetorno;
    }

  }
}
