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

            StreamReader reader = new StreamReader(@"C:\Users\rbask\source\repos\EmployeeDrugScreensImproved\EmployeeDrugScreensImproved\EmployeeRecords.csv");
            Dictionary<string, Object> employeeInfoData = new Dictionary<string, Object>();
            //Dictionary<int, DateTime> employeesToTest = new Dictionary<int, DateTime>();
            //Dictionary<int, DateTime> employeesSelectedForTesting = new Dictionary<int, DateTime>();

            while (line != null)
            {
                line = reader.ReadLine();

                if (line != null)
                {
                    string[] employeeInformation = line.Split(',');
                    // stuck here
                }
            }
        }
    }
}
