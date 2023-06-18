using System;
using System.Collections.Generic;
using System.Text;

namespace Venta.Infrastructure.Extentions
{
    public class MenuException: Exception
    {
        public MenuException(string message) : base(message) { 
          
        }
    }
}
