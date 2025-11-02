using CalculatorLib;
using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
namespace CalculatorApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //catch (IndexOutOfRangeException ex) { Console.WriteLine(ex.Message); }
            //catch (FormatException ex) { Console.WriteLine(ex.Message); }
            string userInput = Console.ReadLine();
            //var instance = new BasicCalculator();
            var instance = new ProgrammerCalculator();
            double result = instance.InputParsing(userInput);
            Console.WriteLine(result);
        }
    }
}
