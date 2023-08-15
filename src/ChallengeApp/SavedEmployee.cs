using System;
using System.Collections.Generic;
using System.IO;

namespace ChallengeApp
{
    public class SavedEmployee : EmployeeBase
    {
        private List<double> grades = new List<double>();
        private object saveUtcNow;
        private const string filename = "Grades.txt";
        private const string filename2 = "audit.txt";
        public SavedEmployee(string name) : base(name)
        {
        }
        public override event GradeAddedDelegate GradeAdded3;
        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (grade >= 1 && grade <= 6)
                {
                    grades.Add(grade);

                    if (grade > 0)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                    if (grade < 3)
                    {
                        GradeAdded3(this, new EventArgs());
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid grade");

                }
            }
            using (var writer = File.AppendText($"audit.txt"))
            {
                writer.WriteLine($"grade: {grade} date: {DateTime.UtcNow}");
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }


    }
}












