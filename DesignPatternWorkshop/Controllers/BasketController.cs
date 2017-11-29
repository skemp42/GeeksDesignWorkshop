using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesignPatternWorkshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternWorkshop.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            var basket = BasketManager.GetBasket(HttpContext);
            return View(basket);
        }

        public IActionResult Purchase()
        {
            var basket = BasketManager.GetBasket(HttpContext);
            basket.Purchase();
            return RedirectToAction("Index");
        }
    }
}