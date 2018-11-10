using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades2
{
  public class TvEventsArg: EventArgs
  {

    public DateTime Fecha
    {
      get
      {
        return DateTime.Now;
      }

      set
      {
      }
    }
  }
}
