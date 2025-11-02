using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    public class ScientificCalculator : BasicCalculator
    {
        public override double InputParsing(string userInput)
        {
            string[] chars = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double num1, num2;
            if (chars.Length == 2)
            {
                string mathOperator = chars[0];
                if (!double.TryParse(chars[1], out num1))
                {
                    throw new FormatException("Первое число введено неправильно");
                }
                return Calculation(mathOperator, num1);
            }
            return base.InputParsing(userInput);
        }
        //понимаю, что дефолтное значение num2 - это костыль, но пока что не придумал ничего лучше.
        public override double Calculation(string mathOperator, double num1, double num2 = 0)
        {
            double result = mathOperator switch
            {
                "sqrt" => Sqrt(num1),
                "sin" => Sin(num1),
                "cos" => Cos(num1),
                "pow" => Pow(num1, num2),
                "/" => Divide(num1, num2),
                _ => base.Calculation(mathOperator, num1, num2)
            };
            return result;
        }
        public override double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                CustomLogger.Log("ERROR", "Divide by zero is not allowed");
                throw new DivideByZeroException();
            }
            CustomLogger.Log("INFO", "Divide started");
            double result = base.Divide(num1, num2);
            CustomLogger.Log("DEBUG", $"Divide finished, Result = {result}");
            return result;
        }
        public double Pow(double num1, double num2)
        {
            return Math.Pow(num1, num2);
        }
        public double Sqrt(double num1)
        {
            return Math.Sqrt(num1);
        }
        public double Sin(double num1)
        {
            return Math.Sin(num1);
        }
        public double Cos(double num1)
        {
            return Math.Cos(num1);
        }
        
    }
}
