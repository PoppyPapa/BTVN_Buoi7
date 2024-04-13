using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN
{
    abstract class Employee
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public abstract double CalculateSalary();
    }

    class FullTimeEmployee : Employee
    {
        public double MonthlySalary { get; set; }

        public override double CalculateSalary()
        {
            return MonthlySalary;
        }
    }
    class PartTimeEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public override double CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }
    }
    class Intern : Employee
    {
        public double Stipend { get; set; }

        public override double CalculateSalary()
        {
            return Stipend;
        }
    }
    class SalaryCalculator
    {
        public static double Calculate(Employee employee)
        {
            return employee.CalculateSalary();
        }
    }
    
}
