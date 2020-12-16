using NUnit.Framework;
using Day5Library;
using System.Collections.Generic;

namespace Day5Tests
{
    public class BoardingPassTests
    {
        BoardingPass _boardingPass;

        [SetUp]
        public void Setup()
        {
            _boardingPass = new BoardingPass();
        }

        [Test]
        public void BoardingPass_Constructor_InitialisesCorrectly()
        {
            _boardingPass = new BoardingPass("ABCDE");
            Assert.That(_boardingPass.boardingPassCode, Is.EqualTo("ABCDE"));
        }

        [Test]
        public void BoardingPass_DecodeBoardingPassCode_WorksAsExpected()
        {
            _boardingPass.boardingPassCode = "BBBBBBBRRR";
            _boardingPass.DecodeBoardingPassCode();
            Assert.That(_boardingPass.rowAsString, Is.EqualTo("1111111"));
            Assert.That(_boardingPass.row, Is.EqualTo(127));
            Assert.That(_boardingPass.column, Is.EqualTo(7));
            Assert.That(_boardingPass.columnAsString, Is.EqualTo("111"));
        }

        [Test]
        public void BoardingPass_CalculateSeatID_WorksAsExpected()
        {
            _boardingPass.row = 2;
            _boardingPass.column = 3;
            _boardingPass.CalculateSeatID();
            Assert.That(_boardingPass.seatID, Is.EqualTo(19));
        }

        [Test]
        public void BoardingPass_GetHighestSeatID_WorksAsExpected()
        {
            BoardingPass bp1 = new BoardingPass("FFFFFFBLLR");
            bp1.DecodeBoardingPassCode();
            bp1.CalculateSeatID();

            BoardingPass bp2 = new BoardingPass("BBBBBBBRRR");
            bp2.DecodeBoardingPassCode();
            bp2.CalculateSeatID();

            List<BoardingPass> testList = new List<BoardingPass>() { bp1, bp2 };

            int result = BoardingPass.GetHighestSeatID(testList);
            Assert.That(result, Is.EqualTo((127 * 8) + 7));
        }

        [Test]
        public void BoardingPass_GetAllSeatIDs_WorksAsExpected()
        {
            BoardingPass bp1 = new BoardingPass("FFFFFFBLLR");
            bp1.DecodeBoardingPassCode();
            bp1.CalculateSeatID();

            BoardingPass bp2 = new BoardingPass("BBBBBBBRRR");
            bp2.DecodeBoardingPassCode();
            bp2.CalculateSeatID();

            List<BoardingPass> testList = new List<BoardingPass>() { bp1, bp2 };
            List<int> result = BoardingPass.GetAllSeatIDs(testList);
            Assert.That(result[0], Is.EqualTo(9));
            Assert.That(result[1], Is.EqualTo(1023));
        }

        [Test]
        public void BoardingPass_FindMyUniqueSeatID_WorksAsExpected()
        {
            List<int> allPossibleSeats = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            List<int> alreadyTakenSeats = new List<int>() { 4, 5, 6, 7, 9, 10, 11, 12 };
            int result = BoardingPass.FindMyUniqueSeatID(alreadyTakenSeats, allPossibleSeats);
            Assert.That(result, Is.EqualTo(8));
        }
    }
}