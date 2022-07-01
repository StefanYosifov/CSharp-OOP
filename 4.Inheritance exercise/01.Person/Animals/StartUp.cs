using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string command = Console.ReadLine();
            Animal animal = null;
            while (command != "Beast")
            {


                string[] animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();


                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                if (command == "Dog")
                {
                    string gender = animalInfo[2];
                    animal = new Dog(name, age, gender);
                }
                else if (command == "Frog")
                {
                    string gender = animalInfo[2];
                    animal = new Frog(name, age, gender);
                }
                else if (command == "Cat")
                {
                    string gender = animalInfo[2];
                    animal = new Cat(name, age, gender);
                }
                else if (command == "Kitten")
                {

                    animal = new Kitten(name, age);
                }
                else if (command == "TomCat")
                {

                    animal = new Tomcat(name, age);
                }
                animals.Add(animal);




                command = Console.ReadLine();
            }
            foreach (var a in animals)
            {
                Console.WriteLine(a);
            }
        }


    }
}
    


