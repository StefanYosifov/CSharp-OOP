using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IBirthable, IIdentifiable
    {
        public Citizen(string name,int age,string id,string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        private string name;
        private int age;
        private string id;
        private string birthDate;



        public string Id
        {
            get { return this.id;}
            private set { this.id = value; }
            
        }

        public string Birthdate
        {
            get { return this.birthDate; }
            private set
            {
                this.birthDate = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                this.age = value;
            }
        }
    }
}
