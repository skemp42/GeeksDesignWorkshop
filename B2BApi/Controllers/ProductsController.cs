using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DAL;
using Domain.Entities;
using Domain.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace B2BApi.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public IEnumerable<ProductData> Get()
        {
            return ProductRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, string q, int n)
        {
            var product = ProductRepository.FindById(id);

            if (product == null)
                return NotFound();

            if (q == null)
                return Ok(product);

            switch (q)
            {
                case "canbuy":
                    return Ok(CanBuy(product, n));
                default:
                    return BadRequest();
            }

        }

        private bool CanBuy(ProductData productData, int n)
        {
            var product = ProductFactory.CreateProduct(productData.Id);

            return product.StockChecker.GetStock() >= n;
        }
    }
}
