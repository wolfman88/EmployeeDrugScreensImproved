using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDrugScreensImproved
{
  class Program
  {
    static void Main(string[] args)
    {
      string line = "";

      StreamReader reader = new StreamReader(@"EmployeeRecords.csv");
      Dictionary<string, Employee> employeeInfoData = new Dictionary<string, Employee>();
      //Dictionary<int, DateTime> employeesToTest = new Dictionary<int, DateTime>();
      //Dictionary<int, DateTime> employeesSelectedForTesting = new Dictionary<int, DateTime>();

      int i = 1;

      while (line != null)
      {

        line = reader.ReadLine();

        if (line != null)
        {
          if (i > 1)
          {
            string[] employeeInformation = line.Split(',');
            // stuck here
            Employee emp = new Employee();
            emp.ID = employeeInformation[0];
            emp.NamePrefix = employeeInformation[1];
            emp.FirstName = employeeInformation[2];
            emp.MiddleInitial = employeeInformation[3];
            emp.LastName = employeeInformation[4];
            emp.Gender = employeeInformation[5];
            emp.DrugTestDateLast = Convert.ToDateTime(employeeInformation[6]);
            emp.EMail = employeeInformation[7];
            emp.DateOfBirth = Convert.ToDateTime(employeeInformation[8]);
            emp.DateHired = Convert.ToDateTime(employeeInformation[9]);
            emp.Salary = employeeInformation[10];
            emp.LastPayHike = employeeInformation[11];
            emp.SSN = employeeInformation[12];
            emp.PhoneNumber = employeeInformation[13];
            emp.County = employeeInformation[14];
            emp.City = employeeInformation[15];
            emp.State = employeeInformation[16];
            emp.ZipCode = employeeInformation[17];
            emp.UserName = employeeInformation[18];
            emp.Password = employeeInformation[19];

            employeeInfoData.Add(employeeInformation[0], emp);
          }
          i++;
        }
      }
    }
  }
}
