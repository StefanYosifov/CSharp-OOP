using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    using Models;
    using Models.Interfaces;
    public class Robot : IInhabitant,IBirthdate
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
            
        }

        public string Model { get; private set; }

        public string Id { get; private set; }

        public string Birthdate{get; private set; }
    }
}
