using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public int Price { get; set; }  
        public bool Available { get; set; }
        public Book(string _Title, string _Author, int _ISBN, int _Price)
        {
            Title = _Title;
            Author = _Author;
            ISBN = _ISBN;
            Price = _Price;
            Available = true;
        }

        
    }
}
