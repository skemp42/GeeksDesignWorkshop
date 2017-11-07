using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Product
    {
        public string Name { get; set; }

        public IStockChecker StockChecker { get; set; }

    }
}
