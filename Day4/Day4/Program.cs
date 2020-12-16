using System;
using System.Collections.Generic;
using AdventOfCodeHelper;
using Day4Library;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> rawData = Helper.ReadInDataAndSeparateWhenBlankLine("data.txt");
            List<Passport> passports = new List<Passport>();
            foreach (string data in rawData)
            {
                passports.Add(new Passport(data));
            }

            Console.WriteLine($"Of {passports.Count} passports, {Passport.HowManyPassportsAreValid(passports)} are valid.");
        }
    }
}
