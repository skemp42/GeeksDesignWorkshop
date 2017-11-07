using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternWorkshop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
               new Product{
                 Name = "Nightmare before christmas VHS",
                 StockChecker = new PhysicalStockChecker()
                },
               new Product{
                   Name = "Nike Trainers",
                 StockChecker = new PhysicalStockChecker()
               },
               new Product{
                   Name = "Ed Sheeran Album (Digital)",
                   StockChecker = new DigitalStockChecker()
               }
            };

            return View(products);
        }
    }
}