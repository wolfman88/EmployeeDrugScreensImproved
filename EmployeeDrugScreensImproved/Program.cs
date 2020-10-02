using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

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
            emp.Salary = Convert.ToDecimal(employeeInformation[10]);
            emp.LastPayHike = Convert.ToDecimal(employeeInformation[11]);
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
      Console.WriteLine("5: ID, Duration of employment");
      Console.WriteLine("6: ID, Employee Age");
      Console.WriteLine("7: ID, Contact info 50 Random Employee's for drug testing: (Last & first name, Phone number, State, City, Zipcode)");
      Console.WriteLine("8: ID, Usernames & Passwords list");
      Console.WriteLine("9: ID, age when hired");
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
            Console.WriteLine($"Selection #: {selection} |" + "ID: {0} | Last Drug Test: {1: MM/dd/yy}", entry.Key, entry.Value.DrugTestDateLast);
            selection++;
          }
          string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

          using (StreamWriter outputCSVFile = new StreamWriter(Path.Combine(docPath, "Employees to be Drug Tested.csv")))
          {
            string[] csvFileHead = new string[]
            {
          "ID", "Prefix", "First Name", "Middle Initial", "Last Name", "Gender", "Date of Last Drug Test", "E-Mail", "Date of Birth",
          "Date Hired", "SSN", "Phone Number", "County", "City", "State", "Zip Code"
            };
            outputCSVFile.WriteLine(string.Join(",", csvFileHead));

            foreach (KeyValuePair<string, Employee> item in employeesSelectedForTesting)
            {
              string[] empValues = new string[]
              {
            item.Value.ID, item.Value.NamePrefix, item.Value.FirstName, item.Value.MiddleInitial, item.Value.LastName, item.Value.Gender,
            Convert.ToString(item.Value.DrugTestDateLast), item.Value.EMail, Convert.ToString(item.Value.DateOfBirth),
            Convert.ToString(item.Value.DateHired), item.Value.SSN, item.Value.PhoneNumber, item.Value.County, item.Value.City, 
                item.Value.State, item.Value.ZipCode
              };
              outputCSVFile.WriteLine(string.Join(",", empValues));
            }
          }
          break;
        case 2:
          foreach (KeyValuePair<string, Employee> entry in employeesSelectedForTesting)
          {
            Console.WriteLine($"Selection #: {selection} |" + "ID: {0} | Employee Name: {1}, {2} | Last Drug Test: {3: MM/dd/yy}", entry.Key,
                entry.Value.LastName, entry.Value.FirstName, entry.Value.DrugTestDateLast);
            selection++;
          }
          break;
        case 3:
          foreach (KeyValuePair<string, Employee> entry in employeesSelectedForTesting)
          {
            Console.WriteLine($"Selection #: {selection} |" + "ID: {0} | Employee Name: {1}, {2} | Phone #: {3} | Last Drug Test: {4: MM/dd/yy}",
                entry.Key, entry.Value.LastName, entry.Value.FirstName, entry.Value.PhoneNumber, entry.Value.DrugTestDateLast);
            selection++;
          }
          break;
        case 4:
          foreach (KeyValuePair<string, Employee> entry in employeeInfoData)
          {
            Console.WriteLine($"Line #: {selection}" + " | ID: {0}" + "|  Salary increase amount: $" +
                $"{Convert.ToInt32(entry.Value.Salary) - Convert.ToInt32(entry.Value.Salary / (1 + entry.Value.LastPayHike))}",
                entry.Key);
            selection++;
          }
          break;
        case 5:
          foreach (KeyValuePair<string, Employee> entry in employeeInfoData)
          {
            long months = DateAndTime.DateDiff(DateInterval.Month, entry.Value.DateHired, DateTime.Now);
            long years = months / 12;
            long monthRemaining = months % 12;

            Console.WriteLine($"Line #: {selection}" + " | ID: {0}" + $"|  Employed for: " +
              $" {years} Years, {monthRemaining} Months", entry.Key);

            // https://www.google.com/search?q=C%23+decimal+part+of+double&oq=C%23+decimal+part+of+double&aqs=chrome..69i57j69i58.8685j0j4&sourceid=chrome&ie=UTF-8
            // https://www.codeproject.com/Questions/1097824/How-to-get-the-decimal-part-of-a-double-Csharp-wit

            /*TimeSpan days = DateTime.Now - entry.Value.DateHired;
            double years = days.Days / 365.2425;
            double months = 

            Console.WriteLine($"Selection #: {selection}" + "  | ID: {0}" + $"|  Employed for: " +
              $" {years} Years, { } Months");*/
            selection++;
          }
          break;
        case 6:
          foreach (KeyValuePair<string, Employee> entry in employeeInfoData)
          {
            long months = DateAndTime.DateDiff(DateInterval.Month, entry.Value.DateOfBirth, DateTime.Now);
            long years = months / 12;
            long monthRemaining = months % 12;

            Console.WriteLine($"Line #: {selection}" + " | ID: {0}" + $"|  Employee's Age: " +
              $" {years} Years, {monthRemaining} Months", entry.Key);
            selection++;
          }
          break;
        case 7:
          foreach (KeyValuePair<string, Employee> entry in employeesSelectedForTesting)
          {
            Console.WriteLine($"Selection #: {selection} |" + " ID: {0} | Employee Name: {1}, {2} | Phone Number: {3} " +
              " |  State: {4} | City: {5} | Zipcode: {6}", entry.Key, entry.Value.LastName, entry.Value.FirstName,
              entry.Value.PhoneNumber, entry.Value.State, entry.Value.City, entry.Value.ZipCode);
            selection++;
          }
          break;
        case 8:
          foreach (KeyValuePair<string, Employee> entry in employeeInfoData)
          {
            Console.WriteLine($"Line #: {selection} |" + " ID: {0} | Employee Name: {1}, {2} | Username: {3} | Password: {4}", entry.Key,
              entry.Value.LastName, entry.Value.FirstName, entry.Value.UserName, entry.Value.Password);
            selection++;
          }
          break;
        case 9:
          foreach (KeyValuePair<string, Employee> entry in employeeInfoData)
          {
            long birthMonths = DateAndTime.DateDiff(DateInterval.Month, entry.Value.DateOfBirth, DateTime.Now);
            long birthYears = birthMonths / 12;
            //long birthMonthRemaining = birthMonths % 12;

            long months = DateAndTime.DateDiff(DateInterval.Month, entry.Value.DateHired, DateTime.Now);
            long years = months / 12;

            long yearsAtHire = birthYears - years;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Line #: {selection}" + " | ID: {0}" + $"|  Age when hired: " +
              $"{yearsAtHire} Years", entry.Key);
            selection++;
          }
          break;
        case 10:
          List<string> listEmployeesOverTenYearsService = new List<string>();

          foreach (KeyValuePair<string, Employee> entry in employeeInfoData)
          {
            long months = DateAndTime.DateDiff(DateInterval.Month, entry.Value.DateHired, DateTime.Now);
            long years = months / 12;
            if (years >= 10)
            {
              listEmployeesOverTenYearsService.Add(Convert.ToString(entry.Key));
            }
          }
          foreach (string key in listEmployeesOverTenYearsService)
          {
            if (employeeInfoData.ContainsKey(key))
            {
              Console.WriteLine($"Before Raise: {employeeInfoData[key].Salary}");
              employeeInfoData[key].Salary = employeeInfoData[key].Salary * Convert.ToDecimal(1.05);
              Console.WriteLine($"after raise: {employeeInfoData[key].Salary}");
              employeeInfoData[key].LastPayHike = Convert.ToDecimal(0.05);
            }
          }
          break;
        case 11:

          break;
        default:
          break;
      }
      /*DateTime birthday = new DateTime(1988, 08, 02);
      int years2 = DateTime.Now.Year - birthday.Year;
      int months2 = DateTime.Now.Month - birthday.Month;*/

      Console.ReadLine();
    }

  }
}
