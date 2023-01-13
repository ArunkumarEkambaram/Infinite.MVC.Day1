using System.Collections.Generic;

namespace Infinite.MVC.Day1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }

        public List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id=1001, Name="Balaji", MobileNo="7894561230"},
                new Customer{Id=1001, Name="Kamal", MobileNo="7894568830"},
                new Customer{Id=1003, Name="Jameel", MobileNo="7894561266"},
                new Customer{Id=1004, Name="Pradeep", MobileNo="6894561230"},
                new Customer{Id=1005, Name="Bathri", MobileNo="9994561230"}
            };
        }
    }


}