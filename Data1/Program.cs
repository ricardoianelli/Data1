using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using Data1.Entities;

namespace Data1
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                List<Employee> employees = new List<Employee>();
                Console.Write("Enter the csv file path: ");
                string inPath = Console.ReadLine();

                using (StreamReader reader = File.OpenText(inPath)){
                    while (!reader.EndOfStream){
                        string[] line = reader.ReadLine().Split(",");
                        employees.Add(
                            new Employee {
                                name = line[0],
                                email = line[1],
                                salary = Double.Parse(line[2], CultureInfo.InvariantCulture)
                            }
                        );
                    }
                }

                Console.Write("Enter salary:");
                double salary = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.WriteLine("Email of people whose salary is more than " + salary.ToString("F2", CultureInfo.InvariantCulture) + ":");

                IEnumerable<string> emails =
                    from emp in employees
                    where emp.salary > salary
                    orderby emp.name
                    select emp.email;

                foreach (string email in emails){
                    Console.WriteLine(email);
                }

                double sum =
                    (from emp in employees
                     where emp.name[0] == 'M'
                     select emp.salary)
                    .Sum();
                    
                Console.WriteLine("Sum of salary of people whose name starts with 'M':" + sum.ToString("F2", CultureInfo.InvariantCulture));
                Console.ReadLine();
            }
            catch (Exception exception){
                Console.WriteLine("Error: " + exception.Message);
            }
        }
    }
}
