using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson
    {


        public Citizen(string name,int age)
        {
            this.Name = name;
            this.Age = age;
        }

        private int age;
        private string name;
       public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                this.age = value;
            }

        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                this.name = value;
            }
        }
    }
}
