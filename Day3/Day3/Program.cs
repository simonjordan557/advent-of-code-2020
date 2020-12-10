using System;
using Day3Library;
using AdventOfCodeHelper;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            Toboggan toboggan = new Toboggan(3, 1);
            toboggan.mountain = Helper.readInData("data.txt");
            int result = toboggan.HowManyTreeStrikes();
            Console.WriteLine($"Struck {result} trees.");

        }
    }
}
