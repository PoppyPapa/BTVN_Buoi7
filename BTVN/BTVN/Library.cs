using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN
{
    public class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook()
        {
            Console.WriteLine("Tên đầu sách: ");
            string _Title = Console.ReadLine();
            do
            {
                if (Validate.CheckTitle(_Title))
                {
                    if (!Validate.CheckXSSInput(_Title))
                    {
                        Console.WriteLine("Tên đầu sách nhập vào không hợp lệ!");
                        Console.WriteLine("Mời nhập lại: ");
                        _Title = Console.ReadLine();
                    }
                }
            }
            while (!Validate.CheckTitle(_Title) || !Validate.CheckXSSInput(_Title));

            Console.WriteLine("Tác giả: ");
            string _Author = Console.ReadLine();
            do
            {
                if (!Validate.CheckAuthor(_Author) || !Validate.CheckXSSInput(_Author))
                {
                    Console.WriteLine("Tên tác giả nhập vào không hợp lệ!");
                    Console.WriteLine("Mời nhập lại: ");
                    _Author = Console.ReadLine();
                }
            }
            while (!Validate.CheckAuthor(_Author) || !Validate.CheckXSSInput(_Author));

            Console.WriteLine("Mã số sách: ");
            int _ISBN, _Price, temp;
            string _isbn = Console.ReadLine();
            do
            {
                if (!Validate.CheckNum(_isbn, out _ISBN) || _ISBN < 0)
                {
                    Console.WriteLine("Nhập lại Mã số sách: ");
                    _isbn = Console.ReadLine();
                }
            }
            while (!Validate.CheckNum(_isbn, out _ISBN) || _ISBN < 0);

            Console.WriteLine("Giá tiền: ");
            string _price = Console.ReadLine();
            do
            {
                if (!Validate.CheckNum(_isbn, out _Price) || _Price < 0)
                {
                    Console.WriteLine("Nhập lại Giá tiền: ");
                    _price = Console.ReadLine();
                }
            }
            while (!Validate.CheckNum(_price, out _Price) || _Price < 0);


            books.Add(new Book(_Title, _Author, _ISBN, _Price));
        }
        public void SearchByAuthor()
        {
            Console.WriteLine("Nhập vào tác giả cần tìm: ");
            string searchAuthor = Console.ReadLine();

            ListSearchByAuthor(searchAuthor);
        }
        private List<Book> ListSearchByAuthor(string author)
        {          
            List<Book> authorBooks = books.FindAll(book => book.Author.Equals(author));
            Console.WriteLine($"Books by {author}:");
            int count = 0;
            foreach (Book book in authorBooks)
            {
                Console.WriteLine($"- {book.Title}");
                count++;
            }
            if (count == 0)
            {
                Console.WriteLine($"Tác giả {author} không có trong thư viện!");
            }
            return authorBooks;
        }

        public void SearchByISBN()
        {
            int temp;
            Console.WriteLine("Nhập vào Mã số sách cần tìm: ");
            
            do
            {
                if (!Validate.CheckNum(Console.ReadLine(), out temp) || temp < 0)
                {
                    Console.WriteLine("Nhập lại Mã số sách: ");
                }
            }
            while (!Validate.CheckNum(Console.ReadLine(), out temp) || temp < 0);
            Book foundBook = books.Find(book => book.ISBN == temp);

            if (foundBook != null)
            {
                Console.WriteLine("Book found:");
                Console.WriteLine($"Title: {foundBook.Title}");
                Console.WriteLine($"Author: {foundBook.Author}");
                Console.WriteLine($"ISBN: {foundBook.ISBN}");
                Console.WriteLine($"Price: {foundBook.Price}");
                Console.WriteLine($"Available: {foundBook.Available}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void BorrowBook()
        {
            int temp;
            Console.WriteLine("Nhập vào Mã số sách muốn mượn: ");
            
            temp = int.Parse(Console.ReadLine());
            Book foundBook = books.Find(book => book.ISBN == temp);
            
            if (foundBook != null && foundBook.Available)
            {
                foundBook.Available = false;
                Console.WriteLine($"Sách \"{foundBook.Title}\" được mượn thành công.");
            }
            else
            {
                Console.WriteLine("Không có trong thư viện để mượn.");
            }
        }

        public void ReturnBook()
        {
            int temp;
            Console.WriteLine("Nhập vào Mã số sách muốn trả: ");

            temp = int.Parse(Console.ReadLine());
            Book foundBook = books.Find(book => book.ISBN == temp);

            if (foundBook != null)
            {
                foundBook.Available = true;
                Console.WriteLine($"Trả sách \"{foundBook.Title}\" thành công.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sách.");
            }
        }
    }
}
