using System;

namespace CodingExamples.IntegerArrays
{
//    Problem: Given an integer array nums and an integer k, return the k-th largest element in the array.
//Constraints:
//	• 1 <= k <= nums.length <= 10⁵
//	• -10⁴ <= nums[i] <= 10⁴

    public class KthMostFinder
    {
        public const int NUMBERS_MAX_LENGTH = 100000;
        public const int NUMBERS_MIN_LENGTH = 1;
        public const int NUMBER_MIN_VALUE = -1000000000;
        public const int NUMBER_MAX_VALUE = 1000000000;
        private int[] numbers;
        public bool IsSorted { get; private set; } = false;
        
        public KthMostFinder(int[] numbers)
        {
            ArgumentNullException.ThrowIfNull(numbers, nameof(numbers));
            LengthOutOfRangeException.ThrowIfNotInRange( "Numbers not in Range ",numbers.Length, NUMBERS_MIN_LENGTH, NUMBERS_MAX_LENGTH);
            //if numbers are not in specified range then also throw the exception
            if (numbers.Any(x => x > NUMBER_MAX_VALUE || x < NUMBER_MIN_VALUE))
            {
                throw new ArgumentOutOfRangeException($"Numbers Contain a value that is not in Range {NUMBER_MIN_VALUE} to {NUMBER_MAX_VALUE}");
            }
            this.numbers = numbers;
        }
        public void Sort()
        {
            numbers= numbers.OrderBy(x=>x).ToArray();
            IsSorted = true;
        }
        #region Largest
        public int FindKthLargestNumber(int kth)
        {
            ThrowIfKthValueNotInRange(kth);
            if (IsSorted)
            {
                return numbers[numbers.Length - kth];
            }
            return FindKthLargestUsingMaxHeap(kth);
        }
        public int FindKthLargestUsingMaxHeap(int kth)
        {
            ThrowIfKthValueNotInRange(kth);
            var maxHeap = new PriorityQueue<int, int>();
            int numbersLength = numbers.Length;
            int target = kth;
            for (int i = 0; i < numbersLength; i++)
            {
                int val = numbers[i];
                maxHeap.Enqueue(val, -val);
            }

            int kthElement = 0;
            for (int i = 0; i < kth; i++)
            {
                kthElement = maxHeap.Dequeue();

            }
            return kthElement;
        }
        public int FindKthLargestUsingMinHeap(int kth)
        {
            ThrowIfKthValueNotInRange(kth);
            var minHeap = new PriorityQueue<int, int>();
            int numbersLength = numbers.Length;

            for (int i = 0; i < numbersLength; i++)
            {
                int val = numbers[i];
                minHeap.Enqueue(val, val);
                if (minHeap.Count > kth)
                {
                    //here we will remove the smallest element
                    minHeap.Dequeue();
                }
            }
            return minHeap.Peek();
        }

        public int FindKthLargestUsingQuickSelection(int kth)
        {
            ThrowIfKthValueNotInRange(kth);

            return FindKthMostWithRecursiveQuickSelect(numbers.Length-kth, 0, numbers.Length - 1);
        }
        public int FindKthSmallestUsingQuickSelection(int kth)
        {
            ThrowIfKthValueNotInRange(kth);

            return FindKthMostWithRecursiveQuickSelect(kth-1, 0, numbers.Length - 1);
        }
        private int FindKthMostWithRecursiveQuickSelect(int kth, int low, int high)
        {
            int pivotIndex = GetPartitionIndexUsingLomuto(low, high);
            if (low == high)
            {
                return numbers[low]; 
            }
            if (pivotIndex == kth )
            {
                return numbers[pivotIndex];
            }
            else if (pivotIndex < kth )
            {
                return FindKthMostWithRecursiveQuickSelect(kth, pivotIndex + 1, high);
            }
            else {
                return FindKthMostWithRecursiveQuickSelect(kth, low, pivotIndex - 1);
            }
            
        }
        public int GetPartitionIndexUsingLomuto(int low,int high)
        {
            ThrowIfLowHighNotInIndexRange(low, high);
            int left = low - 1;         
            
            int pivot = numbers[high];
            int i = low, j = high - 1; 
            while (i <= j) {
                
                if (numbers[i] <= pivot)
                {
                    left++;
                    var temp = numbers[left];
                    numbers[left] = numbers[i];
                    numbers[i] = temp;
                }                
                i++;
            }
           
            var t = numbers[left+1];
            numbers[left+1] = pivot;
            numbers[high] = t;
            return left+1;
        }
       
        
        public int GetPartitionIndexUsingHoare(int low, int high)
        {
            //does not gauarrente the correct pivot index in the sorted array
            ThrowIfLowHighNotInIndexRange(low,high);
            int pivot = numbers[low];
            int i = low, j = high;
            while (i < j)
            {

                while (numbers[i] < pivot)
                {                   
                    i++;
                }
                while (numbers[j] > pivot)
                {                   
                    j--;
                }
                if (i < j)
                {
                    var tmp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = tmp;
                }
            }
            return j;
          
        }
        #endregion

        #region Smallest

        public int FindKthSmallestNumber(int kth)
        {
            ThrowIfKthValueNotInRange(kth);
            if (IsSorted)
            {
                return numbers[kth - 1];
            }
            return FindKthSmallestUsingMaxHeap(kth);
        }
        public int FindKthSmallestUsingMaxHeap(int kth)
        {
            ThrowIfKthValueNotInRange(kth);
            var maxHeap = new PriorityQueue<int, int>();
            int numbersLength = numbers.Length;

            for (int i = 0; i < numbersLength; i++)
            {
                int val = numbers[i];
                maxHeap.Enqueue(val, -val);
                if (maxHeap.Count > kth)
                {
                    //here we will remove the largest element
                    maxHeap.Dequeue();
                }
            }
            return maxHeap.Peek();
        }

        #endregion

        private void ThrowIfKthValueNotInRange(int kth)
        {
            if (kth < 1 || kth > numbers.Length)
            {
                throw new ArgumentOutOfRangeException($"{kth} number not in Range {1} to {numbers.Length}");
            }
        }

        private void ThrowIfLowHighNotInIndexRange(int low, int high)
        {
            if (low < 0 || low >= numbers.Length || high < 0 || high >= numbers.Length )
            {
                throw new IndexOutOfRangeException($"Provided index are out of range {low} and {high} possible range {0} to {numbers.Length-1} ");
            }
            ArgumentOutOfRangeException.ThrowIfGreaterThan(low, high);           
        }
    }
}