using CalculatorLib;
using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
namespace CalculatorApp
{
    public class Program
    {
        public static double LastResult { get; private set; }
        static BasicCalculator calculator;
        static void Main(string[] args)
        {
            while(true)
            {
                try
                {
                    MainMenu();
                    while (true)
                    {
                        RunCalculator(calculator);
                        Console.WriteLine($"Результат: {LastResult}");
                    }
                }
                catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
                catch (FormatException ex) { Console.WriteLine(ex.Message); }
                catch (DivideByZeroException ex) { Console.WriteLine(ex.Message); }
                catch (IndexOutOfRangeException ex) { Console.WriteLine(ex.Message); }
                catch (Exception ex) { Console.WriteLine($"Ошибка приложения, {ex.Message}"); }
            }
        }


        public static BasicCalculator MainMenu()
        {
            Console.WriteLine("1. Basic Calculator     (Доступные операции: +, -, *, /)");
            Console.WriteLine("2. ScientificCalculator (Доступные операции: +, -, *, /, Pow, Sqrt, Sin, Cos)");
            Console.WriteLine("3. ProgrammerCalculator (Доступные операции: +, -, *, /, And(&), Or(|), XOr(^), ToBinary, ToHex)");
            Console.Write("Выберите тип калькулятора: ");
            string calcChoice = Console.ReadLine();
            calculator = calcChoice switch
            {
                "1" => new BasicCalculator(),
                "2" => new ScientificCalculator(),
                "3" => new ProgrammerCalculator(),
                _ => throw new ArgumentException("Неправильно выбран тип калькулятора.")
            };
            return calculator;
        }

        public static void RunCalculator(BasicCalculator calculator)
        {
            Console.Write("Введите операцию: ");
            string userInput = Console.ReadLine().ToLower();
            LastResult = calculator.InputParsing(userInput);
        }
    }
}
