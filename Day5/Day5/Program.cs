using System;
using System.Collections.Generic;
using System.Linq;
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

            // Challenge 2

            List<int> alreadyTakenSeats = BoardingPass.GetAllSeatIDs(boardingPasses);
            List<int> allPossibleSeats = Enumerable.Range(0, (127 * 8) + 7).ToList();
            result = BoardingPass.FindMyUniqueSeatID(alreadyTakenSeats, allPossibleSeats);
            Console.WriteLine($"Your seat is number {result}.");
        }
    }
}
