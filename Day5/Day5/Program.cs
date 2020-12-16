using System;
using System.Collections.Generic;
using AdventOfCodeHelper;
using Day5Library;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BoardingPass> boardingPasses = new List<BoardingPass>();
            List<string> rawData = Helper.readInData("data.txt");
            foreach (string data in rawData)
            {
                BoardingPass boardingPass = new BoardingPass(data);
                boardingPass.DecodeBoardingPassCode();
                boardingPass.CalculateSeatID();
                boardingPasses.Add(boardingPass);
            }

            int result = BoardingPass.GetHighestSeatID(boardingPasses);
            Console.WriteLine($"The highest seat ID of the {boardingPasses.Count} boarding passes is {result}.");

            

        }
    }
}
