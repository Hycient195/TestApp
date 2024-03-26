using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Mocking
{
    public class Program
    {
        public static void Main()
        {
            var videoService = new VideoService();
            var result = videoService.ReadVideoTitle(new FileReader());
            Console.WriteLine(result);
        }
    }
}
