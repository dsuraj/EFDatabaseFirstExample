using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDatabaseFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter employee name");
            using (var db = new EFDatabaseFirstExample.EFDatabaseFirstDBEntities())
            {
                Employee employee = new Employee();
                employee.Name = Console.ReadLine();
                employee.CompanyId = 1; //hard coded for demo purpose
                employee.Age = 27;
                db.Employees.Add(employee);
                db.SaveChanges();
            }

            Console.WriteLine("List of employees for company 1");
            using (var db = new EFDatabaseFirstExample.EFDatabaseFirstDBEntities())
            {
                //get the company with ID = 1
                var company = (from c in db.Companies
                              where c.Id == 1
                              select c).SingleOrDefault();

                //get the employee list for a company with a id = 1
                List<Employee> employees = company.Employees.ToList();

                //display each item.
                foreach (var emp in employees)
                {
                    Console.WriteLine(emp.Name);
                }
                Console.ReadKey();
            }
        }
    }
}
