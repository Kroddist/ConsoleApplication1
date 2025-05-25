using System;
using System.Collections.Generic;

namespace WinFormsApp1.RomanNumerals
{
    public class RomanNumber : IRomanExpression
    {
        private readonly string _roman;
        private static readonly Dictionary<char, int> _romanValues = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public RomanNumber(string roman)
        {
            _roman = roman.ToUpper();
        }

        public int Interpret()
        {
            int result = 0;
            int previousValue = 0;

            for (int i = _roman.Length - 1; i >= 0; i--)
            {
                int currentValue = _romanValues[_roman[i]];

                if (currentValue >= previousValue)
                {
                    result += currentValue;
                }
                else
                {
                    result -= currentValue;
                }

                previousValue = currentValue;
            }

            return result;
        }
    }
} 