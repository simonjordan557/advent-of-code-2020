using NUnit.Framework;
using Day6Library;
using System.Collections.Generic;

namespace Day6Tests
{
    public class CustomsOfficerTests
    {
        CustomsOfficer _customsOfficer;

        [SetUp]
        public void SetUp()
        {
            _customsOfficer = new CustomsOfficer();
        }

        [Test]
        public void CustomsOfficer_WhenConstructed_InitialisesAsExpected()
        {
            Assert.That(_customsOfficer.groupOfGroups, Is.Not.Null);
        }

        [Test]
        public void CustomsOfficer_CreateCustomsFormGroup_WorksAsExpected()
        {
            List<CustomsForm> _testData = _customsOfficer.CreateCustomsFormGroup("a bc cfh d");
            Assert.That(_testData[2].answeredYes, Is.EqualTo("cfh"));
        }

        [Test]
        public void CustomsOfficer_PopulateGroupOfGroups_WorksAsExpected()
        {
            List<CustomsForm> _testData = _customsOfficer.CreateCustomsFormGroup("a bc cfh d");
            _customsOfficer.PopulateGroupOfGroups(_testData);
            Assert.That(_customsOfficer.groupOfGroups.Count, Is.EqualTo(1));
            Assert.That(_customsOfficer.groupOfGroups[0][0].answeredYes, Is.EqualTo("a"));
        }

        [Test]
        public void CustomsOfficer_FindAllYesInAGroup_WorksAsExpected()
        {
            List<CustomsForm> _testData = _customsOfficer.CreateCustomsFormGroup("a bc cfh d");
            string result = _customsOfficer.FindAllYesInAGroup(_testData);
            Assert.That(result, Is.EqualTo("abcfhd"));
        }

        [Test]
        public void CustomsOfficer_HowManyYesInAllGroups_WorksAsExpected()
        {
            List<CustomsForm> _testData = _customsOfficer.CreateCustomsFormGroup("a bc cfh d");
            string _refinedData = _customsOfficer.FindAllYesInAGroup(_testData);
            List<string> _dataList = new List<string>() { _refinedData };
            int result = _customsOfficer.HowManyYesInAllGroups(_dataList);
            Assert.That(result, Is.EqualTo(6));
        }

    }
}
