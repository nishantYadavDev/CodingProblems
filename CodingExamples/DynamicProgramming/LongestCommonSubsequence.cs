using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExamples.DynamicProgramming
{
    public class LongestCommonSubsequence
    {
        public const int MAX_STRING_LENGTH_ALLOW = 10_000_000;
        public int GetMaxLenghtCommonSequence(string first, string second) {
            //bottom up approach           
            int[,] dpTable = GetDpTable(first, second);
            if (dpTable.GetLength(0) == 0 || dpTable.GetLength(1)==0)
            {
                return 0;
            }
            int rows = (first.Length + 1);
            int columns = second.Length + 1;
            return dpTable[rows-1, columns-1];         
        }
        public int[,] GetDpTable(string first, string second)
        {
            if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second)) return new int[0,0];
            ThrowExceptionStringLengthIsMax(first, second);
            int rows = (first.Length + 1);
            int columns = second.Length + 1;
            int[,] dpTable = new int[rows, columns];
            for (int i = 0; i < columns; i++)
            {
                dpTable[0, i] = 0;
            }
            for (int i = 0; i < rows; i++)
            {
                dpTable[i, 0] = 0;
            }
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                {
                    if(first[i - 1] == second[j - 1])
                    {
                        dpTable[i, j] = dpTable[i - 1, j-1]+1;
                    }
                    else
                    {
                        dpTable[i, j] = int.Max(dpTable[i - 1, j], dpTable[i, j - 1]);
                    }
                    
                }
            }
            return dpTable;
        }

       
        public string GetSubsequence(string first, string second)
        {
            int[,] dpTable = GetDpTable(first, second);
            string str = "";
            int rows = dpTable.GetLength(0);
            int columns = dpTable.GetLength(1);
            if (rows == 0 || columns == 0)
            {
                return str;
            }
            StringBuilder sb = new StringBuilder();
            int val = -1;
            int i = rows - 1;
            int j=columns - 1;
            while(val != 0)
            {                
                if (first[i-1] == second[j-1])
                {
                    //strings are 
                    sb.Append(first[i - 1]);
                    i=i - 1;
                    j=j - 1;
                }
                else
                {
                    //choose maximum behind number
                    if (dpTable[i - 1, j] >= dpTable[i, j - 1])
                    {
                        //choosing the top cell
                        i = i - 1;
                    }
                    else {
                        //choosing left
                        j = j - 1;
                    }
                }
                val = dpTable[i, j];
            }
           return  new string(sb.ToString().Reverse().ToArray());
            
        }
        private void ThrowExceptionStringLengthIsMax(string first, string second)
        {
            int maxValueAllow = MAX_STRING_LENGTH_ALLOW;
            ArgumentOutOfRangeException.ThrowIfGreaterThan(first.Length, maxValueAllow, $"First string length is larger than {maxValueAllow}");
            ArgumentOutOfRangeException.ThrowIfGreaterThan(second.Length, maxValueAllow, $"Second string length is larger than {maxValueAllow}");
        }
    }
}
