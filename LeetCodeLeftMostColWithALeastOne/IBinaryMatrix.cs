using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLeftMostColWithALeastOne
{
    public interface IBinaryMatrix
    {
        public int Get(int x, int y);
        public IList<int> Dimensions();
    }
}
