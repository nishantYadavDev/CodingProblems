using CodingExamples.DynamicProgramming;
using CodingExamples.Strings;
using Xunit.Abstractions;

namespace TestCodingExamples
{
    public class TestLongestCommonSubsequence
    {
        private readonly ITestOutputHelper _output;
        public TestLongestCommonSubsequence(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void TestGetMaxLenghtCommonSequence()
        {
            //Arrange
            var lcs = new LongestCommonSubsequence();
            //Assert
            Assert.Equal(0, lcs.GetMaxLenghtCommonSequence(null, "ab"));
            Assert.Equal(0, lcs.GetMaxLenghtCommonSequence( "ab",null));
            Assert.Equal(0, lcs.GetMaxLenghtCommonSequence("", ""));
            Assert.Equal(1, lcs.GetMaxLenghtCommonSequence("a", "ab"));
            Assert.Equal(1, lcs.GetMaxLenghtCommonSequence("ab", "a"));
            Assert.Equal(0, lcs.GetMaxLenghtCommonSequence("ab", "cd"));
            Assert.Equal(4, lcs.GetMaxLenghtCommonSequence("AGGTAB", "GXTXAYB"));
            Assert.Equal(3, lcs.GetMaxLenghtCommonSequence("abcdgh", "aedfhr"));
        }
        [Fact]
        public void TestGetMaxLenghtCommonSequence_stringLengthMax()
        {
            //Arrange
            var lcs = new LongestCommonSubsequence();
            //Assert
           string str=string.Join("",Enumerable.Range(0, LongestCommonSubsequence. MAX_STRING_LENGTH_ALLOW).Select(i => i.ToString()));
            Assert.Throws<ArgumentOutOfRangeException>(() => lcs.GetMaxLenghtCommonSequence(str, "qw"));
        }
        [Fact]
        public void TestGetSubSequence()
        {
            //Arrange
            var lcs = new LongestCommonSubsequence();
            //Assert
            Assert.Equal("", lcs.GetSubsequence(null, "ab"));
            Assert.Equal("", lcs.GetSubsequence("ab", null));
            Assert.Equal("", lcs.GetSubsequence("", ""));
            Assert.Equal("a", lcs.GetSubsequence("a", "ab"));
            Assert.Equal("a", lcs.GetSubsequence("ab", "a"));
            Assert.Equal("", lcs.GetSubsequence("ab", "cd"));
            Assert.Equal("GTAB", lcs.GetSubsequence("AGGTAB", "GXTXAYB"));
            Assert.Equal("adh", lcs.GetSubsequence("abcdgh", "aedfhr"));
        }
    }
}