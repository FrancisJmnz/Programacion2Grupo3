using System;
using System.Collections.Generic;
using System.Text;

namespace Venta.Domain.Core
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.CreationDate = DateTime.Now;
            this.Deleted = false;
        }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int CreationUser { get; set; }
        public int? UserMod { get; set; }
        public int? UserDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
