
using CodingExamples;
using CodingExamples.Strings;

namespace TestCodingExamples
{
    public class TestFirstUniqueCharFinder
    {

        [Fact]
        public void TestStringIsNull()
        {
            //Arrange
            string input = null;
            //Assert
            Assert.Throws<NullReferenceException>(() => new FirstUniqueCharFinder(input));

        }
        [Fact]
        public void TestStringIsOutOfLength()
        {
            //Arrange

            string input = new string(Enumerable.Range(0, FirstUniqueCharFinder.STRING_MAX_LENGTH + 1).Select(x => 'a').ToArray());
            //Assert
            Assert.Equal(FirstUniqueCharFinder.STRING_MAX_LENGTH + 1, input.Length);
            Assert.Throws<LengthOutOfRangeException>(() => new FirstUniqueCharFinder(input));
        }

        [Fact]
        public void TestStringContainsInvalidCharacter()
        {
            //Arrange

            string input = "asdADS";
            //Assert            
            Assert.Throws<ArgumentOutOfRangeException>(() => new FirstUniqueCharFinder(input));

        }
        [Fact]
        public void TestOutsideCharacters()
        {
            //Arrange

            string input = "axcv1";
            //Assert            
            Assert.Throws<ArgumentOutOfRangeException>(() => new FirstUniqueCharFinder(input));

        }
        [Fact]
        public void TestConstructorCreated()
        {
            //Arrange
            string input = "abcvv";
            //Act
            var construct = new FirstUniqueCharFinder(input);
            //Assert            
            Assert.NotNull(construct);
        }
        [Fact]
        public void TestFindUniqueCharIndex()
        {
            //Arrange
            string input = "aabcccvv";
            //Act
            var firstUniqueCharFinder = new FirstUniqueCharFinder(input);
            var actualIndex = firstUniqueCharFinder.FindIndexOfUniqueChar();
            //Assert            
            Assert.Equal(2, actualIndex);
        }
        [Fact]
        public void TestFindUniqueCharIndexAllEqual()
        {
            //Arrange
            string input = "aaaaaaaaaa";
            //Act
            var firstUniqueCharFinder = new FirstUniqueCharFinder(input);
            var actualIndex = firstUniqueCharFinder.FindIndexOfUniqueChar();
            //Assert            
            Assert.Equal(-1, actualIndex);
        }
        [Fact]
        public void TestFindUniqueCharIndexAllButOneEqual()
        {
            //Arrange
            string input = "aaaaaaaaab";
            //Act
            var firstUniqueCharFinder = new FirstUniqueCharFinder(input);
            var actualIndex = firstUniqueCharFinder.FindIndexOfUniqueChar();
            //Assert            
            Assert.Equal(9, actualIndex);
        }
        [Fact]
        public void TestFindUniqueCharIndexRandom()
        {
            //Arrange
            string input = "aabcdefaaa";
            //Act
            var firstUniqueCharFinder = new FirstUniqueCharFinder(input);
            var actualIndex = firstUniqueCharFinder.FindIndexOfUniqueChar();
            //Assert            
            Assert.Equal(2, actualIndex);
        }
        [Fact]
        public void TestFindIndexOfUniqueCharUsingFixedArray()
        {
            //Arrange
            string input = "aabcdefaaa";
            //Act
            var firstUniqueCharFinder = new FirstUniqueCharFinder(input);
            var actualIndex = firstUniqueCharFinder.FindIndexOfUniqueCharUsingFixedArray();
            //Assert            
            Assert.Equal(2, actualIndex);
        }
    }
}