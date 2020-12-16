using NUnit.Framework;
using Day4Library;
using AdventOfCodeHelper;
using System.Collections.Generic;

namespace Day4Tests
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
            Assert.That(_testData[0], Is.EqualTo("byr:2024 iyr:2016 eyr:2034 ecl:zzz pid:985592671 hcl:033b48 hgt:181 cid:166"));
        }
    }
}
