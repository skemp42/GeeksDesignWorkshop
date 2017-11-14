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
    public static class InventoryRepository
    {
        public static IEnumerable<InventoryItem> GetAll()
        {
            return JsonConvert.DeserializeObject<InventoryItem[]>(File.ReadAllText("Data/inventory.json"));
        }

        public static InventoryItem FindByProductId(int id)
        {
            return GetAll().FirstOrDefault(i => i.ProductId == id);
        }
    }
}
