
using CodingExamples;
using CodingExamples.DynamicProgramming;
using CodingExamples.Strings;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace TestCodingExamples
{
    public class TestFibbonaci
    {
        private readonly ITestOutputHelper _output;
        public TestFibbonaci(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void TestGetSeries_ZeroArgumentException()
        {
            //Arrange
           var fibb=new Fibonacci();
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => fibb.GetSeries(0));

        }
        [Fact]
        public void TestGetSeries()
        {
            //Arrange
            var fibb = new Fibonacci();
            //Act
            var firstTerm=fibb.GetSeries(1);
            var uptoSecond= fibb.GetSeries(2);
            var uptoThird = fibb.GetSeries(3);
            var uptoSixth = fibb.GetSeries(6);
            //Assert
            Assert.Equal([0], firstTerm);
            Assert.Equal([0,1], uptoSecond);
            Assert.Equal([0, 1, 1], uptoThird);
            Assert.Equal([0, 1, 1,2,3,5], uptoSixth);
            var upto48= fibb.GetSeries(94);
            _output.WriteLine("Unsigned long Max " + ulong.MaxValue);
            _output.WriteLine("94 element " + upto48[93]);
            _output.WriteLine("93 element " + upto48[92]);
        }
        [Fact]
        public void TestGetSeries_OverflowException()
        {
            //Arrange
            var fibb = new Fibonacci();            
            //Assert
            Assert.Throws<OverflowException>(() => fibb.GetSeries(int.MaxValue));

        }
        [Fact]
        public void TestGetOverflowUptoNumber()
        {
            //Arrange
            var fibb = new Fibonacci();
            _output.WriteLine(""+fibb.GetOverflowUptoNumber());
            //Assert           

        }
        [Fact]
        public void TestGetNumber_OverflowException()
        {
            //Arrange
            var fibb = new Fibonacci();
            //Assert
            Assert.Throws<OverflowException>(() => fibb.GetSeries(95));

        }
        [Fact]
        public void TestGetNumber()
        {
            //Arrange
            var fibb = new Fibonacci();
            //Assert
            Assert.Equal<ulong>(8,fibb.GetNumber(7));

        }
    }
}