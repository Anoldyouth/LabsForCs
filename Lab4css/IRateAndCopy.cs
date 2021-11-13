using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4css
{
    public interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
}
