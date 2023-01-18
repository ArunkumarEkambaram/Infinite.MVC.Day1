﻿using System;
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
        private readonly ApplicationDbContext _context = null;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customers/Index
        public ViewResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        //Customers/Details/1
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                return View(customer);
            }
            return HttpNotFound();
        }

    }
}