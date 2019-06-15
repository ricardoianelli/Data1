using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
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

                employees.ForEach(p => Console.WriteLine(p));
            }
            catch (Exception exception){
                Console.WriteLine("Error: " + exception.Message);
            }
        }
    }
}
