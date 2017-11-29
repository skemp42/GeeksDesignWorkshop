using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Utilities;
using Microsoft.AspNetCore.Http;

namespace DesignPatternWorkshop.Models
{
    public static class BasketManager
    {
        public static Basket GetBasket(HttpContext context)
        {
            var basketString = context.Session.GetString("basket");

            if (basketString == null)
                return new Basket();

            return BasketStringDecorator.ConvertFromString(basketString);
        }
    }
}
