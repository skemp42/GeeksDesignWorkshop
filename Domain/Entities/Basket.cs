using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Utilities;

namespace Domain.Entities
{
    public class Basket : List<Product>
    {
        public void Purchase()
        {
            foreach (var product in this)
            {
                Inventory.Instance.Decrease(product);
            }

            this.Clear();
        }
    }
}
