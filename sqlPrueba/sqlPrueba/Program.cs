using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using System.Data;//Requerido para base de datos
using Entidades2;
  

namespace sqlPrueba
{
    class Program
    {
        static void Main(string[] args)
        {
      List<Televisor> _lista = new List<Televisor>();

      foreach (Televisor item in Televisor.TraerTodos())
      { Console.WriteLine(item.ToString()); }
      Console.ReadKey();

      XmlSerializer serializador = new XmlSerializer(typeof(List<Televisor>));
      XmlTextWriter text = new XmlTextWriter("Televisores.xml", Encoding.UTF8);
      XmlTextReader lectorxml = new XmlTextReader("Televisores.xml");
      serializador.Serialize(text, _lista);
      text.Close();
      SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);// establacela conexion entre mi base de datos y mi aplicacion

      SqlCommand comando = new SqlCommand();

      comando.CommandText = "SELECT * FROM televisores";
      comando.CommandType = System.Data.CommandType.Text;
      comando.Connection = conexion;
      conexion.Open();
      SqlDataReader lector = comando.ExecuteReader();// para leer de la base de datos
      //while (lector.Read())
      //{
      // // Console.WriteLine(lector[0] + "-" + lector[1] + "-" + lector[2] + "-" + lector[3] + "-" + lector[4]);
      //  _lista.Add(new Televisor(lector.GetInt32(0), lector.GetString(1), lector.GetDouble(2), lector.GetInt32(3), lector.GetString(4)));
      //  //Console.WriteLine(lector["id"]);//tiene que coincidir con el nombre en la base de datos
      //}
      List<Televisor> L = (List<Televisor>)serializador.Deserialize(lectorxml);
      Console.ReadKey();

      conexion.Close();

      conexion.Open();
      lector = comando.ExecuteReader();
      DataTable Televisores = new DataTable("Televisores");
      Televisores.Load(lector);

      Televisores.WriteXmlSchema("Televisores_Esquema.xml");
      Televisores.WriteXml("Televisroes_dt.xml");

      DataTable Televisores2 = new DataTable();
      Televisores2.ReadXmlSchema("Televisores_Esquema.xml");
      Televisores2.ReadXml("Televisroes_dt.xml");

      Televisor nuevaTele = new Televisor(6, "Pepa", 2222, 42, "EE.UU");
      //nuevaTele.Insertar();
      // Televisor.Borrar(nuevaTele);
      // nuevaTele.Modificar();
      Televisor.TraerTodos();

    }
    }
}
