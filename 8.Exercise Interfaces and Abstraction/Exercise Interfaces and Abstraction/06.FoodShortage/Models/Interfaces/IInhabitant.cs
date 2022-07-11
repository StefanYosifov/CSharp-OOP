using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.Models.Interfaces
{
    public interface IInhabitant:IBuyer
    {
        string Name { get; }
        string Id { get;}

       
    }
}
