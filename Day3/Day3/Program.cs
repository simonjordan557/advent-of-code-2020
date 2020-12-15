using System;
using System.Collections.Generic;
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
            long result = toboggan.HowManyTreeStrikes();
            Console.WriteLine($"Route {toboggan.slopeX}, {toboggan.slopeY} struck {result} trees.");

            // Challenge 2

            int interimResult;
            List<Toboggan> differentRoutes = new List<Toboggan>() { new Toboggan(1, 1), new Toboggan(5, 1), new Toboggan(7, 1), new Toboggan(1, 2) };
            foreach (Toboggan t in differentRoutes)
            {
                t.mountain = toboggan.mountain;
                interimResult = t.HowManyTreeStrikes();
                Console.WriteLine($"Route {t.slopeX}, {t.slopeY} struck {interimResult} trees.");
                result *= interimResult;
            }
            Console.WriteLine($"Multiplied together, this gives the answer {result}.");
                




        }
    }
}
