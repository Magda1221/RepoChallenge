using System;
using ChallengeApp;
using Xunit;

namespace Challenge.Tests
{
    public class TypeTests
    {
        public delegate string WriteMessage(string message);

        int counter = 0;

        [Fact]
        public void WriteMessageDelegateCanPointToMethod()
        {
            WriteMessage del = ReturnMessage;
            del += ReturnMessage;
            del += ReturnMessage2;

            var result = del("HELLO!");

            Assert.Equal(3, counter);
        }

        string ReturnMessage(string message)
        {
            counter++;
            return message;
        }
        string ReturnMessage2(string message)
        {
            counter++;
            return message.ToUpper();
        }

        [Fact]
        public void GetEmployeeReturnsDifferentObjects()
        {
            var emp1 = GetEmployee("Magda");
            var emp2 = GetEmployee("Anna");

            Assert.NotSame(emp1, emp2);
            Assert.False(Object.ReferenceEquals(emp1, emp2));

        }
        [Fact]
        public void TwoVarsCanReferenceSameObjects()
        {
            var emp1 = GetEmployee("Magda");
            var emp2 = emp1;

            Assert.Same(emp1, emp2);
            Assert.True(Object.ReferenceEquals(emp1, emp2));

        }
        [Fact]
        public void CSharpCanPassByRef()
        {
            Employee emp1 = null;
            GetEmployeeSetName(out emp1, "new name");
            Assert.Equal("new name", emp1.Name);

        }

        private void GetEmployeeSetName(out Employee emp, string name)
        {
            emp = new Employee(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var emp1 = GetEmployee("Magda");
            this.SetName(emp1, "NewName");
            Assert.Equal("Magda", emp1.Name);

        }

        private Employee GetEmployee(string name)
        {
            return new Employee(name);
        }

        public void SetName(Employee employee, string name)
        {
            employee.Name = name;
        }
        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(3, x);

        }
        private void SetInt(ref int x)
        {
            x = 3;
        }
        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void StringBehaveLikeValueType()
        {
            var x = "Magda";
            var upper = this.MakeUppercase(x);

            Assert.Equal("Magda", x);
            Assert.Equal("MAGDA", upper);

        }
        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }
    }
}
