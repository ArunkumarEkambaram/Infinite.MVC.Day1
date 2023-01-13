using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infinite.MVC.Day1.Models;

namespace Infinite.MVC.Day1.Controllers
{
    [RoutePrefix("Customers")]
    public class CustomersController : Controller
    {
        // GET: Customers/Index
        public ViewResult Index()
        {
            Customer customer = new Customer();
            List<Customer> customers = customer.GetCustomers();
            return View(customers);
        }

        //Customers/Details/1
        public ActionResult Details(int id)
        {
            Customer customerObj = new Customer();
            var customer = customerObj.GetCustomers().FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                return View(customer);
            }
            return HttpNotFound();
        }
        
        //CUstomers/MyOrders/1001
        public ActionResult MyOrders(int id)
        {
            Product p = new Product();
            //MyOrderDetailsViewModel vm = new MyOrderDetailsViewModel
            //{
            //    CustomerName = new Customer().GetCustomers().FirstOrDefault(c => c.Id == id).Name,
            //    Products = new Product().GetProducts()
            //    //Products = p.GetProducts()
            //};

            MyOrderDetailsViewModel vm = new MyOrderDetailsViewModel();
            vm.CustomerName = new Customer().GetCustomers().FirstOrDefault(c => c.Id == id)?.Name;
            if (vm.CustomerName == null)
            {
                return HttpNotFound("Customer Id doesn't exists");
            }
            vm.Products = new Product().GetProducts();

            return View(vm);
        }

    }
}