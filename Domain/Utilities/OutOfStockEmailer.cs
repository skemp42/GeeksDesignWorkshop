using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Domain.Interfaces;

namespace Domain.Utilities
{
    public class OutOfStockEmailer : IInventoryEventListener
    {
        public void NotifyOutOfStock(int productId)
        {
            Debug.WriteLine($"Email: Product {productId} is out of stock");
        }
    }
}
