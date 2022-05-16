using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_VT.Models;

namespace WebApi_VT.Controllers
{
    public class EmployeesController : ApiController
    {
        EmployeeDBContext dbContext = new EmployeeDBContext();
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDBContext dbContext = new EmployeeDBContext())
            {
                return dbContext.Employees.ToList();
            }
        }
        public Employee Get(int id)
        {
            using (EmployeeDBContext dbContext = new EmployeeDBContext())
            {
                return dbContext.Employees.FirstOrDefault(e => e.ID == id);
            }
        }
        [HttpPost]
        public Employee Add(Employee emp)
        {
            dbContext.Employees.Add(emp);
            dbContext.SaveChanges();
            return emp;
        }
        [HttpPut]
        public Employee UpdateEmp(int id, Employee emp)
        {
            var dbEmp = dbContext.Employees.FirstOrDefault(e => e.ID == id);

            dbEmp.FirstName = emp.FirstName;
            dbEmp.LastName = emp.LastName;
            dbEmp.Gender = emp.Gender;
            dbEmp.Salary = emp.Salary;

            dbContext.SaveChanges();
            return dbEmp;
        }
        [HttpDelete]
        public Employee DeleteEmp(int id)
        {
            var dbEmp = dbContext.Employees.FirstOrDefault(e => e.ID == id);

            dbContext.Employees.Remove(dbEmp);
            dbContext.SaveChanges();

            return dbEmp;
        }
    }
}
