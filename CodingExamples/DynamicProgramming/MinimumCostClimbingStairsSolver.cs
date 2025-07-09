namespace CodingExamples.DynamicProgramming
{
    public class MinimumCostClimbingStairsSolver
    {
        public const int MIN_COST_LENGTH = 2;
        public const int MAX_COST_LENGTH = 1_000_000;
        public const uint MIN_COST_VALUE = 0;
        public const uint MAX_COST_VALUE = 1_000;
        private uint[] costs;
        public MinimumCostClimbingStairsSolver(uint[] costs)
        {
            ArgumentNullException.ThrowIfNull(costs, nameof(costs));
            LengthOutOfRangeException.ThrowIfNotInRange("Costs array length is not in range ", costs.Length, MIN_COST_LENGTH, MAX_COST_LENGTH);
            if(costs.Any(x=> (x< MIN_COST_VALUE || x > MAX_COST_VALUE)))
            {
                throw new ArgumentOutOfRangeException("Costs array has value out of the valid range of values");
            }
            this.costs = costs;
        }
        public uint GetMinimumCostToReachTop()
        {
            uint[] dpCost = GetMinimumCostDPTable();
            return dpCost[dpCost.Length - 1];
        }
        private uint[] GetMinimumCostDPTable()
        {
            int length = costs.Length + 1;
            uint[] dpCost = new uint[length];
            dpCost[0] = 0;
            dpCost[1] = 0;
            for (int i = 2; i < length; i++)
            {
                dpCost[i] = uint.Min(dpCost[i - 1] + costs[i - 1], dpCost[i - 2] + costs[i - 2]);
            }
            return dpCost;
        }
        public uint[] GetListOfCostIncurred()
        {
            uint[] dpCost = GetMinimumCostDPTable();
            Stack<uint> minCostStack = new Stack<uint>();
            int length = dpCost.Length;
            int i = length - 1;
            while (i >= 2)
            {
                if (dpCost[i] == dpCost[i - 1] + costs[i - 1])
                {
                    minCostStack.Push(costs[i - 1]);
                    i--;
                }
                else if (dpCost[i] == dpCost[i - 2] + costs[i - 2])
                {
                    minCostStack.Push(costs[i - 2]);
                    i -= 2;
                }
            }

            return minCostStack.ToArray();
        }
    }
}
