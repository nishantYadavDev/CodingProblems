using CodingExamples;
using CodingExamples.IntegerArray;

namespace TestCodingExamples
{
    public class TestTwoSumProblem
    {

        [Fact]
        public void TestTargetSumExists_TwoElement()
        {
            //Arrange
            int[] numbers = new int[3] { 1, 3, 2 };
            int targetSum = 5;
            TwoSumProblem twoSumProblem = new TwoSumProblem(numbers);
            //Act 
            var actual = twoSumProblem.TargetSumExists(targetSum);
            //Assert
            Assert.True(actual);
        }
        [Fact]
        public void TestNullArray()
        {
            //Arrange
            int[] numbers = null;
            //Act            
            //Assert
            Assert.Throws<NullReferenceException>(() => new TwoSumProblem(numbers));
        }
        [Fact]
        public void TestFindIndicesOfTargetSum()
        {
            //Arrange
            int[] numbers = new int[] { 1, 3, 2, 4, 5, 4, 2 };
            int targetSum = 10;
            TwoSumProblem twoSumProblem = new TwoSumProblem(numbers);
            //Act 
            var actual = twoSumProblem.FindTargetIndexes(targetSum);
            //Assert
            Assert.Equal(actual, (-1, -1));
        }
        [Fact]
        public void TestFindIndicesOfTargetSum_ArrayLengthLarge()
        {
            //Arrange
            int[] numbers = new int[TwoSumProblem.NUMBERS_MAX_LENGTH + 1];
            //Act Assert
            Assert.Throws<LengthOutOfRangeException>(() => new TwoSumProblem(numbers));

        }
        [Fact]
        public void TestFindIndicesOfTargetSum_ArrayLengthSmall()
        {
            //Arrange
            int[] numbers = new int[1];
            //Act Assert
            Assert.Throws<LengthOutOfRangeException>(() => new TwoSumProblem(numbers));

        }
        [Fact]
        public void TestFindIndicesOfTargetSum_ArrayContainsOutOfRangeValue()
        {
            //Arrange
            int[] numbers = new int[] { 2, 08, TwoSumProblem.NUMBER_MAX_VALUE + 1 };
            //Act Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new TwoSumProblem(numbers));

        }
    }
}