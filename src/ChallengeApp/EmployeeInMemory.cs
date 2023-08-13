using System.Collections.Generic;

namespace ChallengeApp
{
    public class EmployeeInMemory : EmployeeBase
    {
        private List<double> grades = new List<double>();

        public EmployeeInMemory(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded3;
        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {            
        }
        // public override void AddGradeString(string input)
        // {            
        // }

        public override Statistics GetStatistics()
        {
          throw new System.NotImplementedException();
        }

    }
}


