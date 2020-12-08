using NUnit.Framework;
using Day1Library;
using System.IO;

namespace Day1Tests
{
    public class ExpensesTests
    {
        Expenses _expenses;

        [SetUp]
        public void Setup()
        {
            _expenses = new Expenses();
        }

        [Test]
        public void Expenses_Challenge1_CorrectAnswerDetectedInFile()
        {
            Assert.That(776064, Is.EqualTo(_expenses.FindProductWhere2NumbersSum2020()));
        }

        [Test]
        public void Expenses_Challenge2_CorrectAnswerDetectedInFile()
        {
            Assert.That(6964490, Is.EqualTo(_expenses.FindProductWhere3NumbersSum2020()));
        }
    }
}