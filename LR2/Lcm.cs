using System;

namespace LR2.Core
{
    public class Lcm
    {
        public int A { get; }
        public int B { get; }

        public Lcm(int a, int b)
        {
            if (a < 1) throw new ArgumentOutOfRangeException(nameof(a), "a должно быть >= 1");
            if (b < 1) throw new ArgumentOutOfRangeException(nameof(b), "b должно быть >= 1");
            A = a;
            B = b;
        }

        private static int Gcd(int x, int y)
        {
            while (y != 0)
            {
                int t = x % y;
                x = y;
                y = t;
            }
            return x;
        }

        public int Compute() => A / Gcd(A, B) * B;

        public int ComputeBruteforce()
        {
            int m = Math.Max(A, B);
            while (true)
            {
                if (m % A == 0 && m % B == 0) return m;
                m++;
            }
        }
    }
}
