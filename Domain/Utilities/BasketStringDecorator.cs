using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Newtonsoft.Json;

namespace Domain.Utilities
{
    public class BasketStringDecorator
    {
        public Basket Basket { get; private set; }

        public BasketStringDecorator(Basket basket)
        {
            Basket = basket;
        }

        public string ConvertToString()
        {
            return JsonConvert.SerializeObject(Basket);
        }

        public static Basket ConvertFromString(string basketStr)
        {
            return JsonConvert.DeserializeObject<Basket>(basketStr);
        }
    }
}
