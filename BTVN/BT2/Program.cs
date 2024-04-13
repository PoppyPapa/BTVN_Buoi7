using BTVN;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BT2
{
    public class Program
    {
        static void Main(string[] args)
        {
            EnterEmployeeInfo employeeInfo = new EnterEmployeeInfo();
            int choice;
            do
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("********* MENU ********");
                Console.WriteLine("       **********      ");
                Console.WriteLine("1. Thêm thông tin nhân viên.");
                Console.WriteLine("2. Tính toán lương nhân viên.");
                Console.WriteLine("3. Thoát.");
                Console.WriteLine("**********************");
                Console.WriteLine("\nLựa chọn: ");
                string text = Console.ReadLine();
                do
                {
                    
                    if (!Validate.CheckNum(text, out choice) || choice < 0 || choice > 5)
                    {
                        Console.WriteLine("\nPLease, enter again: ");
                        text = Console.ReadLine();
                    }
                    
                }
                while (!Validate.CheckNum(text, out choice) || choice < 0 || choice > 5);
                
                switch (choice)
                {
                    case 1:
                        employeeInfo.EmployeeInfo();
                        break;
                    case 2:
                        employeeInfo.EmployeeSalary();
                        break;
                    case 3:  
                        Console.WriteLine("**** Program End!!! ****");
                        break;
                    default:
                        Console.WriteLine("Nhập lại: ");
                        break;
                }
            }
            while (choice != 3);
        }
       
    }
}