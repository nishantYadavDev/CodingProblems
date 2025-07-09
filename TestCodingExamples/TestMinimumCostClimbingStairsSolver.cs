using CodingExamples;
using CodingExamples.DynamicProgramming;
using CodingExamples.Strings;
using Xunit.Abstractions;

namespace TestCodingExamples
{
    public class TestMinimumCostClimbingStairsSolver
    {
        private readonly ITestOutputHelper _output;
        public TestMinimumCostClimbingStairsSolver(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void TestMinimumCostClimbingStairsSolver_ConstructorException()
        {
            //Arrange
            uint[] a = null;
            uint[] b = [1];
            uint[] c = new uint[MinimumCostClimbingStairsSolver.MAX_COST_LENGTH + 1];
            uint[] d = [1, MinimumCostClimbingStairsSolver.MAX_COST_VALUE+1];
            //Assert
            Assert.Throws<ArgumentNullException>(() => new MinimumCostClimbingStairsSolver(a));
            Assert.Throws<LengthOutOfRangeException>(() => new MinimumCostClimbingStairsSolver(b));
            Assert.Throws<LengthOutOfRangeException>(() => new MinimumCostClimbingStairsSolver(c));
            Assert.Throws<ArgumentOutOfRangeException>(() => new MinimumCostClimbingStairsSolver(d));
        }
        [Fact]
        public void TestGetMinimumCostToReachTop()
        {
            //Arrange
            uint[] costs = [10,15,20];
            //Act
            var minCostSolver = new MinimumCostClimbingStairsSolver(costs);
            var actualCostToReachTop = minCostSolver.GetMinimumCostToReachTop();
            //Assert
            Assert.Equal<uint>(15, actualCostToReachTop);

        }
        [Fact]
        public void TestGetMinimumCostToReachTop_SixElement()
        {
            //Arrange
            uint[] costs = [10, 15, 20,30,40,50];
            //Act
            var minCostSolver = new MinimumCostClimbingStairsSolver(costs);
            var actualCostToReachTop = minCostSolver.GetMinimumCostToReachTop();
            _output.WriteLine(actualCostToReachTop.ToString());
            //Assert
            Assert.Equal<uint>(70, actualCostToReachTop);

        }
        [Fact]
        public void TestGetListOfCostIncurred_SixIncreasingElement()
        {
            //Arrange
            uint[] costs = [10, 15, 20, 30, 40, 50];
            //Act
            var minCostSolver = new MinimumCostClimbingStairsSolver(costs);
            var actualCostArray = minCostSolver.GetListOfCostIncurred();
            _output.WriteLine(OutputUtility.Print(actualCostArray));
            //Assert
            Assert.Equal<uint>([10,20,40], actualCostArray);

        }
        [Fact]
        public void TestGetListOfCostIncurred_SixElement()
        {
            //Arrange
            uint[] costs = [30, 15, 20, 10, 40, 25];
            //Act
            var minCostSolver = new MinimumCostClimbingStairsSolver(costs);
            var actualCostArray = minCostSolver.GetListOfCostIncurred();
            _output.WriteLine(OutputUtility.Print(actualCostArray));
            //Assert
            Assert.Equal<uint>([15, 10, 25], actualCostArray);

        }
    }
}