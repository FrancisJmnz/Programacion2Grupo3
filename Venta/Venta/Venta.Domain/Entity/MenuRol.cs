using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Venta.Domain.Core;

namespace Venta.Domain.Entity
{
    public class MenuRol:BaseEntity
    {
        [Key]
        public int idMenuRol { get; set; }
        public int? idMenu { get; set; }
        public int? idRol { get; set; }
        

    }
}
