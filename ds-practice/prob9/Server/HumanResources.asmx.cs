using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utils;

namespace Server
{
    /// <summary>
    /// Summary description for HumanResources
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HumanResources : System.Web.Services.WebService
    {
        private static List<Employee> employees = new List<Employee>();

        [WebMethod]
        public void AddManager(Employee e)
        {
            if (e == null)
                return;

            e.Subordinates = new List<Employee>();
        }

        /* Seteaza managerul m la employee e (daca m e chiar manager) */
        [WebMethod]
        public void AddEmployee(Employee m, Employee e)
        {
            if (e == null)
                return;
            
            Employee eTmp = employees.FirstOrDefault(emp => emp.Name == e.Name);
            Employee mTmp = employees.FirstOrDefault(mEmp => mEmp.Name == m.Name);

            if (eTmp != null)
                e = eTmp;
            if (mTmp != null)
                m = mTmp;


            // Daca exista deja, modifica-l pe ala
            if (employees.Any(emp => emp.Name == e.Name))
                e = employees.First(emp => emp.Name == e.Name);
            else // Altfel adauga-l
                employees.Add(e);

            if (m != null && m.Subordinates != null)
                m.Subordinates.Add(e);
        }

        [WebMethod]
        public Employee GetManagerOf(Employee e)
        {
            e = employees.FirstOrDefault(emp => emp.Name == e.Name);
            if (e != null)
                return employees.FirstOrDefault(emp => emp.Subordinates.Contains(e));
            else
                return null;
        }

        [WebMethod]
        public Employee[] GetEmployeesOf(Employee e)
        {
            e = employees.FirstOrDefault(emp => emp.Name == e.Name);
            
            if (e != null)
                return e.Subordinates.ToArray();
            else
                return new Employee[] { };
        }
    }
}
