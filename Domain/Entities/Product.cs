using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Product : ProductData
    {
        [JsonIgnore]
        public IStockChecker StockChecker { get; set; }
    }

}
