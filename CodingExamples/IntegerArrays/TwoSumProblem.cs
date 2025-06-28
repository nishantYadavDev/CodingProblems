using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
// problem statement
//Two Sum
//Problem: Given an array of integers nums and an integer target, return the indices of the two numbers such that they add up to target.
//Constraints:
//-2 <= nums.length <= 10⁴
//- -10⁹ <= nums[i] <= 10⁹
//-Exactly one solution exists, and each input has exactly one solution.

namespace CodingExamples.IntegerArray
{
    public class TwoSumProblem
    {
        private readonly int[] numbers;
        Dictionary<int, int> numbersIndexMap;
        public const int NUMBERS_MAX_LENGTH = 10000;
        public const int NUMBERS_MIN_LENGTH = 2;
        public const int NUMBER_MIN_VALUE = -1000000000;
        public const int NUMBER_MAX_VALUE = 1000000000;
        public TwoSumProblem(int[] numbers)
        {
            if (numbers == null)
            {
                throw new NullReferenceException();

            }
            if (numbers.Length < NUMBERS_MIN_LENGTH || numbers.Length > NUMBERS_MAX_LENGTH)
            {
                throw new LengthOutOfRangeException($"Numbers length is not in Range ", NUMBERS_MIN_LENGTH, NUMBERS_MAX_LENGTH);

            }
            //if numbers are not in specified range then also throw the exception

            if (numbers.Any(x => x > NUMBER_MAX_VALUE || x < NUMBER_MIN_VALUE))
            {
                throw new ArgumentOutOfRangeException($"Numbers Contain a value that is not in Range {NUMBER_MIN_VALUE} to {NUMBER_MAX_VALUE}");
            }
            numbersIndexMap = new Dictionary<int, int> { };
            this.numbers = numbers;

        }

        public bool TargetSumExists(int targetSum)
        {

            if (FindTargetIndexes(targetSum) == (-1, -1))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public (int, int) FindTargetIndexes(int targetSum)
        {
            numbersIndexMap.Add(numbers[0], 0);
            for (int i = 1; i < numbers.Length; i++)
            {
                var diff = targetSum - numbers[i];
                if (numbersIndexMap.TryGetValue(diff, out int firstIndex))
                {
                    return (firstIndex, i);
                }
                else
                {
                    numbersIndexMap.TryAdd(numbers[i], i);
                }
            }
            return (-1, -1);
        }

    }
}
