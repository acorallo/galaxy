using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Core.Contracts
{
    public interface IGeometric
    {
        double getPerimeter();
        bool IsCenterInside();
    }
}
