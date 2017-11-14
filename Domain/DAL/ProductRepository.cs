using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Utilities;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace Domain.DAL
{
    public static class ProductRepository
    {
        public static IEnumerable<ProductData> GetAll()
        {
            return JsonConvert.DeserializeObject<ProductData[]>(File.ReadAllText("Data/products.json"));
        }

        public static ProductData FindById(int id)
        {
            return GetAll().FirstOrDefault(p => p.Id == id);
        }
    }
}
