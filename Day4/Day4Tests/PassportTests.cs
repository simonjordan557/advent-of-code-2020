using NUnit.Framework;
using Day4Library;
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
        [TestCase("2002", true)]
        [TestCase("2003", false)]
        [TestCase("1874", false)]
        [TestCase("13", false)]
        public void Passport_ValidateByr_WorksAsExpected(string data, bool expectedResult)
        {
            _passport.passportInfo["byr"] = data;
            bool result = _passport.ValidateByr();
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("2020", true)]
        [TestCase("2030", false)]
        [TestCase("1876", false)]
        [TestCase("16", false)]
        public void Passport_ValidateIyr_WorksAsExpected(string data, bool expectedResult)
        {
            _passport.passportInfo["iyr"] = data;
            bool result = _passport.ValidateIyr();
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        [TestCase("2020", true)]
        [TestCase("2035", false)]
        [TestCase("1876", false)]
        [TestCase("16", false)]
        public void Passport_ValidateEyr_WorksAsExpected(string data, bool expectedResult)
        {
            _passport.passportInfo["eyr"] = data;
            bool result = _passport.ValidateEyr();
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("120fg", false)]
        [TestCase("12cm", false)]
        [TestCase("12in", false)]
        [TestCase("1000cm", false)]
        [TestCase("1000in", false)]
        [TestCase("165cm", true)]
        [TestCase("65in", true)]
        public void Passport_ValidateHgt_WorksAsExpected(string data, bool expectedResult)
        {
            _passport.passportInfo["hgt"] = data;
            bool result = _passport.ValidateHgt();
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("^4323ef", false)]
        [TestCase("#4323ef", true)]
        [TestCase("#7564a", false)]
        [TestCase("#7564adc3", false)]
        [TestCase("#46h74e", false)]
        public void Passport_ValidateHcl_WorksAsExpected(string data, bool expectedResult)
        {
            _passport.passportInfo["hcl"] = data;
            bool result = _passport.ValidateHcl();
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("amb", true)]
        [TestCase("gnr", false)]
        [TestCase("#345ae9", false)]
        public void Passport_ValidateEcl_WorksAsExpected(string data, bool expectedResult)
        {
            _passport.passportInfo["ecl"] = data;
            bool result = _passport.ValidateEcl();
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("123456789", true)]
        [TestCase("000341654", true)]
        [TestCase("341654", false)]
        [TestCase("12345678987654321", false)]
        [TestCase("#2345e1", false)]
        public void Passport_ValidatePid_WorksAsExpected(string data, bool expectedResult)
        {
            _passport.passportInfo["pid"] = data;
            bool result = _passport.ValidatePid();
            Assert.That(result, Is.EqualTo(expectedResult));
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