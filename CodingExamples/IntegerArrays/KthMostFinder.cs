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
            throw new NotImplementedException();
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


    }
}