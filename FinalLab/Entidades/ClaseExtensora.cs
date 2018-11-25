using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades {

    public static class ClaseExtensora {

        public static string MostrarBD(this Producto objeto) {

            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);
            conexion.Open();
            Producto aux;
            StringBuilder sb = new StringBuilder();

            try {
    
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM [productosDB].[dbo].[productos]",conexion);
                SqlDataReader sqlRead = sqlCom.ExecuteReader();
               
                
                
                

                while (sqlRead.Read()) {

                    aux = new Producto((string)sqlRead[0], (int)sqlRead[1]);
                    sb.AppendLine(aux.ToString());

                }

                return sb.ToString();

            } catch (Exception) {

                conexion.Close();
                return "Error";

            }

        }

        public static bool AgregarBD(this Producto p)
        {

            Boolean retorno = false;
            SqlConnection connectionSQL = new SqlConnection(Properties.Settings.Default.conexion); //Se instancia el SqlConnection para poder utilizar la base
            try
            {
                connectionSQL.Open(); //Se abre la conexción con la base

                SqlCommand comandosSQL = new SqlCommand("INSERT into [productosDB].[dbo].[productos]([nombre],[stokc]) VALUES ('" + p.nombre + "'," + p.stock + ")", connectionSQL); //Se instancia el objeto capaz de ejecutar comandos, pero se cambia la orden, siendo esta vez usada para agregar algo, no para traer, si el atributo es de tipo string, requiere '' y "".
                int registrosAfectados = comandosSQL.ExecuteNonQuery(); //Ejecutar algo que no es una consulta, devuelve la cantidad de registros afectados

                if (registrosAfectados > 0)
                {/*Se deben cerrar ambas conexiones o habrà problema al intentar volver a leerlos*/
                    //Luego la conexión con la base de datos
                    retorno = true;
                }
            }
            catch (Exception e) { }
            finally { connectionSQL.Close(); }
            return retorno;

        }

    }

}
