using NUnit.Framework;
using Day4Library;
using AdventOfCodeHelper;
using System.Collections.Generic;

namespace Day4Tests
{
    public class PassportTests
    {
        Passport _passport;

        [SetUp]
        public void Setup()
        {
            _passport = new Passport();
        }

        [Test]
        public void Passport_Constructor_CreatesDictionary()
        {
            Assert.That(_passport.passportInfo, Is.Empty);
        }

        [Test]
        public void Passport_PopulatePassportInfo_CorrectlyPopulatesInfoAndIndexerWorksToo()
        {
            _passport.PopulatePassportInfo("byr:166 pid:1635463");
            Assert.That(_passport["byr"], Is.EqualTo("166"));
            Assert.That(_passport["pid"], Is.EqualTo("1635463"));
        }

        [Test]
        [TestCase("ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm", true)]
        [TestCase("iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884 hcl:#cfa07d byr:1929", false)]
        [TestCase("hcl:#ae17e1 iyr:2013 eyr:2024 ecl:brn pid:760753108 byr:1931 hgt:179cm", true)]
        [TestCase("hcl:#cfa07d eyr:2025 pid:166559648 iyr:2011 ecl:brn hgt:59in", false)]
        public void Passport_ValidatePassportInfo_WorksAsExpected(string rawData, bool expectedResult)
        {
            _passport.PopulatePassportInfo(rawData);
            bool result = _passport.ValidatePassportInfo();
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        [TestCase("ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm", 1)]
        [TestCase("iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884 hcl:#cfa07d byr:1929", 0)]
        public void Passport_HowManyPassportsAreValid_WorksAsExpected(string rawData, int expectedResult)
        {
            _passport.PopulatePassportInfo(rawData);
            List<Passport> passportList = new List<Passport>() { _passport };
            Assert.That(Passport.HowManyPassportsAreValid(passportList), Is.EqualTo(expectedResult));
        }
    }
}