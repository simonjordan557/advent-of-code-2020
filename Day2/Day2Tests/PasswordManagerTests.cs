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
        public void CheckPasswordIsValidChallenge1_GivenValidPassword_ReturnsTrue()
        {
            Password password = new Password(1, 3, 'a', "fhdgjalkjfuatt");
            Assert.That(_passwordManager.CheckPasswordIsValidChallenge1(password), Is.EqualTo(true));
        }

        [Test]
        public void CheckPasswordIsValidChallenge1_GivenInvalidPassword_ReturnsFalse()
        {
            Password password = new Password(3, 7, 'f', "fjkljkjslkdjf");
            Assert.That(_passwordManager.CheckPasswordIsValidChallenge1(password), Is.EqualTo(false));
        }

        [Test]
       public void ExtractMeaningfulData_GivenValidInput_SubstringCorrect()
        {
            List<string> testData = new List<string>() { "2-3 r: rrrrr" };
            _passwordManager.ExtractMeaningfulData(testData);
            Assert.That(_passwordManager.passwordToCheck, Is.EqualTo("rrrrr"));
        }

        [Test]
        public void HowManyPasswordsAreValidChallenge1_CalculatesCorrectly()
        {
            List<Password> testData = new List<Password>()
            {
                new Password(1, 3, 'a', "aasdf"), // valid
                new Password(1, 4, 'h', "hhlkf"), // valid
                new Password(4, 6, 't', "ttgkh")  // invalid
            };

            Assert.That(_passwordManager.HowManyPasswordsAreValidChallenge1(testData), Is.EqualTo(2));
        }

        [Test]
        public void CheckPasswordIsValidChallenge2_GivenValidPassword_ReturnsTrue()
        {
            Password password = new Password(1, 3, 'a', "fhagjalkjfuatt");
            Assert.That(_passwordManager.CheckPasswordIsValidChallenge2(password), Is.EqualTo(true));
        }

        [Test]
        public void CheckPasswordIsValidChallenge2_GivenInvalidPassword_ReturnsFalse()
        {
            Password password = new Password(3, 7, 'f', "fjkljkjslkdjf");
            Assert.That(_passwordManager.CheckPasswordIsValidChallenge2(password), Is.EqualTo(false));
        }

        [Test]
        public void HowManyPasswordsAreValidChallenge2_CalculatesCorrectly()
        {
            List<Password> testData = new List<Password>()
            {
                new Password(1, 3, 'a', "aasdf"), // valid
                new Password(1, 4, 'h', "hhlkf"), // valid
                new Password(4, 5, 't', "ttgkh"), // invalid
                new Password(1, 2, 'v', "vvvvk")  // invalid
            };

            Assert.That(_passwordManager.HowManyPasswordsAreValidChallenge2(testData), Is.EqualTo(2));
        }
    }
}