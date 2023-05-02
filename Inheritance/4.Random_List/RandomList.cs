using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList:List<String>
    {
        List<String> list;
        public RandomList()
        {
            list= new List<String>();
        }


        public string RandomString()
        {
            Random rnd = new Random();
            int removeRandomElement = rnd.Next(0, base.Count);
            if (base.Count > 0)
            {
                string removedString = base[removeRandomElement];
                base.RemoveAt(removeRandomElement);
                return removedString;
            }
            return null;
        
        }
    }
}
