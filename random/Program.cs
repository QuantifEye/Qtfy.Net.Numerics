namespace random
{
    using System;
    using Qtfy.Net.Numerics.Random.RandomNumberEngines;

    class Program
    {
        static void Main(string[] args)
        {
            var mt = MersenneTwister32Bit19937.InitGenRand(1);
            Console.WriteLine(mt.NextULong((ulong)uint.MaxValue << 32));
        }
    }
}
