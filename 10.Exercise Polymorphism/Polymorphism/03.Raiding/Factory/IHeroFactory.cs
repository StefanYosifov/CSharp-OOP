using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factory
{
    public interface IHeroFactory
    {

        BaseHero CreateHero(string type,string name);

    }
}
