using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Week_5.BL
{
    class Books
    {
        public string author;
        public int pages;
        public int bookMark;
        public List<string> chapter;
        public int price;



        public Books(string author, int pages, List<string> chapter, int price)
        {
            this.author = author;
            this.pages = pages;
            this.chapter = chapter;
            this.price = price;

        }
        public string getChapter(int chapterNo)
        {
            if (chapterNo < 1 && chapterNo > chapter.Count)
            {
                return "invalid chapter name";
            }
            else
                return chapter[chapterNo - 1];
        }
        public int getBookMark()
        {
            if (bookMark > -1)
            {
                return bookMark;
            }
            else
                return -1;
        }
        public void setBookPrice(int newPrice)
        {
            price = newPrice;
        }
        public int getPrice()
        {
            return price;
        }
        public void setBookMark(int bookMark)
        {
            this.bookMark = bookMark;
        }
    }
}
