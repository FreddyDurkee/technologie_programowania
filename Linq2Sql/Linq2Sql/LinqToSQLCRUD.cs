using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Linq2Sql
{
        class LinqToSQLCRUD
        {
        static void Main(string[] args)
        {
            // string connectString = ConfigurationManager.ConnectionStrings["LinqToSQLDBConnectionString"].ToString();
            DataClasses1DataContext db = new DataClasses1DataContext();

            Department newDepartment = new Department();
            newDepartment.DepartmentId = 1;
            newDepartment.Name = "IT";

            db.Department.InsertOnSubmit(newDepartment);
            db.SubmitChanges();

            //Create new Employee

            Employee newEmployee = new Employee();
                newEmployee.Name = "Michael";
                newEmployee.Email = "yourname@companyname.com";
                newEmployee.ContactNo = "343434343";
                newEmployee.DepartmentId = 1;
                newEmployee.Adress = "Michael - USA";

                //Add new Employee to database
                db.Employee.InsertOnSubmit(newEmployee);

                //Save changes to Database.
                db.SubmitChanges();

                //Get new Inserted Employee            
                Employee insertedEmployee = db.Employee.FirstOrDefault(e=> e.Name.Equals("Michael"));

                Console.WriteLine("Employee Id = {0} , Name = {1}, Email = {2}, ContactNo = {3}, Address = {4}",
                                 insertedEmployee.EmployeeId, insertedEmployee.Name, insertedEmployee.Email,
                                 insertedEmployee.ContactNo, insertedEmployee.Adress);

                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }
        }
    
}
