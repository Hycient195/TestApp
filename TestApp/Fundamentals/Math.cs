using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Fundamentals
{
    public class Math
    {
        public int Add (int a, int b)
        {
            return a + b;
        }

        public int Subtract (int a, int b) 
        {
            return a - b;
        }

        public int Max (int a, int b)
        {
            return (a > b) ? a : b;
        }

        public int Min(int a, int b)
        {
            return (a < b) ? a : b;
        }

        public IEnumerable<int> GetOddNumbersWithinLimit(int limit)
        {
            List<int> result = new List<int>();
            for (int i = 0; i <= limit; i++)
            {
                if ((i % 2) != 0)
                    result.Add(i);
            }
            return result;
        }
    }
}
