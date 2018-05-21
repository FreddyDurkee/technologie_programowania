using System;
using System.Collections.Generic;
using System.Linq;


namespace Linq2Sql
{
        class LinqToSQLCRUD
        {
        public static string departmentString(Employee p)
        {
            return p.DepartmentId + " " + p.Department;
        }

        static void Main(string[] args)
        {
            string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["Linq2Sql.Properties.Settings.LinqToSqlConnectionString"].ToString();
            DataClasses1DataContext db = new DataClasses1DataContext();

            Department newDepartment = new Department();
            newDepartment.DepartmentId = 1;
            newDepartment.Name = "IT";

            db.Department.InsertOnSubmit(newDepartment);
            db.SubmitChanges();

            //Create new Employee

            Employee newEmployee = new Employee();
            newEmployee.EmployeeId = 1;
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

            #region IEnumerable vs IQueryable
            IEnumerable<Employee> enumEmployees = db.Employee.Where(user => user.DepartmentId == 1);
            IQueryable<Employee> queryEmployees = db.Employee.Where(user => user.DepartmentId == 1);

            //Kiedy wykonujemy
            //1. Iterujemy sie
            foreach (Employee emps in enumEmployees)
            {
                Console.WriteLine(emps);
            }

            //2. Wywolujemy ToList()
            IEnumerable<Employee> empList = enumEmployees.ToList();

            //3. Wybieramy pojedynczy element
            Employee emp = enumEmployees.First();


            //Przypadek 1
            var department1 = db.Employee.Where(user => user.DepartmentId == 1).Select(p => p.DepartmentId + " " + p.Department);
            foreach (var dep in department1)
            {
                Console.WriteLine(dep);
            }

            //Przypadek 2


            var department2 = db.Employee.Where(user => user.DepartmentId == 1).Select(p => departmentString(p));
            foreach (var dep in department2)
            {
                Console.WriteLine(dep);
            }

            //Przypadek 3
            var department3 = db.Employee
                .Where(user => user.DepartmentId == 1).ToList().
                Select(p => departmentString(p));
            foreach (var dep in department3)
            {
                Console.WriteLine(dep);
            }

            #endregion

        }
    }
    
}
