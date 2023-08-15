using System;
using System.Collections.Generic;

namespace ChallengeApp
{

    class Program
    {
        static void Main(string[] args)
        {

            var employee = new SavedEmployee("Anna");

            employee.GradeAdded += OnGradeAdded;
            employee.GradeAdded3 += LowGrade;



            EnterGrade(employee);

            var stats = employee.GetStatistics();
            Console.WriteLine($"Average: {stats.Average}");
            Console.WriteLine($"High: {stats.High}");
            Console.WriteLine($"Low: {stats.Low}");
            Console.WriteLine($"Sum: {stats.Sum:N2}");
            Console.WriteLine($"Count: {stats.Count:N2}");
            Console.WriteLine($"Letter: {stats.Letter}");
        }

        private static void EnterGrade(IEmployee employee)
        {
            while (true)
            {

                Console.WriteLine($"Hello! Enter grade for {employee.Name}. For quit press 'q'.");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    employee.AddGrade(grade);
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("New grade is added.");
        }

        static void LowGrade(object sender, EventArgs args)
        {
            Console.WriteLine("Oh no! Degree is too low.");
        }



    }

}


