using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BTVN
{
    public class EnterEmployeeInfo
    {
        private List<Employee> _employees;

        public EnterEmployeeInfo()
        {
            _employees = new List<Employee>();
        }

        public void EmployeeInfo()
        {
            

            Console.Write("Nhập số lượng nhân viên: ");
            string n = Console.ReadLine();
            int num;
            do
            {
                if (!Validate.CheckNum(n, out num) || num < 0)
                {
                    Console.WriteLine("Nhập lại số lượng nhân viên: ");
                    n = Console.ReadLine();
                }
            }
            while (!Validate.CheckNum(n, out num) || num < 0);


            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Nhập thông tin cho nhân viên {i + 1}:");
                Console.Write("Tên nhân viên: ");
                string name = Console.ReadLine();
                do
                {
                    if (!Validate.CheckName(name) || !Validate.CheckXSSInput(name) || name == " ")
                    {
                        Console.WriteLine("Tên nhân viên nhập vào không hợp lệ!");
                        Console.WriteLine("Mời nhập lại: ");
                        name = Console.ReadLine();
                    }
                                  }
                while (!Validate.CheckName(name) || !Validate.CheckXSSInput(name) || name == " ");

                Console.Write("Loại nhân viên (1 - Full-time, 2 - Part-time, 3 - Intern): ");
                int type = int.Parse(Console.ReadLine());
                Employee emp = null;
                switch (type)
                {
                    case 1:
                        emp = new FullTimeEmployee();
                        Console.Write("Lương hàng tháng: ");
                        ((FullTimeEmployee)emp).MonthlySalary = double.Parse(Console.ReadLine());
                        break;
                    case 2:
                        emp = new PartTimeEmployee();
                        Console.Write("Tỉ lệ giờ làm việc: ");
                        ((PartTimeEmployee)emp).HourlyRate = double.Parse(Console.ReadLine());
                        Console.Write("Số giờ làm việc trong tháng: ");
                        ((PartTimeEmployee)emp).HoursWorked = double.Parse(Console.ReadLine());
                        break;
                    case 3:
                        emp = new Intern();
                        Console.Write("Tiền thưởng/tháng: ");
                        ((Intern)emp).Stipend = double.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Không hợp lệ.");
                        break;
                }
                emp.Name = name;
                _employees.Add(emp);
            }
        }

        public void EmployeeSalary()
        {
            Console.WriteLine("Lương của các nhân viên:");
            foreach (var employee in _employees)
            {
                double salary = SalaryCalculator.Calculate(employee);
                Console.WriteLine($"{employee.Name}: {salary} VND");
            }
        }
    }
}
