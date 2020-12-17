using NUnit.Framework;
using Day6Library;

namespace Day6Tests
{
    public class CustomsFormTests
    {
        CustomsForm _customsForm;
        [Test]
        public void CustomsForm_WhenConstructed_InitialisesAsExpected()
        {
            _customsForm = new CustomsForm("abxy");
            Assert.That(_customsForm.answeredYes, Is.EqualTo("abxy"));
        }
    }
}