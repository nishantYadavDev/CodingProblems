
using CodingExamples;
using CodingExamples.DynamicProgramming;
using CodingExamples.Strings;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Numerics;
using System.Windows.Markup;
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
        public void TestGetOverflowUptoNumber()
        {
            //Arrange
            var fibb = new Fibonacci();
            _output.WriteLine(""+fibb.GetOverflowUptoNumber());
            //Assert           

        }
       
        [Fact]
        public void TestGetNumber()
        {
            //Arrange
            var fibb = new Fibonacci();
            //Assert
            Assert.Equal<ulong>(8,fibb.GetNumber(7));

        }
        [Fact]
        public void TestGetBigIntegerNumber()
        {
            //Arrange
            var fibb = new Fibonacci();
            //Assert
            var value = fibb.GetBigIntegerNumber(1000);
            _output.WriteLine("" + value);
            var expected =  BigInteger.Parse("26863810024485359386146727202142923967616609318986952340123175997617981700247881689338369654483356564191827856161443356312976673642210350324634850410377680367334151172899169723197082763985615764450078474174626");
            Assert.Equal<BigInteger>(expected,value);
        }
        [Fact]
        public void TestGetBigIntegerNumber_IntMax()
        {
            //Arrange
            var fibb = new Fibonacci();
            //Assert
            var value = fibb.GetBigIntegerNumber(2_000);
            var outputString= value.ToString();
            _output.WriteLine("Digits length " + outputString.Length);
            _output.WriteLine(outputString);
           
        }
        [Fact]
        public void TestGetBigIntegerNumber_OutOfRange()
        {
            //Arrange
            var fibb = new Fibonacci();
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=> fibb.GetBigIntegerNumber(2_000_001));            

        }
    }
}