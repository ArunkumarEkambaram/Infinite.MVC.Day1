using Infinite.MVC.Day1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Infinite.MVC.Day1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context = null;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Products
        //[HttpGet]                
        public ActionResult Index()
        {
            //var products = new Product().GetProducts();
            var products = _context.Products.ToList();
            return View(products);
        }

        //GET: Products/Details/1
        public ActionResult Details(int id)
        {           
            var product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return View(product);
            }
            return HttpNotFound();
        }

        public ActionResult Create()
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            //Product p = new Product
            //{
            //    Categories = categories
            //};
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}