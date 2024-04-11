using BTVN;
using System.Text;

namespace Buoi7
{
    public class Program
    {
        static void Main(string[] args)
        {
            Library _library = new Library();
            int choice;
            do
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("\n");
                Console.WriteLine("********* MENU ********");
                Console.WriteLine("       **********      ");
                Console.WriteLine("1. Thêm sách vào thư viện.");
                Console.WriteLine("2. Tìm kiếm theo tên tác giả.");
                Console.WriteLine("3. Tìm kiếm theo mã sách.");
                Console.WriteLine("4. Mượn sách.");
                Console.WriteLine("5. Trả sách.");
                Console.WriteLine("6. Thoát.");
                Console.WriteLine("**********************");
                Console.WriteLine("\nLựa chọn: ");

                string text = Console.ReadLine();
                do
                {
                    if (!Validate.CheckNum(text, out choice) || choice < 1 || choice > 6)
                    {
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        Console.WriteLine("Chọn lại: ");
                        text = Console.ReadLine();
                    }
                }
                while (!Validate.CheckNum(text, out choice) || choice < 1 || choice > 6);

                switch (choice)
                {
                    case 1:
                        _library.AddBook();
                        break;
                    case 2:
                        _library.SearchByAuthor();
                        break;
                    case 3:
                        _library.SearchByISBN();
                        break;
                    case 4:
                        _library.BorrowBook();
                        break;
                    case 5:
                        _library.ReturnBook();
                        break;
                    case 6:
                        Console.WriteLine("**** Program End!!! ****");
                        break;
                    default:
                        Console.WriteLine("Enter again: ");
                        break;
                }
            }
            while (choice != 6);

        }
    }
}
        