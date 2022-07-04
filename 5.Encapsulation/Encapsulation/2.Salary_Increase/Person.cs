using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        public Person()
        {
            people = new List<Person>();
        }

        public Person(string firstName, string lastName, int age,decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            this.Salary = salary;
        }

        private List<Person> people;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {Salary:F2} leva.";
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

        public void PrintPeople()
        {
            foreach(var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }

        public void Add(Person person)
        {
            people.Add(person);
        }

    }
}
