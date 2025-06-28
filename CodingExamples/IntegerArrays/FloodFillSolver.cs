
//Problem: Flood Fill
//You are given a 2D array image representing a grid of pixel values, where image[i][j] denotes the color of the pixel at row i and column j. You are also given three integers: sr, sc, and newColor.
//- (sr, sc) represents the starting pixel.
//- newColor is the color you want to apply.
//Your task is to perform a flood fill starting from the pixel (sr, sc). Replace the color of the starting pixel and all 4-directionally connected pixels (up, down, left, right) that have the same original color as the starting pixel with newColor.
//Return the modified image after performing the flood fill.

//📥 Input
//- image: int[][] — a 2D array of integers (0 ≤ imagei[i][j] ≤ 10)
//- sr: int — starting row index (0 ≤ sr < image.length)
//- sc: int — starting column index (0 ≤ sc < image[0].length)
//- newColor: int — the new color to apply (0 ≤ newColor ≤ 10)

//📤 Output
//- int[][] — the updated image after flood fill

//🧪 Example
//Input:
//image = [[1,1,1],
//         [1,1,0],
//         [1,0,1]]
//sr = 1, sc = 1, newColor = 2

//Output:
//[[2,2,2],
// [2,2,0],
// [2,0,1]]

//Input Constraints
//| Parameter | Constraint | 
//| image | 2D array of size n × m | 
//| n, m | 1 ≤ n, m ≤ 512 | 
//| image[i][j] | 0 ≤ image[i][j] ≤ 255 | 
//| sr, sc | 0 ≤ sr < n, 0 ≤ sc < m | 
//| newColor | 0 ≤ newColor ≤ 255 | 


namespace CodingExamples.IntegerArrays
{
    public class FloodFillSolver
    {
       
        public const int IMAGE_DIMENSION_MAX_LENGTH = 512;
        public const int IMAGE_DIMENSION_MIN_LENGTH = 1;
        public const int IMAGE_PIXEL_MIN_VALUE = 0;
        public const int IMAGE_PIXEL_MAX_VALUE = 255;
        public int Rows { get; }
        public int Cols { get; }
        private int[,] image;
        private int[,] directionsNEWS=new int[,] { { -1,0}, { 0, 1 }, { 0, -1 } , { 1, 0 } };
        private int[,] directionsDiagonal = new int[,] { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
        private int[,] allDirections = new int[,] { { -1, 0 }, { 0, 1 }, { 0, -1 }, { 1, 0 },
            { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
        
        public struct Pixel
        {
            public int row;
            public int col;
            public int value;
            public Pixel(int row, int col, int value)
            {
                this.row = row;
                this.col = col;
                this.value = value;
            }
            public readonly bool IsPixelRowInRange(int minInclusive, int maxInclusive)
            {
                return (row >= minInclusive && row <= maxInclusive);
            }
            public readonly bool IsPixelColInRange(int minInclusive, int maxInclusive)
            {
                return (col >= minInclusive && col <= maxInclusive);
            }
            public readonly bool IsPixelValueInRange(int minInclusive, int maxInclusive)
            {
                return (value >= minInclusive && value <= maxInclusive);
            }
            public readonly Pixel GetNewPixelByRow(int row)
            {
                return new Pixel(row, col, value);
            }
            public readonly Pixel GetNewPixelByCol(int col)
            {
                return new Pixel(row, col, value);
            }
            public readonly Pixel GetNewPixelByValue(int value)
            {
                return new Pixel(row, col, value);
            }
            public readonly Pixel GetNewPixelByRowCol(int row,int col)
            {
                return new Pixel(row, col, value);
            }
        }
        public FloodFillSolver(int[,] image)
        {
            if (image == null)
            {
                throw new NullReferenceException("provided image  2D array is null");

            }
            Rows = image.GetLength(0);
            if (Rows < IMAGE_DIMENSION_MIN_LENGTH || Rows > IMAGE_DIMENSION_MAX_LENGTH)
            {
                throw new LengthOutOfRangeException($"Image row dimension is not in Range ", IMAGE_DIMENSION_MIN_LENGTH, IMAGE_DIMENSION_MAX_LENGTH);
            }
            Cols = image.GetLength(1);
            if (Cols < IMAGE_DIMENSION_MIN_LENGTH || Cols > IMAGE_DIMENSION_MAX_LENGTH)
            {
                throw new LengthOutOfRangeException($"Image column dimension is not in Range ", IMAGE_DIMENSION_MIN_LENGTH, IMAGE_DIMENSION_MAX_LENGTH);
            }
            if (AnyOutOfRangePixelInImage(image))
            {
                throw new ArgumentOutOfRangeException($"Image Contains a pixel value that is not in Range {IMAGE_PIXEL_MIN_VALUE} to {IMAGE_PIXEL_MAX_VALUE}");
            }
            this.image = image;
        }
        private bool AnyOutOfRangePixelInImage(int[,] image)
        {
            //flatten the array 
            var allValues = image.Cast<int>();
            bool anyOutOfRangePixel = allValues.Any(v => v < IMAGE_PIXEL_MIN_VALUE || v > IMAGE_PIXEL_MAX_VALUE);
            return anyOutOfRangePixel;
        }
        /// <summary>
        /// Fills the image with a source pixel and color value by using recursion
        /// </summary>

        
        private void ValidateSourcePixel(Pixel srcPixel)
        {
            if (!srcPixel.IsPixelRowInRange(0, Rows - 1))
            {
                throw new ArgumentOutOfRangeException($"Source pixel row  is out of range {0} to {Rows - 1}");
            }
            if (!srcPixel.IsPixelColInRange(0, Cols - 1))
            {
                throw new ArgumentOutOfRangeException($"Source pixel column is out of range {0} to {Cols - 1}");
            }
            if (!srcPixel.IsPixelValueInRange(IMAGE_PIXEL_MIN_VALUE, IMAGE_PIXEL_MAX_VALUE))
            {
                throw new ArgumentOutOfRangeException($"Source pixel value is out of range {IMAGE_PIXEL_MIN_VALUE} to {IMAGE_PIXEL_MAX_VALUE}");
            }
        }
        public int[,] FloodFillInNEWSDirection(Pixel srcPixel)
        {
            ValidateSourcePixel(srcPixel);
            RecursivelyFillImageWith(srcPixel, image[srcPixel.row, srcPixel.col],directionsNEWS);
            return image;
        }
        public int[,] FloodFillInDiagonalDirection(Pixel srcPixel)
        {
            ValidateSourcePixel(srcPixel);
            RecursivelyFillImageWith(srcPixel, image[srcPixel.row, srcPixel.col],directionsDiagonal);
            return image;
        }
        public int[,] FloodFillInAllDirections(Pixel srcPixel)
        {
            ValidateSourcePixel(srcPixel);
            RecursivelyFillImageWith(srcPixel, image[srcPixel.row, srcPixel.col],allDirections);
            return image;
        }
        private void RecursivelyFillImageWith(Pixel srcPixel,int oldValue, int[,] directions)
        {
            if(oldValue == srcPixel.value)
            {
                return;
            }
            image[srcPixel.row, srcPixel.col] = srcPixel.value;
            int directionsRowCount = directions.GetLength(0);
            //moving in North East West South directions
            for (int i = 0; i < directionsRowCount; i++)
            {
                int rowPosition= srcPixel.row + directions[i,0];
                int colPosition = srcPixel.col + directions[i, 1];
                if (rowPosition >= 0 && rowPosition < Rows && colPosition>=0 && colPosition<Cols && image[rowPosition, colPosition] == oldValue)
                {
                    RecursivelyFillImageWith(srcPixel.GetNewPixelByRowCol(rowPosition,colPosition), oldValue, directions);
                }
            }
            
           
        }
        }
    }

