using System;
using System.Collections.Generic;
using System.Text;

namespace _8._CollectionHierarchy.Models
{
    using Interfaces;
    public class AddCollection<T> : IAddCollection<T>
    {
        public AddCollection()
        {
            this.data = new List<T>();
        }

        private int lastIndex;
        private readonly ICollection<T> data;
        public int Add(T item)
        {
            this.data.Add(item);
            return this.data.Count - 1;
        }
    }
}
