﻿using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Store.DataAccess.Entities.Interfaces;

namespace Store.DataAccess.Entities
{
    public class Role : IdentityRole<long>, IBaseEntity
    {
        public DateTime CreationDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}
