using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExamples.DynamicProgramming
{
    public class Fibonacci
    {
       public ulong[] GetSeries(uint uptoN)
        {
            List<ulong> series= new List<ulong>();
            ArgumentOutOfRangeException.ThrowIfLessThan<uint>(uptoN, 1);
            if (uptoN == 1)
            {
                series.Add(0);
            }
            else if (uptoN == 2)
            {
                series.Add(0);
                series.Add(1);
            }
            else {
                ulong first = 0; series.Add(0);
                ulong second = 1; series.Add(1);
               
                for (uint i = 3; i <= uptoN; i++) {
                    ulong val =checked( first + second);
                    series.Add(val);
                    first = second;
                    second = val;
                }
            }
            return [.. series];
        }
        public ulong GetNumber(uint nth)
        {          
            ArgumentOutOfRangeException.ThrowIfLessThan<uint>(nth, 1);
            ulong first = 0;
            ulong second = 1;
            if (nth == 1)
            {
                return first;
            }
            else if (nth == 2)
            {
                return second;
            }
            else
            { 
                for (uint i = 3; i <= nth; i++)
                {
                    ulong val = checked(first + second);                    
                    first = second;
                    second = val;
                }
            }
            return second;
        }
        public ulong GetOverflowUptoNumber()
        {
            ulong first = 0;
            ulong second = 1;
            uint i = 3;
            for (; i < int.MaxValue/2; i++)
            {
                try
                {
                    ulong val = checked(first + second);
                    first = second;
                    second = val;
                }
                catch(OverflowException oe) {

                    return i;
                }
              
            }
            return i;
        }
    }
}
