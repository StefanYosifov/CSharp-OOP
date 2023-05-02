using System;
using System.Linq;

namespace _4.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String[] commandArr = Console.ReadLine().Split(' ').ToArray();
                string ingredient=commandArr[0];
                string flaour=commandArr[1];
                string baking=commandArr[2];
                double weight = double.Parse(commandArr[3]);
                Dough dough=new Dough(flaour, baking, weight);
                Console.WriteLine(dough);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
      
        }
    }
}
