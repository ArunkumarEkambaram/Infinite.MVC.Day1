using Infinite.MVC.Day1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infinite.MVC.Day1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products       
        public ActionResult Index()
        {
            var products = new Product().GetProducts();
            return View(products);
        }

        //GET: Products/Details/1
        public ActionResult Details(int id)
        {
            var product = new Product().GetProducts().FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return View(product);
            }
            return HttpNotFound();
        }
    }
}