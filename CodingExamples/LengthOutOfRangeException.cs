﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExamples
{
    public class LengthOutOfRangeException : Exception
    {
        public int minLength, maxLength;
        public LengthOutOfRangeException(string msg,int minLength,int maxLength):base(msg)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
            msg += $"Expected Range {minLength} to {maxLength}";
        }
        public static void ThrowIfNotInRange(string msg,int length, int minLengthInclusive, int maxLengthInclusive)
        {
            if(length < minLengthInclusive || length > maxLengthInclusive)
            {
                throw new LengthOutOfRangeException(msg,minLengthInclusive,maxLengthInclusive);
            }
        }
    }
}
