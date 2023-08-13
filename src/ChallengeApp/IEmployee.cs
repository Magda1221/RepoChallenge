using static ChallengeApp.EmployeeBase;

namespace ChallengeApp
{
    public interface IEmployee
    {
        void AddGrade(double grade);
        // void AddGradeString(string input);
        Statistics GetStatistics();

        string Name { get; }
        event GradeAddedDelegate GradeAdded;
        event GradeAddedDelegate GradeAdded3;
        
    }
}






