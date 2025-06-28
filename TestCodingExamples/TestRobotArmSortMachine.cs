using CodingExamples;

namespace TestCodingExamples
{
    public class TestRobotArmSortMachine
    {
        [Fact]
        public void TestGetSortingInstructions_Empty()
        {
            //Arrange
            int[] boxesA, boxesB, boxesC;
            boxesA=new int[0];
            boxesB=new int[0];
            boxesC=new int[0];
            RobotArmSortMachine robotArmSortMachine=new RobotArmSortMachine(boxesA, boxesB, boxesC);
            string[] expected = new string[0];
            //Act 
            var actual = robotArmSortMachine.GetSortingInstructions();
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestGetSortingInstructions_EqualSizeOne()
        {
            //Arrange
            int[] boxesA, boxesB, boxesC;
            boxesA = new int[1];
            boxesB = new int[1];
            boxesC = new int[1];
            RobotArmSortMachine robotArmSortMachine = new RobotArmSortMachine(boxesA, boxesB, boxesC);
            string[] expected = new string[] { "A C", "B A", "C A", "C A" };
            //Act 
            var actual = robotArmSortMachine.GetSortingInstructions();
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestGetSortingInstructions_AlreadySortedA()
        {
            //Arrange
            int[] boxesA, boxesB, boxesC;
            boxesA = new int[4] { 4,3,2,1};
            boxesB = new int[0];
            boxesC = new int[0];
            RobotArmSortMachine robotArmSortMachine = new RobotArmSortMachine(boxesA, boxesB, boxesC);
            string[] expected = new string[0] { };
            //Act 
            var actual = robotArmSortMachine.GetSortingInstructions();
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestGetSortingInstructions_OneBOneC()
        {
            //Arrange
            int[] boxesA, boxesB, boxesC;
            boxesA = new int[0] ;
            boxesB = new int[1] { 1};
            boxesC = new int[1] { 2};
            RobotArmSortMachine robotArmSortMachine = new RobotArmSortMachine(boxesA, boxesB, boxesC);
            string[] expected = new string[2] { "C A","B A"};
            //Act 
            var actual = robotArmSortMachine.GetSortingInstructions();
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}