﻿namespace CarRacing.Repositories
{
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RacerRepository : IRepository<IRacer>
    {

        private readonly ICollection<IRacer> models;

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => models as IReadOnlyCollection<IRacer>;

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            this.models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return models.FirstOrDefault(x => x.Username == property);  
        }

        public bool Remove(IRacer model)
        {
            return models.Remove(model);
        }
    }
}
