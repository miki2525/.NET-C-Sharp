using RPN.utils;
using System;
using System.Collections.Generic;

namespace RPNCalulator {
	public class RPN: RPNMethods
	{
		private readonly Stack<int> _operators;
		private readonly Dictionary<string, Func<int, int, int>> _operationFunction;

        public RPN()
        {
			_operationFunction = new Dictionary<string, Func<int, int, int>>
			{
				["+"] = (fst, snd) => fst + snd,
				["-"] = (fst, snd) => fst - snd,
				["*"] = (fst, snd) => fst * snd,
				["/"] = (fst, snd) => fst / snd,
				["!"] = (fst, snd) => countFactorial(fst)
			};
			_operators = new Stack<int>();
		}

		public int EvalRPN(string input) 
		{
			var splitInput = input.Split(' ');
			foreach (var op in splitInput)
			{

				int valueToPush = 0;
				if(IsNumber(op, out valueToPush))
				{
					_operators.Push(valueToPush);
					continue;
				}
				else if (IsOperator(op))
				{
					var num1 = _operators.Pop();
					var num2 = _operators.Pop();
					_operators.Push(_operationFunction[op](num1, num2));
				}
                else if (IsFactorial(op))
                {
					var num1 = _operators.Pop();
					_operators.Push(_operationFunction[op](num1, 0));
				}
			}

			var result = _operators.Pop();
			if (_operators.IsEmpty)
			{
				return result;
			}
			throw new InvalidOperationException();
		}
	}
}