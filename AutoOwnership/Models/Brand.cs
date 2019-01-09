﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoOwnership.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Model> Models { get; set; }


    }
}