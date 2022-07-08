using System;
using System.Collections.Generic;
using System.Text;

namespace _8._CollectionHierarchy.Models
{
    using Interfaces;
    public class MyList<T> : IMyList<T>
    {
        int IMyList<T>.Used => throw new NotImplementedException();

        int IAddCollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }
    }
}
