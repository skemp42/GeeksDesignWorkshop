using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DAL;
using Domain.Entities;
using Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

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
            return RedirectToAction("Index");
        }
    }
}