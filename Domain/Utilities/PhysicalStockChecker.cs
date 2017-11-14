using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DAL;
using Domain.Interfaces;

namespace Domain.Utilities
{
    public class PhysicalStockChecker : IStockChecker
    {
        public int ProductId { get; private set; }
        public PhysicalStockChecker(int productId)
        {
            ProductId = productId;
        }

        public int GetStock()
        {
            var item = InventoryRepository.FindByProductId(ProductId);
            return item.Quantity;
        }
    }
}
