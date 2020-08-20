using System;
using Helios.Architecture.Scrambler.Analysis;
using Helios.Architecture.Scrambler.Scramblers;

namespace Helios.Architecture.Scrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            TestScrambler();
            AnalyzeAlgorithm();

            Console.ReadLine();
        }

        private static void TestScrambler()
        {
            var random = new Random();
            var salt = random.Next();
            var scrambler = new IndexScrambler(salt);

            // test 1000 times with random numbers
            for (int i = 0; i < 1000; i++)
            {
                var index = random.Next();
                var encoded = scrambler.Encode(index);
                var decoded = scrambler.Decode(encoded);
                if (index != decoded) Console.WriteLine($"The scrambler failed for {index} -> {decoded}");
            }
        }

        private static void AnalyzeAlgorithm()
        {
            // create algorithm
            var algorithm = new ScramblerAlgorithm();

            // analyze algorithm
            algorithm.Analyze();
        }
    }
}
