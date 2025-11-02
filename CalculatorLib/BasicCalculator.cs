
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace CalculatorLib
{
    public class BasicCalculator
    {
        public virtual double InputParsing(string userInput)
        {
            string[] chars = ModifiedUserInput(userInput).Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double num1, num2;
            if (chars.Length != 3)
            {
                throw new IndexOutOfRangeException("Некорректный ввод");
            }
            if (!double.TryParse(chars[0], out num1))
            {
                throw new FormatException("Первое число введено неправильно");
            }
            if (!double.TryParse(chars[2], out num2))
            {
                throw new FormatException("Второе число введено неправильно");
            }
            string mathOperator = chars[1];
            return Calculation(mathOperator, num1, num2);
        }
        public virtual double Calculation(string mathOperator, double num1, double num2)
        {
            double result = mathOperator switch
            {
                "+" => Add(num1, num2),
                "-" => Subtract(num1, num2),
                "*" => Multiply(num1, num2),
                "/" => Divide(num1, num2),
                _ => throw new ArgumentException("Некорректный оператор")
            };
            return result;
        }

        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        public double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }
        public double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }
        public virtual double Divide(double num1, double num2)
        {
            if (num2 == 0) { throw new DivideByZeroException("Divide by zero is not allowed"); }
            return num1 / num2;
        }
        private static readonly string[] possibleOperators = {
            "+", "-", "*", "/", "sqrt", "sin", "cos", "pow", "&",
            "and", "|", "or", "binary", "tobinary", "hex", "tohex"};
        public static string ModifiedUserInput(string userInput)
        {
            string modifiedInput = userInput;
            foreach (string symbol in possibleOperators)
            {
                modifiedInput = modifiedInput.Replace(symbol, $" {symbol} ");
            }
            return modifiedInput;
        }
    }
}
