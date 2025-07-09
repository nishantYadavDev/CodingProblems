using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExamples.Strings
{
    public static class OutputUtility
    {
        public static string Print2DArray<T>(T[,] data)
        {
            if(data == null)
            {
                return "";
            }
            int rows=data.GetLength(0);
            int cols=data.GetLength(1);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    sb.Append($"{data[i,j]} ");
                }
                sb.Append($"\n");
            }
            return sb.ToString();
        }
        public static string Print<T>(IEnumerable<T> data)
        {
            if (data == null)
            {
                return "";
            }           
            StringBuilder sb = new StringBuilder();
            foreach (T item in data) {
                sb.Append($"{item} ");
            }
                
            return sb.ToString();
        }
    }
}
