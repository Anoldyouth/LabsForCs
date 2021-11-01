using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lab3css
{
    class CompareRating : IComparer<Article>
    {
        public int Compare([AllowNull] Article x, [AllowNull] Article y)
        {
            if (x.Rating.CompareTo(y.Rating) != 0)
            {
                return x.Rating.CompareTo(y.Rating);
            }
            else return 0;
        }
    }
}
