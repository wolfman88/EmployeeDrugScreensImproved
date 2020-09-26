using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDrugScreensImproved
{
    class Employee
    {
        public Employee()
        {

        }

        public string ID { get; set; }
        public string NamePrefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DrugTestDateLast { get; set; }
        public string EMail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateHired { get; set; }
        public int Salary { get; set; }
        public int LastPayHike { get; set; }
        public string SSN { get; set; }
        public string PhoneNumber { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Employee GetEmployee(string ID)
        {
            Employee emp = new Employee();
            return emp;
        }
    }
}
