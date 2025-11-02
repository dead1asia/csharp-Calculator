using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    public class ProgrammerCalculator : BasicCalculator
    {
        public override double InputParsing(string userInput)
        {
            string[] chars = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double num1;
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
        public override double Calculation(string mathOperator, double num1, double num2 = 0)
        {
            double result = mathOperator switch
            {
                "&" => And(num1, num2),
                "|" => Or(num1, num2),
                "^" => XOr(num1, num2),
                "binary" => ToBinary(num1),
                "hex" => ToHex(num1),
                _ => base.Calculation(mathOperator, num1, num2)
            };
            return result;
        }

        public double And(double num1, double num2)
        {
            int result = (int)num1 & (int)num2;
            return result;
        }
        public int Or(double num1, double num2)
        {
            int result = (int)num1 | (int)num2;
            return result;
        }
        public int XOr(double num1, double num2)
        {
            int result = (int)num1 ^ (int)num2;
            return result;
        }
        public double ToBinary(double num1)
        {
            string binaryValue = Convert.ToString((int)num1, 2);
            return Convert.ToInt32(binaryValue);
        }

        public int ToHex(double num1)
        {
            string hexValue = Convert.ToString((int)num1, 2);
            return Convert.ToInt32(hexValue);
        }


    }
}
