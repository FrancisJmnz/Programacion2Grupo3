using System;
using System.Collections.Generic;
using System.Text;

namespace Venta.Infrastructure.Exceptions
{
    public class ventaException : Exception
    {
        public ventaException(string message) : base(message)
        {

        }

    }
}
