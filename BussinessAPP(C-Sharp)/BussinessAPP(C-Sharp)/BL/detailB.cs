using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAPP_C_Sharp_.BL
{
    class detailB
    {
        public string bookList;
        public string bookAuthur;
        public string bookPublish;
       
        public bool searchBooks(List<detailB> g, string search)
        {

            bool isCheck = false;
            for (int index = 0; index < g.Count; index++)
            {
                if (search == g[index].bookList)
                {
                    isCheck = true;
                    break;
                }
            }
            return isCheck;
        }

        public bool checkRbooks(List<detailB> d, ref string remove, ref string auhtor)
        {
            bool valid = false;
            for (int index = 0; index < d.Count; index++)
            {
                if (remove == d[index].bookList && auhtor == d[index].bookAuthur)
                {

                    d.RemoveAt(index);
                    valid = true;
                    break;
                }
                else
                {
                    valid = false;
                }
            }
            return valid;
        }
    }
}
