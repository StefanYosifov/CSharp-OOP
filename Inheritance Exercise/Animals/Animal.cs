using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        protected Animal(string name,int age,string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        private string name;
        private int age;
        private string gender;
        public string Name { get { return name;}
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"Invalid input!");
                }
            }
        
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (age <= 0)
                {
                    throw new ArgumentNullException($"Invalid input!");
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get { return this.gender; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"Invalid input!");
                }
                this.gender = value;
            }
        }

        public abstract string ProduceSound();
        public override string ToString()
        {
           StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(this.ProduceSound());
            return sb.ToString().Trim();
        }
    }
}
