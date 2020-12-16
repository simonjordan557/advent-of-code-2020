using System;
using System.Collections.Generic;
using System.Text;

namespace Day5Library
{
    public class BoardingPass
    {
        public string boardingPassCode;
        public string rowAsString;
        public string columnAsString;
        public int row;
        public int column;
        public int seatID;

        public BoardingPass()
        {

        }

        public BoardingPass(string data)
        {
            boardingPassCode = data;
        }

        public void DecodeBoardingPassCode()
        {
            rowAsString = boardingPassCode.Substring(0, 7).Replace('F', '0').Replace('B', '1');
            columnAsString = boardingPassCode.Substring(7, 3).Replace('L', '0').Replace('R', '1');
            row = Convert.ToInt32(rowAsString, 2);
            column = Convert.ToInt32(columnAsString, 2);
        }

        public void CalculateSeatID()
        {
            seatID = (row * 8) + column;
        }

        public static int GetHighestSeatID(List<BoardingPass> boardingPasses)
        {
            int highestSeatIDSoFar = 0;
            foreach (BoardingPass boardingPass in boardingPasses)
            {
                if (boardingPass.seatID > highestSeatIDSoFar)
                {
                    highestSeatIDSoFar = boardingPass.seatID;
                }
            }
            return highestSeatIDSoFar;
        }

    }
}
