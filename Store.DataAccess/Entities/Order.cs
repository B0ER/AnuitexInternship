﻿using Store.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.DataAccess.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime Date { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
