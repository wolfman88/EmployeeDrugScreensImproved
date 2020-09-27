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
            int selection = 1;
            int numDayTestLimit = -180;
            DateTime dateTestLimit = DateTime.Today.AddDays(numDayTestLimit);
            var rand = new Random();

            StreamReader reader = new StreamReader(@"EmployeeRecords.csv");
            Dictionary<string, Employee> employeeInfoData = new Dictionary<string, Employee>();
            Dictionary<string, DateTime> employeesEligible = new Dictionary<string, DateTime>();
            Dictionary<string, DateTime> employeesSelectedForTesting = new Dictionary<string, DateTime>();

            int i = 1;

            while (line != null)
            {
                line = reader.ReadLine();

                if (line != null)
                {
                    if (i > 1)
                    {
                        string[] employeeInformation = line.Split(',');
                        // got stuck here
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

            foreach (KeyValuePair<string, Employee> entry in employeeInfoData) // Loop over employeeInfoData Dictionary to get employes not drug tested in 6 months or more.
            {
                if (entry.Value.DrugTestDateLast <= dateTestLimit)
                {
                    employeesEligible.Add(entry.Key, entry.Value.DrugTestDateLast); // pass results into a new dictionary called employeesEligableForTesting.
                }
            }

            for (int x = 0; x < 50; x++)
            {
                int selectionNext = rand.Next(employeesEligible.Count);

                if (!employeesSelectedForTesting.ContainsKey(employeesEligible.ElementAt(selectionNext).Key))
                {
                    employeesSelectedForTesting.Add(employeesEligible.ElementAt(selectionNext).Key,
                        employeesEligible.ElementAt(selectionNext).Value);
                }
                else
                    x--;
            }

            foreach (KeyValuePair<string, DateTime> entry in employeesSelectedForTesting)
            {
                Console.WriteLine($"Selection #:{selection}   " + "ID: {0} | Last Drug Test: {1: MM/dd/yy}", entry.Key, entry.Value);
                selection++;
            }
            Console.ReadLine();
        }
    }
}
