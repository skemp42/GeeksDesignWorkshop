using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Utilities;

namespace Domain.DAL
{
    public static class ProductRepository
    {
        public static IEnumerable<ProductData> GetAll()
        {
            return new List<ProductData>
            {
               new ProductData{
                 Id = 1,
                 Name = "Nightmare before christmas VHS",
                 Type = ProductType.Physical
                },
               new ProductData{
                   Id = 2,
                   Name = "Nike Trainers",
                   Type = ProductType.Physical
               },
               new ProductData{
                   Id = 3,
                   Name = "Ed Sheeran Album (MP3)",
                   Type = ProductType.Digital
               }
            };
        }

        public static ProductData FindById(int id)
        {
            return GetAll().FirstOrDefault(p => p.Id == id);
        }
    }
}
