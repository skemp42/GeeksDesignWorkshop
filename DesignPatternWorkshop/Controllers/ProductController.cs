using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesignPatternWorkshop.Models;
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
            Logger.Log($"Request to add product to basket with id: {id}");
            var product = ProductFactory.CreateProduct(id);
            if (product.StockChecker.GetStock() <= 0)
            {
                Logger.Log($"Product {id} out of stock.");
                ViewData["Error"] = "Out of stock";
                return RedirectToAction("Index");
            }

            var basket = BasketManager.GetBasket(HttpContext);
            basket.Add(product);
            HttpContext.Session.SetString("basket", new BasketStringDecorator(basket).ConvertToString());

            return RedirectToAction("Index");
        }


    }
}