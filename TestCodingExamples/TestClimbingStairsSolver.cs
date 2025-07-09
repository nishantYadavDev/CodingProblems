using CodingExamples.DynamicProgramming;
using Xunit.Abstractions;

namespace TestCodingExamples
{
    public class TestClimbingStairsSolver
    {
        private readonly ITestOutputHelper _output;
        public TestClimbingStairsSolver(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void TestGetNumberOfWaysSeries_ArgumentOutOfRangeException()
        {
            //Arrange
            var climbingStairs = new ClimbingStairsSolver();
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => climbingStairs.GetNumberOfWaysSeries(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => climbingStairs.GetNumberOfWaysSeries(95));

        }
        [Fact]
        public void TestGetNumberOfWaysSeries()
        {
            //Arrange
            var climbingStairs = new ClimbingStairsSolver();
            //Act
            var firstTerm = climbingStairs.GetNumberOfWaysSeries(1);
            var uptoSecond = climbingStairs.GetNumberOfWaysSeries(2);
            var uptoThird = climbingStairs.GetNumberOfWaysSeries(3);
            var uptoSixth = climbingStairs.GetNumberOfWaysSeries(6);
            //Assert
            Assert.Equal([1], firstTerm);
            Assert.Equal([1, 2], uptoSecond);
            Assert.Equal([1, 2, 3], uptoThird);
            Assert.Equal([1, 2, 3, 5, 8, 13], uptoSixth);
            var upto92 = climbingStairs.GetNumberOfWaysSeries(92);
            _output.WriteLine("Unsigned long Max " + ulong.MaxValue);
            _output.WriteLine("94 element " + upto92[91]);
            _output.WriteLine("93 element " + upto92[90]);
        }
        
       
        [Fact]
        public void TestGetNumber()
        {
            //Arrange
            var climbingStairs = new ClimbingStairsSolver();
            //Assert
            Assert.Equal<ulong>(21, climbingStairs.GetNumberOfWays(7));

        }
    }
}