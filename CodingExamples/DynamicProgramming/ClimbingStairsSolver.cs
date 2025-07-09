namespace CodingExamples.DynamicProgramming
{
    public class ClimbingStairsSolver
    {
        public const uint MAX_STEPS = 92;
        private void ValidateInput(uint uptoStepN)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan<uint>(uptoStepN, 1);
            ArgumentOutOfRangeException.ThrowIfGreaterThan<uint>(uptoStepN, MAX_STEPS);
        }
        public ulong[] GetNumberOfWaysSeries(uint uptoStepN)
        {
            ValidateInput( uptoStepN);
            List<ulong> series = new List<ulong>();            
            if (uptoStepN == 1)
            {
                series.Add(1);
            }
            else if (uptoStepN == 2)
            {
                series.Add(1);
                series.Add(2);
            }
            else
            {
                ulong first = 1; series.Add(1);
                ulong second = 2; series.Add(2);

                for (uint i = 3; i <= uptoStepN; i++)
                {
                    ulong val = checked(first + second);
                    series.Add(val);
                    first = second;
                    second = val;
                }
            }
            return [.. series];
        }
        public ulong GetNumberOfWays(uint nthStep)
        {
            ValidateInput(nthStep);
            ulong first = 1;
            ulong second = 2;
            if (nthStep == 1)
            {
                return first;
            }
            else if (nthStep == 2)
            {
                return second;
            }
            else
            {
                for (uint i = 3; i <= nthStep; i++)
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
