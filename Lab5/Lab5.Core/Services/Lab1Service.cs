using System.Numerics;

namespace Lab5.Core.Services
{
    public class Lab1Service
    {
        public (BigInteger maxSetSize, long maxSetCount) Calculate(int N, int K)
        {
            BigInteger maxSetSize = 0;
            for (int m = 1; m <= N; m++)
            {
                maxSetSize += K * m;
            }
            return (maxSetSize, 1);
        }
    }
}