using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        //List<string> listString;
        //public StackOfStrings()
        //{
        //    listString = new List<string>();
        //}
        
        public bool IsEmpty()
        {
            if (base.Count == 0)
            {
                return true;
            }
            
            return false;
        }

        //public Stack<String> AddRange(Stack<string> stackToAdd) My solution
        //{
        //    while (stackToAdd != null)
        //    {
        //        base.Push(stackToAdd.Pop());
        //    }
        //    return this;
        //}


        public Stack<string> AddRange(IEnumerable<string> colllection) // Better solution
        {
            foreach(var item in colllection)
            {
                this.AddRange(colllection);
            }
            return this;
        }
    }
}
