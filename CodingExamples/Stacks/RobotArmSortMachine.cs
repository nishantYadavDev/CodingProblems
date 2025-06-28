using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExamples
{
    public class RobotArmSortMachine
    {
        private Stack<int> stackA;
        private Stack<int> stackB;
        private Stack<int> stackC;
        List<string> movesList = new List<string>();
        public RobotArmSortMachine(int[] boxesA, int[] boxesB, int[] boxesC)
        {
            stackA = new Stack<int>(boxesA);
            stackB = new Stack<int>(boxesB);
            stackC = new Stack<int>(boxesC);
        }
        public string[] GetSortingInstructions()
        {
            
            //check if all stacks are empty
            if(stackA.Count==0 && stackB.Count == 0 && stackC.Count == 0)
            {                
                return movesList.ToArray();
            }
            // check if stack b and stack c are empty
            if (stackA.Count > 0 && stackB.Count == 0 && stackC.Count == 0)
            {
                //now if stack a is already sorted
                bool isSorted = stackA.Zip(stackA.Skip(1), (a, b) => a<=b).All(s => s);
                if (isSorted)
                {
                    // no moves required
                   // Console.WriteLine("Is sorted ");
                    return movesList.ToArray();
                }                
            }
            while (stackA.Count > 0) {
                //emptying stack A and equally distributing to Stack B and stack C
                if (stackB.Count < stackC.Count) {
                    RecordPushFrom(stackA, stackB, "A", "B");
                }
                else
                {
                    RecordPushFrom(stackA, stackC, "A", "C");
                }
                               
            }
            DisplayStacks();
            while (stackB.Count > 0 || stackC.Count > 0)
            {
                //find maximum in stack B and Stack C

                var valIndexB = stackB.Select((value, index) => new { value = value, index = index }).OrderByDescending(x => x.value).FirstOrDefault();
                var valIndexC = stackC.Select((value, index) => new { value = value, index = index }).OrderByDescending(x => x.value).FirstOrDefault();
                
                if (valIndexB != null && valIndexC != null)
                {
                    //means both has some elements
                    if (valIndexB.value >= valIndexC.value)
                    {
                        //move from stackB to stack c upto the max index value
                        
                        MoveItemsFromTo(stackB, stackC, valIndexB.index, "B", "C");
                        RecordPushFrom(stackB, stackA, "B", "A");
                    }
                    else
                    {
                        
                        MoveItemsFromTo(stackC, stackB, valIndexC.index, "C", "B");
                        RecordPushFrom(stackC, stackA, "C", "A");
                    }
                   
                }
                else if(valIndexB != null)
                {
                    //means stackC is empty
                    MoveItemsFromTo(stackB, stackC, valIndexB.index, "B", "C");
                    RecordPushFrom(stackB, stackA, "B", "A");
                }
                else if (valIndexC != null)
                {
                    MoveItemsFromTo(stackC, stackB, valIndexC.index,"C","B");
                    RecordPushFrom(stackC, stackA, "C", "A");
                    
                }
               
            }
            return movesList.ToArray();
        }
        private void MoveItemsFromTo(Stack<int> source, Stack<int> destination,int count, string sourceeName, string destinationName)
        {
            int i = 0;
            while (i < count)
            {
                i++;
                RecordPushFrom(source,destination, sourceeName, destinationName);
                
            }
        }
        private void RecordPushFrom(Stack<int> source,Stack<int> destination,string sourceeName,string destinationName)
        {
            movesList.Add($"{sourceeName} {destinationName}");
            destination.Push(source.Pop());            
        }
        public void DisplayStacks()
        {
            DisplayStack("Stack A",stackA);
            DisplayStack("Stack B", stackB);
            DisplayStack("Stack C", stackC);
        }
        private void DisplayStack(string heading,Stack<int> stack) {
            Console.WriteLine(heading);
            foreach (int i in stack)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}
