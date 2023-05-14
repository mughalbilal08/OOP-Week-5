using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Week_5.BL
{
    class Product
    {
        public string name;
        public string category;
        public float price;


        public float calculateText(Customer cus)
        {

            List<Product> pro = cus.getAllProduct();

            float tex1 = 0.0f;

            float tex2 = 0.0f;
            float totalTex = 0.0f;
            foreach (Product storeP in pro)
            {
                if (storeP.category == "fruit")
                {
                    tex1 = storeP.price * (10.0f / 100.0f);
                    totalTex = tex1 + totalTex;
                }
                else if (storeP.category == "grocery")
                {
                    tex2 = storeP.price * (5.0f / 100.0f);
                    totalTex = tex2 + totalTex;

                }
            }

            return totalTex;


        }
    }
}
