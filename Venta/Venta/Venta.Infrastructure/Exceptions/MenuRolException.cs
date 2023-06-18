using System;
using System.Collections.Generic;
using System.Text;

namespace Venta.Infrastructure.Extentions
{
    public  class MenuRolException :Exception
    {
        public MenuRolException(string message): base(message) { 

        }
    }
}
