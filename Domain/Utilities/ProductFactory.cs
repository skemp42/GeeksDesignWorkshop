using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DAL;
using Domain.Entities;

namespace Domain.Utilities
{
    public static class ProductFactory
    {
        public static Product CreateProduct(int id)
        {
            var data = ProductRepository.FindById(id);

            switch (data.Type)
            {
                case ProductType.Digital:
                    return new Product
                    {
                        Id = id,
                        Name = data.Name,
                        Type = data.Type,
                        StockChecker = new DigitalStockChecker()
                    };
                case ProductType.Physical:
                    return new Product
                    {
                        Id = id,
                        Name = data.Name,
                        Type = data.Type,
                        StockChecker = new PhysicalStockChecker()
                    };
            }

            throw new InvalidOperationException("Unknown type");
        }
    }
}
