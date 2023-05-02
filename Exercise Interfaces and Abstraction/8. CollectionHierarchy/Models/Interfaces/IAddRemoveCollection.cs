using System;
using System.Collections.Generic;
using System.Text;

namespace _8._CollectionHierarchy.Models.Interfaces
{
    public interface IAddRemoveCollection<T> : IAddCollection<T>
    {

        T Remove();

    }
}
