﻿using System;
using System.Collections.Generic;
using System.Text;
using Venta.Domain.Entity;
using Venta.Domain.Repository;
namespace Venta.Domain.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity() { 
        this.CreationDate = DateTime.Now;
        this.Deleted = false;
        } 

        public DateTime? CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int CreationUser { get; set; }
        public int? UserMod { get; set; }
        public int? UserDelete { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }

    }
}
