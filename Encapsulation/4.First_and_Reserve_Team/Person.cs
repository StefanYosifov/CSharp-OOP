using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        public Person()
        {

        }
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;

        }

        private string firstName;
        private string lastName;
        private int age;
        decimal salary;

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                
                this.firstName = value;
            }
        }


        public string LastName
        {
            get { return lastName; }
            private set
            {
                
                this.lastName = value;
            }
        }

        public decimal Salary
        {
            get { return salary; }
            private set
            {
                
                this.salary = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                
                this.age = value;
            }
        }


        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)

            {

                this.Salary += this.Salary * percentage / 100;

            }

            else

            {

                this.Salary += this.Salary * percentage / 200;

            }

        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {Salary:F2} leva.";
        }
    }
}
