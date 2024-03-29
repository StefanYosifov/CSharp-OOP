﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Models
{
    using Interfaces;
    public class Robot : IInhabitant
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}
