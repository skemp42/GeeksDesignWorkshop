using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;

namespace Domain.Utilities
{
    public static class InventoryObserver
    {
        static List<IInventoryEventListener> Listeners = new List<IInventoryEventListener>();

        public static void OutOfStock(int productId)
        {
            foreach (var listener in Listeners)
            {
                listener.NotifyOutOfStock(productId);
            }
        }

        public static void RegisterListener(IInventoryEventListener listener)
        {
            Listeners.Add(listener);
        }

    }
}
