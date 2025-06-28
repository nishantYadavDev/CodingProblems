using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Problem statement
//Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

//An input string is valid if:

//Open brackets must be closed by the same type of brackets.
//Open brackets must be closed in the correct order.
//Every close bracket has a corresponding open bracket of the same type.
//Constraints:

//1 <= s.length <= 10⁴
//s consists of parentheses only '()[]{}'

namespace CodingExamples.Strings
{
    public readonly struct DelimeterPair
    {
        public char Opening { get; }
        public char Closing { get; }
        public DelimeterPair(char opening,char closing)
        {
            Opening=opening;
            Closing=closing;
        }
    }
    public class ValidParantheses
    {
        private string bracketExpression;
        public const int STRING_MAX_LENGTH = 10000;
        public const int STRING_MIN_LENGTH = 1;
        private readonly DelimeterPair[] validDelimeterPairs = [new DelimeterPair('(',')'), new DelimeterPair('{', '}'), new DelimeterPair('[', ']')];
        Stack<char> delimeterStack;

        public ValidParantheses(string bracketExpression)
        {
            if (bracketExpression == null)
            {
                throw new NullReferenceException();

            }
            if (bracketExpression.Length < STRING_MIN_LENGTH || bracketExpression.Length > STRING_MAX_LENGTH)
            {
                throw new LengthOutOfRangeException($"String length is not in Range {STRING_MIN_LENGTH} to {STRING_MAX_LENGTH}", STRING_MIN_LENGTH, STRING_MAX_LENGTH);

            }
            //if numbers are not in specified range then also throw the exception
            var validCharacters= validDelimeterPairs.Select(c => c.Opening).ToList();
            validCharacters.AddRange(validDelimeterPairs.Select(c => c.Closing));
            if (bracketExpression.Any(x => !validCharacters.Contains(x)))
            {
                throw new ArgumentOutOfRangeException($"String Contain a character out of that is not in Range {validDelimeterPairs.ToString()}");
            }
            delimeterStack = new();
            this.bracketExpression = bracketExpression;

        }
        public bool IsParenthesesValid()
        {
            foreach (char c in bracketExpression)
            {
                foreach (var delimeterPair in validDelimeterPairs)
                {
                    if(delimeterPair.Opening == c)
                    {
                        delimeterStack.Push(c);
                        break;
                    }
                    if(delimeterPair.Closing == c)
                    {
                        if ( delimeterStack.TryPop(out char cpop))
                        {
                            if (cpop != delimeterPair.Opening)
                            {
                                //if top element is not the matching pair
                                return false;
                            }
                            break;
                        }
                        //if stack is empty and there is still a closing character
                        return false;
                    }
                }
               
            }
            return delimeterStack.Count == 0;
        }
    }
}
