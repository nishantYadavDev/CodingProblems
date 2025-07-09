namespace CodingExamples.DynamicProgramming
{
    public class ClimbingStairsSolver
    {
        public const uint MAX_STEPS = 92;
        private void ValidateInput(uint uptoN)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan<uint>(uptoN, 1);
            ArgumentOutOfRangeException.ThrowIfGreaterThan<uint>(uptoN, MAX_STEPS);
        }
        public ulong[] GetNumberOfWaysSeries(uint uptoN)
        {
            ValidateInput( uptoN);
            List<ulong> series = new List<ulong>();            
            if (uptoN == 1)
            {
                series.Add(1);
            }
            else if (uptoN == 2)
            {
                series.Add(1);
                series.Add(2);
            }
            else
            {
                ulong first = 1; series.Add(1);
                ulong second = 2; series.Add(2);

                for (uint i = 3; i <= uptoN; i++)
                {
                    ulong val = checked(first + second);
                    series.Add(val);
                    first = second;
                    second = val;
                }
            }
            return [.. series];
        }
        public ulong GetNumberOfWays(uint nth)
        {
            ValidateInput(nth);
            ulong first = 1;
            ulong second = 2;
            if (nth == 1)
            {
                return first;
            }
            else if (nth == 2)
            {
                return second;
            }
            else
            {
                for (uint i = 3; i <= nth; i++)
                {
                    ulong val = checked(first + second);
                    first = second;
                    second = val;
                }
            }
            return second;
        }
       
    }
}
