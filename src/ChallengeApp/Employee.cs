using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class InMemoryEmp : EmployeeBase
    {
        private List<double> grades;
        public InMemoryEmp(string name) : base(name)
        {
            grades = new List<double>();
        }

        public override event GradeAddedDelegate GradeAdded3;
        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if (grade >= 1 && grade <= 6)
            {

                grades.Add(grade);
                if (grade < 3 && GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }


            }

            else
            {
                throw new ArgumentException($"Invalid grade. Write grade in range of (+/-1-6)");

            }
        }

        public override Statistics GetStatistics()
        {
            {
                var result = new Statistics();
                for (var index = 0; index < grades.Count; index += 1)
                {
                    result.Add(grades[index]);
                }
                return result;
            }
        }
    }



}













