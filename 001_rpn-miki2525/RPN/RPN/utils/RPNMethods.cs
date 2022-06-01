using System;

namespace RPN.utils
{
    public class RPNMethods
    {

        public int countFactorial(int n)
        {
            if (n == 0)
                return 1;
            return n * countFactorial(n-1);
        }

        public bool IsNumber(String input, out int valueToPush)
        {
            if (int.TryParse(input, out valueToPush))
            {
                return true;
            }
            char firstChar = (input.ToCharArray()[0]);
            switch (firstChar)
            {
                case 'B':
                    valueToPush = Convert.ToInt32(input.Substring(1), 2);
                    return true;

                case 'D':
                    valueToPush = int.Parse(input.Substring(1));
                    return true;

                case '#':
                    valueToPush = Convert.ToInt32(input.Substring(1), 16);
                    return true;

                default:
                    return false;
            }
        }

        public bool IsOperator(String input) =>
            input.Equals("+") || input.Equals("-") ||
            input.Equals("*") || input.Equals("/");



        public bool IsFactorial(String input) =>
            input.Equals("!");
        }
}
