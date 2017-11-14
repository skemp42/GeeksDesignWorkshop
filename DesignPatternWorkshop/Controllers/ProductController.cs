using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DAL;
using Domain.Entities;
using Domain.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DesignPatternWorkshop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductRepository.GetAll();

            return View(products);
        }

        [HttpPost]
        public IActionResult AddToBasket([FromForm] int id)
        {
            var product = ProductFactory.CreateProduct(id);
            if (product.StockChecker.GetStock() <= 0)
            {
                ViewData["Error"] = "Out of stock";
                return RedirectToAction("Index");
            }

            var basket = GetBasket();
            basket.Add(product);
            HttpContext.Session.SetString("basket", new BasketStringDecorator(basket).ConvertToString());

            return RedirectToAction("Index");
        }

        private Basket GetBasket()
        {
            var basketString = HttpContext.Session.GetString("basket");

            if (basketString == null)
                return new Basket();

            return BasketStringDecorator.ConvertFromString(basketString);
        }
    }
}