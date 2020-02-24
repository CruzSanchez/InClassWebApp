using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InClassDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace InClassDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        //GET {controller}
        public IActionResult Index()
        {
            var products = _repo.GetAllProducts();
            return View(products);
        }

        //GET {controller}/{action}/{id}        
        public IActionResult ViewProduct(int id)
        {
            var product = _repo.GetProductById(id);
            return View(product);
        }

        
        //POST {controller}/{action}
        public IActionResult Create(Product p)
        {
            _repo.CreateProduct(p);
            return RedirectToAction("Index");
            //return View();
        }

        public IActionResult NewProduct()
        {
            return View();
        }
    }
}