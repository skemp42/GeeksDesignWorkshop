using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DAL;
using Domain.Entities;

namespace Domain.Utilities
{
    public class Inventory
    {
        private static Inventory instance;

        private Inventory() { }

        public static Inventory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Inventory();
                }

                return instance;
            }
        }

        internal void Decrease(Product product)
        {
            if (product.Type == ProductType.Digital)
                return;

            var item = InventoryRepository.FindByProductId(product.Id);

            if (item.Quantity == 0)
                return;

            InventoryRepository.UpdateQuantity(product.Id, item.Quantity - 1);

            if (item.Quantity == 1)
            {
                InventoryObserver.OutOfStock(product.Id);
            }
        }
    }



}
