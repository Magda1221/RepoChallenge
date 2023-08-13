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

        // public override void AddGradeString(string input)
        // {
        //  var grade = input switch
        // {
        //     "1+" => 1.5,
        //     "2+" => 2.5,
        //     "3+" => 3.5,
        //     "4+" => 4.5,
        //     "5+" => 5.5,
        //     "1-" => 0.75,
        //     "2-" => 1.75,
        //     "3-" => 2.75,
        //     "4-" => 3.75,
        //     "5-" => 4.75,
        //     "1" or "2" or "3" or "4" or "5" or "6" 
        //     => double.Parse(input)
        // };

        // if (GradeAdded != null && grade <= 6)
        // {
        //     GradeAdded(this, new EventArgs());
        // this.grades.Add(grade);
        // // Console.WriteLine($"Grade {grade} was added.");

        // if (grade < 3)
        // {
        //     GradeAdded3(this, new EventArgs());
        // }
        // // if (grade > 6)
        // else
        // {
        //     Console.WriteLine($"Grade is out of range. Write grade in range of (+/-1-6)");
        // }
        // }
    }
}


// public class Employee : EmployeeBase
// {
//     public delegate void GradeAddedDelegate(object sender, EventArgs args);

//     public override event GradeAddedDelegate GradeAdded3;

//     private List<double> grades = new List<double>();
//     private char n;
//     private char letter;

//     public const string SEX = "K";


//     public Employee(string name) : base(name)
//     {
//     }


//     // internal void AddGradeString(string input)
//     // {
//     //     throw new NotImplementedException();
//     // }

//     public void AddGrade(double grade, int a)
//     {

//     }

//     public double Grade
//     {
//         get
//         {
//             return this.Grade;
//         }
//         set
//         {
//             this.Grade = value;
//         }
//     }

//     public override void AddGrade(double grade)

//     {
//         if (grade >= 1 && grade <= 6)
//         {
//             this.grades.Add(grade);


//             // if (GradeAdded != null)
//             // {
//             //     GradeAdded(this, new EventArgs());

//             if (GradeAdded3 != null && grade < 3)
//             {
//                 GradeAdded3(this, new EventArgs());
//             }

//         }
//     }
//     //     else
//     //     {
//     //         // throw new ArgumentException($"Invalid argument: {nameof(grade)}");
//     //         Console.WriteLine("This grade is incorrect.");
//     //     }
//     // }
//     //      public void AddGrade(char grade)
//     //     {

//     //       switch(grade)
//     //       {
//     //         case 'A':
//     //          this.AddGrade(100);
//     //          break;
//     //         case 'B':
//     //          this.AddGrade(80);
//     //          break;
//     //         case 'C':
//     //          this.AddGrade(60);
//     //          break;
//     //         default:
//     //          this.AddGrade(0);
//     //          break;
//     //       }
//     // }

//     public override Statistics GetStatistics()
//     {
//         var result = new Statistics();
//         result.Average = 0.0;
//         result.High = double.MinValue;
//         result.Low = double.MaxValue;

//         //var index = 0;

//         for (var index = 0; index < grades.Count; index++)
//         {
//             if (grades[index] == 5)
//             {
//                 continue;
//             }

//             result.Low = Math.Min(grades[index], result.Low);
//             result.High = Math.Max(grades[index], result.High);
//             result.Average += grades[index];
//         };

//         result.Average /= grades.Count;

//         switch (result.Average)
//         {
//             case var d when d >= 90:
//                 result.Letter = 'A';
//                 break;

//             case var d when d >= 80:
//                 result.Letter = 'B';
//                 break;

//             case var d when d >= 60:
//                 result.Letter = 'C';
//                 break;

//             default:
//                 result.Letter = 'Z';
//                 break;

//         }

//         return result;

//     }

// public override void AddGradeString(string input)
// {
//     var grade = input switch
//     {
//         "1+" => 1.5,
//         "2+" => 2.5,
//         "3+" => 3.5,
//         "4+" => 4.5,
//         "5+" => 5.5,
//         "1-" => 0.75,
//         "2-" => 1.75,
//         "3-" => 2.75,
//         "4-" => 3.75,
//         "5-" => 4.75,
//         "1" or "2" or "3" or "4" or "5" or "6" 
//         _ => double.Parse(input)
//     };

//     if (GradeAdded != null && grade < 6)
//     {
//         GradeAdded(this, new EventArgs());
//     this.grades.Add(grade);
//     // Console.WriteLine($"Grade {grade} was added.");

//     if (grade < 3)
//     {
//         GradeAdded3(this, new EventArgs());
//     }
// }


//     // else
//     // {
//     //     throw new ArgumentException($"Grade is out of range. Write grade in range of (+/-1-6)");
//     // }


// }









