using System;
using System.Collections.Generic;
using System.Text;

namespace _8._CollectionHierarchy.Models
{
    using Interfaces;
    using System.Linq;

    public class AddRemoveCollection<T> : IAddCollection<T>
    {

        public AddRemoveCollection()
        {
            this.data = new List<T>();
        }

        private IList<T> data;
        public int Add(T item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public T Remove()
        {
            T elementToRemove = this.data.LastOrDefault();
            if (elementToRemove != null)
            {
                this.data.Remove(elementToRemove);
            }
            return elementToRemove;
        }
    }
}
