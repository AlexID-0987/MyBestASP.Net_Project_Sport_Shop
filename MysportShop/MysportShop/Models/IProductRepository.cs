﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public interface IProductRepository
    {
        IQueryable<MyProduct> _Products { get; }
    }
}
//інтерфейс працюючій з базой данних, схожий на IEnumerable<>