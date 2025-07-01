using CodingExamples;
using CodingExamples.IntegerArray;
using CodingExamples.IntegerArrays;
using System.Text;
using Xunit.Abstractions;

namespace TestCodingExamples
{
    public class TestKthMostFinder
    {
        private readonly ITestOutputHelper _output;

        public TestKthMostFinder(ITestOutputHelper output)
        {
            _output = output;
        }
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
        [Fact]
        public void TestGetPartitionIndexUsingHoare()
        {
            //Arrange
            int[] numbers = new int[] { 21, 4, 8, 2, 45, 31, 89, 5, 9, 4, 2, 7, 10, 4 };
            var kthfinder = new KthMostFinder(numbers);
            //Act
            _output.WriteLine(ConvertToString(numbers));
            var index = kthfinder.GetPartitionIndexUsingHoare(0, numbers.Length - 1);
            _output.WriteLine(ConvertToString(numbers));
            _output.WriteLine($"Partition Index is {index} : value  {numbers[index]} ");
            //Assert

        }
        [Fact]
        public void TestGetPartitionIndexUsingLomuto()
        {
            //Arrange
            int[] numbers = new int[] { 21, 4, 8, 2, 45, 31, 89, 5, 9, 4, 2, 7, 10, 4 };
            var kthfinder = new KthMostFinder(numbers);
            //Act
            _output.WriteLine(ConvertToString(numbers));
            var index = kthfinder.GetPartitionIndexUsingLomuto(0, numbers.Length-1);
            _output.WriteLine(ConvertToString(numbers));
            _output.WriteLine($"Partition Index is {index} : value  {numbers[index]} ");
            //Assert

        }
        [Fact]
        public void TestGetPartitionIndexUsingLomuto_ThrowException()
        {
            //Arrange
            int[] numbers = new int[] { 21, 3,8 };
            var kthfinder = new KthMostFinder(numbers);
            //Act Assert
            Assert.Throws<IndexOutOfRangeException>(()=>kthfinder.GetPartitionIndexUsingLomuto(0, numbers.Length)); 
         }
        [Fact]
        public void TestGetPartitionIndexUsingLomuto_ThrowArgumentException()
        {
            //Arrange
            int[] numbers = new int[] { 21, 3, 8 };
            var kthfinder = new KthMostFinder(numbers);
            //Act Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => kthfinder.GetPartitionIndexUsingLomuto(2, 1));
        }

        [Fact]
        public void TestFindKthLargestUsingQuickSelection()
        {
            //Arrange
            int[] numbers = new int[] { 21, 4, 8, 2, 45, 31, 89, 5, 4 };
            var kthfinder = new KthMostFinder(numbers);
            //Act
            var index = kthfinder.GetPartitionIndexUsingLomuto(0, numbers.Length - 1);
            _output.WriteLine(ConvertToString(numbers));
            _output.WriteLine($"Partition Index is {index} : value  {numbers[index]} ");

            //Assert
            Assert.Equal(45, kthfinder.FindKthLargestUsingQuickSelection(2));
            Assert.Equal(89, kthfinder.FindKthLargestUsingQuickSelection(1));
            Assert.Equal(31, kthfinder.FindKthLargestUsingQuickSelection(3));

        }
        [Fact]
        public void TestFindKthSmallestUsingQuickSelection()
        {
            //Arrange
            int[] numbers = new int[] { 21, 4, 8, 2, 45, 31, 89, 5, 4 };
            var kthfinder = new KthMostFinder(numbers);
            //Act

            //Assert
            Assert.Equal(4, kthfinder.FindKthSmallestUsingQuickSelection(2));           
            Assert.Equal(2, kthfinder.FindKthSmallestUsingQuickSelection(1));
            Assert.Equal(4, kthfinder.FindKthSmallestUsingQuickSelection(3));
        }
        private string ConvertToString(int[] numbers)
        {
            var sb = new StringBuilder();
            foreach (var number in numbers) {
                sb.Append($"{number},");
            }
            return sb.ToString();
        }
    }
}