using System;
using System.Collections.Generic;
using System.Text;
using Galaxy.Core.Models;

namespace Galaxy.Core.Contracts
{
    public interface IGalaxySetup
    {
        List<Planet> getPlanets();
    }
}
