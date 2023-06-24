using System;
using System.Collections.Generic;
using System.Text;

namespace Venta.Application.Dtos
{
    public abstract class DtoBase
    {
        public DateTime ChangeDate { get; set; }
        public int ChangeUser { get; set; }
    }
}
