using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Fundamentals
{
    public class FizzBuzz
    {
        public static string GetOutput(int arg)
        {
            if (arg % 3 == 0 && arg % 5 == 0)
                return "FizzBuzz";

            if (arg % 3 == 0)
                return "Fizz";

            if (arg % 5 == 0)
                return "Buzz";

            return arg.ToString();
        }
    }
}
