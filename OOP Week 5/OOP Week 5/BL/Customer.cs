using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Week_5.BL
{
    class Customer
    {
        public string custmerName;
        public string custmerAdress;
        public string custmerContact;
        public List<Product> products = new List<Product>();
        public Customer()
        {

        }
        public List<Product> getAllProduct()
        {
            return products;
        }
        public void storeInList(Product p)
        {
            products.Add(p);

        }
    }
}
