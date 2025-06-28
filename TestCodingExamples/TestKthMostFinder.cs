using CodingExamples;
using CodingExamples.IntegerArray;
using CodingExamples.IntegerArrays;

namespace TestCodingExamples
{
    public class TestKthMostFinder
    {
        [Fact]
        public void TestKtthLargestFinderNullArray()
        {
            //Arrange
            int[] numbers = null;
           
            //Act            
            //Assert
            Assert.Throws<ArgumentNullException>(()=>new KthMostFinder(numbers) );
        }
        [Fact]
        public void TestKthLargestFinderArrayLengthNotInRange()
        {
            //Arrange
            int[] numbers = new int[0];
            int[] largeSizeMumbers = new int[KthMostFinder.NUMBERS_MAX_LENGTH+1];
            //Act            
            //Assert
            Assert.Throws<LengthOutOfRangeException>(() => new KthMostFinder(numbers));
            Assert.Throws<LengthOutOfRangeException>(() => new KthMostFinder(largeSizeMumbers));
        }
        [Fact]
        public void TestKthLargestFinderValueNotInRange()
        {
            //Arrange
            int[] numbers = new int[2] { KthMostFinder .NUMBER_MIN_VALUE-1, KthMostFinder.NUMBER_MAX_VALUE  };

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new KthMostFinder(numbers));
            numbers[0] = KthMostFinder.NUMBER_MIN_VALUE ;
            numbers[1] = KthMostFinder.NUMBER_MAX_VALUE + 1;
            Assert.Throws<ArgumentOutOfRangeException>(() => new KthMostFinder(numbers));
        }
        [Fact]
        public void TestKthLargestFinderKthValueNotItRange()
        {
            //Arrange
            int[] numbers = new int[4] {21,4,8,2};
            var kthfinder= new KthMostFinder(numbers);
            //Act            
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => kthfinder.FindKthLargestNumber(0));           
            Assert.Throws<ArgumentOutOfRangeException>(() => kthfinder.FindKthLargestNumber(5));
        }
        [Fact]
        public void TestKthLargestFinderKthValueAfterSort()
        {
            //Arrange
            int[] numbers = new int[] { 21, 4, 8, 2 ,45,31,89,5,4};
            var kthfinder = new KthMostFinder(numbers);
            //Act
            kthfinder.Sort();           
            //Assert
            Assert.Equal(45, kthfinder.FindKthLargestNumber(2));
            Assert.Equal(89, kthfinder.FindKthLargestNumber(1));
            Assert.Equal(31, kthfinder.FindKthLargestNumber(3));
        }
        [Fact]
        public void TestKthLargestFinderUsingMaxHeap()
        {
            //Arrange
            int[] numbers = new int[] { 21, 4, 8, 2, 45, 31, 89, 5, 4 };
            var kthfinder = new KthMostFinder(numbers);
            //Act
            
            //Assert
            Assert.Equal(45, kthfinder.FindKthLargestUsingMaxHeap(2));
            Assert.Equal(89, kthfinder.FindKthLargestUsingMaxHeap(1));
            Assert.Equal(31, kthfinder.FindKthLargestUsingMaxHeap(3));
        }
        [Fact]
        public void TestKthLargestFinderUsingMinHeap()
        {
            //Arrange
            int[] numbers = new int[] { 21, 4, 8, 2, 45, 31, 89, 5, 4 };
            var kthfinder = new KthMostFinder(numbers);
            //Act

            //Assert
            Assert.Equal(45, kthfinder.FindKthLargestUsingMinHeap(2));
            Assert.Equal(89, kthfinder.FindKthLargestUsingMinHeap(1));
            Assert.Equal(31, kthfinder.FindKthLargestUsingMinHeap(3));
        }
        [Fact]
        public void TestKthSmallestFinderUsingMaxHeap()
        {
            //Arrange
            int[] numbers = new int[] { 21, 4, 8, 2, 45, 31, 89, 5, 4 };
            var kthfinder = new KthMostFinder(numbers);
            //Act

            //Assert
            Assert.Equal(4, kthfinder.FindKthSmallestNumber(2));
            kthfinder.Sort();
            Assert.Equal(2, kthfinder.FindKthSmallestNumber(1));
            Assert.Equal(4, kthfinder.FindKthSmallestUsingMaxHeap(3));
        }
    }
}