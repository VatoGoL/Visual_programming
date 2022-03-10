using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbr
{
    public class RomanNumberExtend : RomanNumber
    {
        
        public RomanNumberExtend(string num) : base(Converter(num))
        {
              
        }
        private static ushort Converter(string num)
        {
            ushort result = 0;
            foreach (char c in num)
            {
                switch (c)
                {
                    case 'I': 
                        result++; 
                        break;
                    case 'V':
                        result+= 5;
                        break;
                    case 'X':
                        result += 10;
                        break;
                    case 'L':
                        result += 50;
                        break;
                    case 'C':
                        result += 100;
                        break;
                    case 'D':
                        result += 500;
                        break;
                    case 'M':
                        result += 1000;
                        break;
                }
            }
            for(int i = 0; i < num.Length; i++)
            {
                if(i > 0)
                {
                    if ((num[i] == 'X' || num[i] == 'V') && num[i - 1] == 'I')
                    {
                        result-= 1*2;
                    }
                    else if ((num[i] == 'L' || num[i] == 'C') && num[i - 1] == 'X')
                    {
                        result -= 10*2;
                    }
                    else if ((num[i] == 'D' || num[i] == 'M') && num[i - 1] == 'C')
                    {
                        result -= 100*2;
                    }
                }
                
            }

            return result;
        }
    }
}
