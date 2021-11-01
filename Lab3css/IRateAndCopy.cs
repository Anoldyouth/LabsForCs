using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3css
{
    public interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
}
