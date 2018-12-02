using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesPracticaPreRecuperatorio
{
    public delegate void ElementoAgregado(object o, CartucheraEventArgs e);
    public delegate List<Utiles> obtenerBD();
    [XmlInclude(typeof(Lapicera))]
    [XmlInclude(typeof(Goma))]
    [Serializable]
    [XmlType("Cartuchera")] // sirve para ponerle nombres a las clases a ser serializadas.
   public class Cartuchera<T>: ISerializar
    {
        public string _marca;
        public Byte _capacidad;
        public List<T> elementos;
        public event obtenerBD eventoCartuchera;
        public event ElementoAgregado ElementoAgregadoEvent;

        public List<T> Elementos
        {
            get { return elementos; }
            set { elementos = value; }
        }

        

        public Cartuchera(byte capacidad) : this()
        {
            
            this._capacidad = capacidad;
        }

        public Cartuchera()
        {
            
            this.Elementos = new List<T>();
          
            
                    
        }


        public static implicit operator Cartuchera<T>(byte capacidad)
        {
            return new Cartuchera<T>(capacidad);
        }

        public void Add(T a)
        {
            if (this._capacidad > this.elementos.Count)
            {
                
                this.Elementos.Add(a);
              
                
               
            }
            else
            {
                throw new CarucheraLlenaExeption();

            }

        }

        public bool Remobe(T a)
        {
            bool retorno = false;
            foreach (T item in this.Elementos)
            {
                if (item.Equals(a))
                {
                    this.Elementos.Remove(a);
                    retorno= true;
                }
                
            }
            return retorno;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" Capacidad: " + this._capacidad);
            sb.AppendLine(" Marca: "+this._marca);
            foreach (T item in this.Elementos)
            {
                sb.AppendFormat(item.ToString()+"\n");
            }
            return sb.ToString();
        }

        public bool SerializarXml(string ruta)
        {
           try
            {

                XmlSerializer serializer = new XmlSerializer(typeof(Cartuchera<Utiles>));
                TextWriter tw = new StreamWriter(ruta);
                serializer.Serialize(tw, this);
                tw.Close();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;

            }

        }

        public bool DeserializarXml(string ruta)
        {

            StreamReader tr = new StreamReader(ruta);
            Cartuchera<Utiles> cartuchera = 1;
                try
            {

                XmlSerializer serializer = new XmlSerializer(this.GetType());
                cartuchera = (Cartuchera<Utiles>)serializer.Deserialize(tr);

                Console.WriteLine(cartuchera.ToString());
                Console.ReadKey();
                tr.Close();
                return true;

            }
            catch (Exception e)
            {

                tr.Close();
               
                return false;

            }
        }


            public List<Utiles> obtenerUtilesBD()
            {

                List<Utiles> listaRetorno = new List<Utiles>();

                try
                {
                    SqlConnection connectionSQL = new SqlConnection(Properties.Settings.Default.Conexion); //requiere string de collecion, que tiene ciertos parametros para hacer la conexión, eso es una serie de caracteres a modo de cadena con permisos, etc.
                    /*Properties.Settings.Default.conexion permite acceder a las propiedades del proyecto y la aplicacion*/

                    connectionSQL.Open(); //Esto requiere el objeto instanciado, abre la conexion a la base de datos
                    /*A partir de aqui se debe usar el lenguaje de SQL*/
                    SqlCommand comandosSQL = new SqlCommand("SELECT * FROM [Utiles].[dbo].[elementos]", connectionSQL); //Pide string a ejecutar (los comandos de consulta de SQL en modo de cadena) y el objeto de conexion
                    SqlDataReader sqlRead = comandosSQL.ExecuteReader(); //No tiene constructor accesible, solo puede asignarse por este comando, ExecuteReader ejecuta el comando que estaba en el parametro al instanciarl*/
                     
                    while (sqlRead.Read()) //Mientras el dataReader tenga objetos para leer
                    {
                        if (sqlRead["tipo"].ToString().CompareTo("1") == 0)
                        { 
                           Lapicera lapicera = new Lapicera(sqlRead["marca"].ToString(),Convert.ToDouble(sqlRead["precio"]), sqlRead["color"].ToString(), sqlRead["trazo"].ToString());
                           listaRetorno.Add(lapicera);
                            if (lapicera._precio > 53)
                            {
                                this.ElementoAgregadoEvent(this, new CartucheraEventArgs(lapicera.ToString()));
                            }
                        }
                        else {
                            Goma goma = new Goma(sqlRead["marca"].ToString(), Convert.ToDouble(sqlRead["precio"]), true);
                            listaRetorno.Add(goma);
                            if (sqlRead["soloLapiz"].ToString().CompareTo("1") == 0)
                                goma.soloLapiz = true;
                            else
                                goma.soloLapiz = false;
                           
                            if (goma._precio > 53)
                            {
                                this.ElementoAgregadoEvent(this, new CartucheraEventArgs(goma.ToString()+DateTime.Now.ToString()));
                            }
                        }
                       
                       // Console.WriteLine(sqlRead["id"].ToString() + " " + sqlRead["marca"].ToString() + " " + sqlRead["precio"].ToString() + " " + sqlRead["color"].ToString() + " " + sqlRead["trazo"].ToString() + " " + sqlRead["soloLapiz"].ToString() + " " + sqlRead["tipo"].ToString());
                    }

                    /*Se deben cerrar ambas conexiones o habrà problema al intentar volver a leerlos*/
                    sqlRead.Close(); //Primero el SqlDataReader
                    connectionSQL.Close(); //Luego la conexión con la base de datos
                }
                catch (Exception e) { Console.WriteLine(e.Message); }

                return listaRetorno;
            }

           
           

     }
}
