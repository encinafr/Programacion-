using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesPracticaPreRecuperatorio
{
   public interface ISerializar
    {
        bool SerializarXml(string ruta);
        bool DeserializarXml(string ruta);
    }
}
