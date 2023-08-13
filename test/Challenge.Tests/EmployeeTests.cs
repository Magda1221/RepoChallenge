using System;
using ChallengeApp;
using Xunit;

namespace Challenge.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var emp = new Employee("Magda");
            
            var a = 11;
            emp.AddGrade(55.6);
            emp.AddGrade(82.1);
            emp.AddGrade(35.7);
            
            //act
            var result = emp.GetStatistics();

            //assert
            Assert.Equal(57.8, result.Average, 1);
            Assert.Equal(82.1, result.High);
            Assert.Equal(35.7, result.Low);
        }
    }
}
