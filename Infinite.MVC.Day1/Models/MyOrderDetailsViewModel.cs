using System.Collections.Generic;

namespace Infinite.MVC.Day1.Models
{
    public class MyOrderDetailsViewModel
    {        
        public string CustomerName { get; set; }
        public List<Product> Products { get; set; }
    }
}