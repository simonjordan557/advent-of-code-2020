using NUnit.Framework;
using System.Collections.Generic;
using Day2Library;

namespace Day2Tests
{
    public class PasswordManagerTests
    {
        PasswordManager _passwordManager;

        [SetUp]
        public void Setup()
        {
            _passwordManager = new PasswordManager();
        }

        [Test]
        [TestCase("g:", 'g')]
        [TestCase("c:", 'c')]
        public void SetKeyChar_GivenValidString_ReturnsCorrectChar(string input, char expectedResult)
        {
            char result = _passwordManager.SetKeyChar(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("17-20", 17)]
        [TestCase("5-9", 5)]
        public void SetMinOccurences_GivenValidString_ReturnsCorrectInt(string input, int expectedResult)
        {
            int result = _passwordManager.SetMinOccurences(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("17-20", 20)]
        [TestCase("5-9", 9)]
        public void SetMaxOccurences_GivenValidString_ReturnsCorrectInt(string input, int expectedResult)
        {
            int result = _passwordManager.SetMaxOccurences(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CheckPasswordIsValid_GivenValidPassword_ReturnsTrue()
        {
            Password password = new Password(1, 3, 'a', "fhdgjalkjfuatt");
            Assert.That(_passwordManager.CheckPasswordIsValid(password), Is.EqualTo(true));
        }

        [Test]
        public void CheckPasswordIsValid_GivenInvalidPassword_ReturnsFalse()
        {
            Password password = new Password(3, 7, 'f', "fjkljkjslkdjf");
            Assert.That(_passwordManager.CheckPasswordIsValid(password), Is.EqualTo(false));
        }

        [Test]
       public void ExtractMeaningfulData_GivenValidInput_SubstringCorrect()
        {
            List<string> testData = new List<string>() { "2-3 r: rrrrr" };
            _passwordManager.ExtractMeaningfulData(testData);
            Assert.That(_passwordManager.passwordToCheck, Is.EqualTo("rrrrr"));
        }

        [Test]
        public void HowManyPasswordsAreValid_CalculatesCorrectly()
        {
            List<Password> testData = new List<Password>()
            {
                new Password(1, 3, 'a', "aasdf"), // valid
                new Password(1, 4, 'h', "hhlkf"), // valid
                new Password(4, 6, 't', "ttgkh")  // invalid
            };

            Assert.That(_passwordManager.HowManyPasswordsAreValid(testData), Is.EqualTo(2));
        }
    }
}