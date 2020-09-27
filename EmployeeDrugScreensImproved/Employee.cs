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

        public string ID { get; set; } // 0
        public string NamePrefix { get; set; } // 1
        public string FirstName { get; set; } // 2
        public string MiddleInitial { get; set; } // 3
        public string LastName { get; set; } // 4
        public string Gender { get; set; } // 5
        public DateTime DrugTestDateLast { get; set; } // 6
        public string EMail { get; set; } // 7
        public DateTime DateOfBirth { get; set; } // 8
        public DateTime DateHired { get; set; } // 9
        public string Salary { get; set; } // 10
        public string LastPayHike { get; set; } // 11
        public string SSN { get; set; } // 12
        public string PhoneNumber { get; set; } // 13
        public string County { get; set; } // 14
        public string City { get; set; } // 15 
        public string State { get; set; } // 16
        public string ZipCode { get; set; } // 17
        public string UserName { get; set; } // 18
        public string Password { get; set; } // 19

        public Employee GetEmployee(string ID)
        {
            Employee emp = new Employee();
            return emp;
        }
    }
}
