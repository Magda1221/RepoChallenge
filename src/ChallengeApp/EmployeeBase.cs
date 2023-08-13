using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public abstract class EmployeeBase : NamedObject, IEmployee
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public EmployeeBase(string name) : base(name)
        {

        }

        public abstract event GradeAddedDelegate GradeAdded3;

        public abstract void AddGrade(double grade);
        // public abstract void AddGradeString(string input);
        public abstract Statistics GetStatistics();
        public abstract event GradeAddedDelegate GradeAdded;
    }

}






