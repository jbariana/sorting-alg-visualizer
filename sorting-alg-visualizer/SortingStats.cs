using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting_alg_visualizer
{
    public static class SortingStats
    {
        public static int Comparisons { get; set; } = 0;
        public static int Swaps { get; set; } = 0;

        public static void Reset()
        {
            Comparisons = 0;
            Swaps = 0;
        }
    }
}
