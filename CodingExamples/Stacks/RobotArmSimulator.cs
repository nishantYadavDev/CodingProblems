using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExamples
{
    internal class RobotArmSimulator
    {
        int stackCapacityMax = 10;
        int stackCapacityMin = 3;
        int min = 10;
        int max = 100;
        int[] boxesA, boxesB, boxesC;
        public void Run()
        {
            var random = new Random();
            boxesA = Enumerable.Range(0, random.Next(stackCapacityMin, stackCapacityMax)).Select(i => random.Next(min, max)).ToArray();
            //int[] boxesA =new int[] {9,7,6,5 };
             boxesB = Enumerable.Range(0, random.Next(stackCapacityMin, stackCapacityMax)).Select(i => random.Next(min, max)).ToArray();
             boxesC = Enumerable.Range(0, random.Next(stackCapacityMin, stackCapacityMax)).Select(i => random.Next(min, max)).ToArray();
            DisplayBoxes("Boxes A", boxesA);
            DisplayBoxes("Boxes B", boxesB);
            DisplayBoxes("Boxes C", boxesC);
            var rasm = new RobotArmSortMachine(boxesA, boxesB, boxesC);
            rasm.DisplayStacks();
            var sortInstructions = rasm.GetSortingInstructions();
            foreach (var item in sortInstructions)
            {
                Console.Write($" {item},");
            }
            Console.WriteLine($"\n Total length of instructions {sortInstructions.Length},");
            
        }
        void DisplayBoxes(string heading, int[] boxes)
        {
            Console.WriteLine(heading);
            foreach (int box in boxes)
            {
                Console.Write($"{box} ");
            }
            Console.WriteLine();
        }
    }
}
