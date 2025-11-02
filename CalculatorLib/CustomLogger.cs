using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    public static class CustomLogger
    {
        public static void Log(string level, string message)
        {
            string outputInfo = $"{DateTime.Now:F}, {level}, {message}";
            Console.WriteLine(outputInfo);
        }
    }
}
