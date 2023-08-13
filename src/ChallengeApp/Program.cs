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


            // var name = employee.Name;
            // employee.Name = "Anna";


            // var aa = Employee.SEX;

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
                //     try
                //    { 
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
                // finally
                // {
                    // Console.WriteLine("Here is finally");
                // }

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

        // employee.NewAge();
        // employee.AddGrade(5.8);
        // employee.AddGrade(3.7);
        // employee.AddGrade(2.61);
        // employee.AddGrade("4.85");
        // employee.AddGrade("nie");
        // employee.AddGrade("5");
        // employee.AddGrade("co");


        // var stat = employee.GetStatistics();
        // Console.WriteLine($"The average is {stat.Average:N2}");
        // Console.WriteLine($"The Max value is {stat.High:N2}");
        // Console.WriteLine($"The Min value is {stat.Low:N2}");

        // var grades = new List<double>() { 18.5, 7, 1.854 };


        // var result = 0.0;
        // var highGrade = double.MinValue;
        // var lowGrade = double.MaxValue;

        // var ChangeName = employee.GetStatistics();
        // employee.ChangeName("T9mek");
        // employee.ChangeName("Karolina");
        // stat = employee.GetStatistics();

        // foreach (var n in grades)
        // {
        //     lowGrade = Math.Min(lowGrade, n);
        //     highGrade = Math.Max(highGrade, n);
        //     result += n;
        // }
        // Console.WriteLine($"The average is {result:N6}");

        // if (args.Length > 0)
        // {
        //     Console.WriteLine("Hello {args[0]}");
        // }
        // else
        // {
        //     Console.WriteLine("Hello");
        // }

    }

}


