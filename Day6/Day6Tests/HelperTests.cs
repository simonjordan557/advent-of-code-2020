using NUnit.Framework;
using AdventOfCodeHelper;
using System.Collections.Generic;

namespace Day6Tests
{
    public class HelperTests
    {
        List<string> _testData;
        string filePath;

        [SetUp]
        public void SetUp()
        {
            _testData = new List<string>();
            filePath = "data.txt";
        }

        [Test]
        public void Helper_ReadInDataAndSeparateWhenBlankLine_CorrectlySplitsEachEntryIntoAString()
        {
            _testData = Helper.ReadInDataAndSeparateWhenBlankLine(filePath);
            Assert.That(_testData[0], Is.EqualTo("nvlyak nyvha yaen qynia"));
        }
    }
}
