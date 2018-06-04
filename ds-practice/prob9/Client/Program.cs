using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.localhost;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResources hr = new HumanResources();
            var e1 = new Employee(); e1.Name = "mircea dobreanu";
            var e2 = new Employee(); e2.Name = "vladimir lenin";
            var e3 = new Employee(); e3.Name = "anna pauker";
            var e4 = new Employee(); e4.Name = "benito";

            hr.AddEmployee(null, e2);
            hr.AddManager(e2);
            hr.AddEmployee(e2, e1);
            hr.AddEmployee(e2, e3);

            Console.WriteLine("employees of {0}", e2.Name);
            foreach (var emp in hr.GetEmployeesOf(e2))
                Console.WriteLine(emp.Name);

            Console.WriteLine("Manager of {0} is {1}", e3.Name, hr.GetManagerOf(e3).Name);
        }
    }
}
