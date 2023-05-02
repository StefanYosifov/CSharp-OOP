using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {

        
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        private string name;
        private int age;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0)
                {
                    this.age = value;
                }
                else
                {
                    this.age = 0;
                }
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}, Age: {this.Age}");
            return sb.ToString();
        }
    }
}
