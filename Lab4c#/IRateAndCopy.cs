using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4cs
{
    public interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
}
