using CodingExamples;
using CodingExamples.IntegerArray;
using CodingExamples.IntegerArrays;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ClientProtocol;
using System.Text;
using Xunit.Abstractions;
using static CodingExamples.IntegerArrays.FloodFillSolver;

namespace TestCodingExamples
{
    public class TestFloodFillSolver
    {
        private readonly ITestOutputHelper _output;

        public TestFloodFillSolver(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TestNullImage()
        {
            //Arrange
            int[,] image = null;
            //Act            
            //Assert
            Assert.Throws<NullReferenceException>(() => new FloodFillSolver(image));
        }
        [Fact]
        public void TestZeroLengthColumnImage()
        {
            //Arrange
            int[,] image = new int[1, 0];
            //Act            
            //Assert
            Assert.Throws<LengthOutOfRangeException>(() => new FloodFillSolver(image));
        }
        [Fact]
        public void TestZeroLengthRowImage()
        {
            //Arrange
            int[,] image = new int[0, 1];
            //Act            
            //Assert
            Assert.Throws<LengthOutOfRangeException>(() => new FloodFillSolver(image));
        }
        [Fact]
        public void TestZeroLengthRowColumnImage()
        {
            //Arrange
            int[,] image = new int[0, 0];
            //Act            
            //Assert
            Assert.Throws<LengthOutOfRangeException>(() => new FloodFillSolver(image));
        }
        [Fact]
        public void TestConstructoreCreated()
        {
            //Arrange
            int[,] image = new int[1, 1];
            //Act
            var floodFillSolver = new FloodFillSolver(image);
            //Assert
            Assert.NotNull(floodFillSolver);
            Assert.Equal(1, floodFillSolver.Rows);
            Assert.Equal(1, floodFillSolver.Cols);
        }
        [Fact]
        public void TestImageOutOfPixel()
        {
            //Arrange
            int[,] image = new int[1, 1] { { -1 } };
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new FloodFillSolver(image));
        }
        [Fact]
        public void TestSourcePixelOutOfRangeRow()
        {
            //Arrange
            int[,] image = new int[1, 1] { { 2 } };
            FloodFillSolver.Pixel pixel = new FloodFillSolver.Pixel(1, 0, 1);
            var fsolver = new FloodFillSolver(image);
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => fsolver.FloodFillInNEWSDirection(pixel));
        }
        [Fact]
        public void TestSourcePixelOutOfColumn()
        {
            //Arrange
            int[,] image = new int[1, 1] { { 2 } };
            FloodFillSolver.Pixel pixel = new FloodFillSolver.Pixel(0, 1, 1);
            var fsolver = new FloodFillSolver(image);
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => fsolver.FloodFillInNEWSDirection(pixel));
        }
        [Fact]
        public void TestSourcePixelOutOfValue()
        {
            //Arrange
            int[,] image = new int[1, 1] { { 2 } };
            FloodFillSolver.Pixel pixel = new FloodFillSolver.Pixel(0, 0, -1);
            var fsolver = new FloodFillSolver(image);
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => fsolver.FloodFillInNEWSDirection(pixel));
        }
        [Fact]
        public void TestSourcePixelIsCorrect()
        {
            //Arrange
            int[,] image = new int[1, 1] { { 2 } };
            FloodFillSolver.Pixel pixel = new FloodFillSolver.Pixel(0, 0, 2);
            var fsolver = new FloodFillSolver(image);
            //Assert
            Assert.Equal(image, fsolver.FloodFillInNEWSDirection(pixel));
        }
        [Fact]
        public void TestFloodFill_1()
        {
            //Arrange
            int[,] image = new int[5, 5] {
            { 0,0,0,0,0 },
            { 0,1,0,0,1 },
            { 0,0,1,1,0 },
            { 0,0,1,1,0 },
            { 0,0,0,0,0 }};

            FloodFillSolver.Pixel pixel = new FloodFillSolver.Pixel(2, 2, 2);
            var fsolver = new FloodFillSolver(image);
            //Assert
            int[,] expectedImage = new int[5, 5] {
            { 0,0,0,0,0 },
            { 0,1,0,0,1 },
            { 0,0,2,2,0 },
            { 0,0,2,2,0 },
            { 0,0,0,0,0 }};

            var actual = fsolver.FloodFillInNEWSDirection(pixel);
            _output.WriteLine(Format2DArray(actual));
            Assert.Equal(expectedImage, actual);
        }

        [Fact]
        public void TestFloodFill_SameAllValue()
        {
            //Arrange
            int[,] image = new int[5, 5] {
            { 0,0,0,0,0 },
            { 0,0,0,0,0 },
            { 0,0,0,0,0 },
            { 0,0,0,0,0 },
            { 0,0,0,0,0 }};

            FloodFillSolver.Pixel pixel = new FloodFillSolver.Pixel(2, 2, 0);
            var fsolver = new FloodFillSolver(image);
            //Assert
            int[,] expectedImage = new int[5, 5] {
            { 0,0,0,0,0 },
            { 0,0,0,0,0 },
            { 0,0,0,0,0 },
            { 0,0,0,0,0 },
            { 0,0,0,0,0 }};

            var actual = fsolver.FloodFillInAllDirections(pixel);
            _output.WriteLine(Format2DArray(actual));
            Assert.Equal(expectedImage, actual);
        }
        [Fact]
        public void TestFloodFill_SameAllNewValue()
        {
            //Arrange
            int[,] image = new int[5, 5] {
            { 0,0,0,0,0 },
            { 0,0,0,0,0 },
            { 0,0,0,0,0 },
            { 0,0,0,0,0 },
            { 0,0,0,0,0 }};

            FloodFillSolver.Pixel pixel = new FloodFillSolver.Pixel(2, 2, 2);
            var fsolver = new FloodFillSolver(image);
            //Assert
            int[,] expectedImage = new int[5, 5] {
            { 2,2,2,2,2 },
            { 2,2,2,2,2 },
            {  2,2,2,2,2 },
            {  2,2,2,2,2  },
            { 2,2,2,2,2 }};

            var actual = fsolver.FloodFillInNEWSDirection(pixel);
            _output.WriteLine(Format2DArray(actual));
            Assert.Equal(expectedImage, actual);
        }

        [Fact]
        public void TestFloodFill_InAllDirection()
        {
            //Arrange
            int[,] image = new int[5, 5] {
            { 0,0,0,0,0 },
            { 0,1,0,0,1 },
            { 0,0,1,1,0 },
            { 0,0,1,1,0 },
            { 0,0,0,0,0 }};

            FloodFillSolver.Pixel pixel = new FloodFillSolver.Pixel(2, 2, 2);
            var fsolver = new FloodFillSolver(image);
            //Assert
            int[,] expectedImage = new int[5, 5] {
            { 0,0,0,0,0 },
            { 0,2,0,0,2 },
            { 0,0,2,2,0 },
            { 0,0,2,2,0 },
            { 0,0,0,0,0 }};

            var actual = fsolver.FloodFillInAllDirections(pixel);

            _output.WriteLine(Format2DArray(actual));
            Assert.Equal(expectedImage, actual);
        }

        [Fact]
        public void TestFloodFill_InNEWSDirection()
        {
            //Arrange
            int[,] image = new int[5, 5] {
            { 0,0,0,0,0 },
            { 0,1,1,1,1 },
            { 0,1,1,1,0 },
            { 0,1,1,1,0 },
            { 0,0,0,0,0 }};

            FloodFillSolver.Pixel pixel = new FloodFillSolver.Pixel(2, 2, 2);
            var fsolver = new FloodFillSolver(image);
            //Assert
            int[,] expectedImage = new int[5, 5] {
            { 0,0,0,0,0 },
            { 0,2,2,2,2 },
            { 0,2,2,2,0 },
            { 0,2,2,2,0 },
            { 0,0,0,0,0 }};

            var actual = fsolver.FloodFillInNEWSDirection(pixel);

            _output.WriteLine(Format2DArray(actual));
            Assert.Equal(expectedImage, actual);
        }

        [Fact]
        public void TestFloodFill_InDiagonalDirection()
        {
            //Arrange
            int[,] image = new int[5, 5] {
            { 0,0,0,0,0 },
            { 0,1,0,1,1 },
            { 0,0,1,1,0 },
            { 0,1,1,1,0 },
            { 0,0,0,0,0 }};

            FloodFillSolver.Pixel pixel = new FloodFillSolver.Pixel(2, 2, 2);
            var fsolver = new FloodFillSolver(image);
            //Assert
            int[,] expectedImage = new int[5, 5] {
            { 0,0,0,0,0 },
            { 0,2,0,2,1 },
            { 0,0,2,1,0 },
            { 0,2,1,2,0 },
            { 0,0,0,0,0 }};

            var actual = fsolver.FloodFillInDiagonalDirection(pixel);

            _output.WriteLine(Format2DArray(actual));
            Assert.Equal(expectedImage, actual);
        }
        public void TestFloodFill_Random()
        {
            //Arrange
            int rows = 6;
            int cols = 6;
            Random rand = new Random();

            int[,] image = new int[rows, cols];
            Enumerable.Range(0, rows * cols)
          .Select(_ => rand.Next(FloodFillSolver.IMAGE_PIXEL_MIN_VALUE, 4)) // Random values between 0 and 99
          .Select((val, index) => new { Row = index / cols, Col = index % cols, Value = val })
          .ToList()
          .ForEach(x => image[x.Row, x.Col] = x.Value);

            FloodFillSolver.Pixel pixel = new FloodFillSolver.Pixel(1, 1, 4);
            int[,] testArr= (int[,])image.Clone();
            
            var fsolver = new FloodFillSolver(testArr);
            //Assert
            

             var actual = fsolver.FloodFillInAllDirections(pixel);
            _output.WriteLine(Format2DArray(image));
            _output.WriteLine(Format2DArray(actual));
            Assert.Equal(image, actual);
        }

        private string Format2DArray(int[,] array)
        {
            var sb = new StringBuilder();
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append(array[i, j]).Append(j < cols - 1 ? ", " : "");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

    }
}