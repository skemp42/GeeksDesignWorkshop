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
        const string FilePath = "../Data/inventory.json";

        public static IEnumerable<InventoryItem> GetAll()
        {
            return JsonConvert.DeserializeObject<InventoryItem[]>(File.ReadAllText(FilePath));
        }

        public static InventoryItem FindByProductId(int id)
        {
            return GetAll().FirstOrDefault(i => i.ProductId == id);
        }

        public static void UpdateQuantity(int id, int newQty)
        {
            var all = GetAll();
            var product = all.FirstOrDefault(i => i.ProductId == id);
            if (product == null)
                throw new InvalidOperationException("Cannot find any product with id " + id);

            product.Quantity = newQty;
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(all));
        }
    }
}
