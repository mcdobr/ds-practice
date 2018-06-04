using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Employee
    {
        private string name;
        private List<Employee> subordinates;

        public Employee() { }

        public Employee(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get {return name;}
            set {name = value;}
        }

        public List<Employee> Subordinates
        {
            get { return subordinates; }
            set { subordinates = value;}
        }
    }
}
