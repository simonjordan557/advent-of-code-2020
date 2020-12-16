using NUnit.Framework;
using AdventOfCodeHelper;
using System.Collections.Generic;

namespace Day5Tests
{
    public class HelperTests
    {
        List<string> _testData;
        string filePath = "data.txt";

        [Test]
        public void Helper_ReadInData_CorrectlySplitsEachEntryIntoAString()
        {
            _testData = Helper.readInData(filePath);
            Assert.That(_testData[0], Is.EqualTo("FBFBFBFRRL"));
        }
    }
}
