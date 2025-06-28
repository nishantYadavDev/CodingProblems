
using CodingExamples;
using CodingExamples.Strings;
using System.Text;

namespace TestCodingExamples
{
    public class TestValidParentheses
    {

        [Fact]
        public void TestStringIsNull()
        {
            //Arrange
            string parentheses = null;
            //Assert
            Assert.Throws<NullReferenceException>(() => new ValidParantheses(parentheses));

        }
        [Fact]
        public void TestStringIsOutOfLength()
        {
            //Arrange
            
            string parentheses = new string(Enumerable.Range(0,ValidParantheses.STRING_MAX_LENGTH+1).Select(x=>'a').ToArray());
            //Assert
            Assert.Equal(ValidParantheses.STRING_MAX_LENGTH+1 , parentheses.Length);
            Assert.Throws<LengthOutOfRangeException>(() => new ValidParantheses(parentheses));
        }

        [Fact]
        public void TestStringContainsInvalidCharacter()
        {
            //Arrange

            string parentheses = "()&";
            //Assert            
            Assert.Throws<ArgumentOutOfRangeException>(() => new ValidParantheses(parentheses));

        }
        [Fact]
        public void TestOutsideCharacters()
        {
            //Arrange

            string parentheses = "5657dfdnb7bdbnd&";
            //Assert            
            Assert.Throws<ArgumentOutOfRangeException>(() => new ValidParantheses(parentheses));

        }
        [Fact]
        public void TestConstructorCreated()
        {
            //Arrange
            string parentheses = "()[]{}";
            //Act
            var construct= new ValidParantheses(parentheses);
            //Assert            
            Assert.NotNull(construct);
        }
        [Fact]
        public void TestIsValidParentheses()
        {
            //Arrange
            string parentheses = "()[]{}";
            //Act
            var vp = new ValidParantheses(parentheses);
            //Assert            
            Assert.True(vp.IsParenthesesValid());
        }
        [Fact]
        public void TestIsValidParenthesesSingleLeft()
        {
            //Arrange
            string parentheses = "(";
            //Act
            var vp = new ValidParantheses(parentheses);
            //Assert            
            Assert.False(vp.IsParenthesesValid());
        }
        [Fact]
        public void TestIsValidParenthesesSingleRight()
        {
            //Arrange
            string parentheses = "}";
            //Act
            var vp = new ValidParantheses(parentheses);
            //Assert            
            Assert.False(vp.IsParenthesesValid());
        }
        [Fact]
        public void TestIsValidParenthesesTwoThenSingleRight()
        {
            //Arrange
            string parentheses = "{}}";
            //Act
            var vp = new ValidParantheses(parentheses);
            //Assert            
            Assert.False(vp.IsParenthesesValid());
        }
        [Fact]
        public void TestIsValidParenthesesOpposite()
        {
            //Arrange
            string parentheses = ")(][}{";
            //Act
            var vp = new ValidParantheses(parentheses);
            //Assert            
            Assert.False(vp.IsParenthesesValid());
        }
    }
}