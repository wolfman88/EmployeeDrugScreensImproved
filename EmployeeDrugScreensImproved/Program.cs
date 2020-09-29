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
            Dictionary<string, Employee> employeesEligible = new Dictionary<string, Employee>();
            Dictionary<string, Employee> employeesSelectedForTesting = new Dictionary<string, Employee>();

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
                    employeesEligible.Add(entry.Key, entry.Value); // pass results into a new dictionary called employeesEligableForTesting.
                } 
                // Next to do: continue to pass full employee objects to next dictionary for the perposes of displaying more information in console.
                // COMPLETE: Only issue, hard coded output... not efficent.
            }

            for (int x = 0; x < 50; x++)
            {
                int selectionNext = rand.Next(employeesEligible.Count);

                if (!employeesSelectedForTesting.ContainsKey(employeesEligible.ElementAt(selectionNext).Key))
                {
                    employeesSelectedForTesting.Add(employeesEligible.ElementAt(selectionNext).Key,
                        employeesEligible.ElementAt(selectionNext).Value);
                } // Next to do: add full value of employee object into final dictionary and possibly ask user what information they require.
                else
                    x--;
            }

            Console.WriteLine("Employee information Request");
            Console.WriteLine("Number entered outputs information specified in the following list:");
            Console.WriteLine("1: ID & Last test date");
            Console.WriteLine("2: ID, Last & first name, Last test Date");
            Console.WriteLine("3: ID, Last & first name, Phone Number, Last test Date");
            Console.WriteLine("4: ID, Last & first name, salery before last raise.");
            Console.WriteLine("hit ONLY the enter key to exit at any point");
            //Console.WriteLine("4: ID, Last & first name, , Last test Date");

            string userInput = Console.ReadLine();
            bool tryConvert = int.TryParse(userInput, out int switchRequest);

            switch (switchRequest)
            {
                case 0:
                    break;
                case 1:
                    foreach (KeyValuePair<string, Employee> entry in employeesSelectedForTesting)
                    {
                        Console.WriteLine($"Selection #:{selection}   " + "ID: {0} | Last Drug Test: {1: MM/dd/yy}", entry.Key, entry.Value.DrugTestDateLast);
                        selection++;
                    }
                    break;
                case 2:
                    foreach (KeyValuePair<string, Employee> entry in employeesSelectedForTesting)
                    {
                        Console.WriteLine($"Selection #:{selection}   " + "ID: {0} | Employee Name: {1}, {2} | Last Drug Test: {3: MM/dd/yy}", entry.Key,
                            entry.Value.LastName, entry.Value.FirstName, entry.Value.DrugTestDateLast);
                        selection++;
                    }
                    break;
                case 3:
                    foreach (KeyValuePair<string, Employee> entry in employeesSelectedForTesting)
                    {
                        Console.WriteLine($"Selection #:{selection}   " + "ID: {0} | Employee Name: {1}, {2} | Phone #: {3} | Last Drug Test: {4: MM/dd/yy}", 
                            entry.Key, entry.Value.LastName, entry.Value.FirstName, entry.Value.PhoneNumber, entry.Value.DrugTestDateLast);
                        selection++;
                    }
                    break;
                case 4:
                    foreach (KeyValuePair<string, Employee> entry in employeeInfoData)
                    {
                        Console.WriteLine($"Selection #: {selection}" + "  | ID: {0}" + "Previous Salary: $" + 
                            $"{Convert.ToDecimal(entry.Value.Salary) / (1 + Convert.ToDecimal(entry.Value.LastPayHike))}", 
                            entry.Key);
                    }
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }
    }
}
