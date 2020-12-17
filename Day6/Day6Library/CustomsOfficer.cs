using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Day6Library
{
    public class CustomsOfficer
    {
        public List<List<CustomsForm>> groupOfGroups;

        public CustomsOfficer()
        {
            groupOfGroups = new List<List<CustomsForm>>();

        }
        public List<CustomsForm> CreateCustomsFormGroup(string rawData)
        {
            List<CustomsForm> result = new List<CustomsForm>();
            string[] eachCustomsFormRawData = rawData.Split(' ');
            foreach (string data in eachCustomsFormRawData)
            {
                result.Add(new CustomsForm(data));
            }
            return result;
        }

        public void PopulateGroupOfGroups(List<CustomsForm> input)
        {
            groupOfGroups.Add(input);
        }

        public string FindAllYesInAGroup(List<CustomsForm> input)
        {
            HashSet<char> wip = new HashSet<char>();
            foreach (char c in input[0].answeredYes)
                wip.Add(c);

            for (int i = 1; i < input.Count; i++)
            {
                foreach (char c in input[i].answeredYes)
                wip.Add(c);
            }
            StringBuilder sb = new StringBuilder();
            foreach (char c in wip)
            {
                sb.Append(c);
            }
            return sb.ToString();       
        }

        public int HowManyYesInAllGroups(List<string> input)
        {
            int result = 0;
            foreach (string s in input)
            {
                result += s.Length;
            }
            return result;
        }

        public int HowManyEveryoneAnsweredYes(List<CustomsForm> input)
        {
            List<char> commonAnswers = new List<char>();
            foreach (char c in input[0].answeredYes)
            {
                commonAnswers.Add(c);
            }
            for (int i = 1; i < input.Count; i++)
            {
                for (int j = 0; j < commonAnswers.Count; j++)
                {
                    if (!input[i].answeredYes.Contains(commonAnswers[j]))
                    {
                        commonAnswers.RemoveAt(j);
                    }
                }
            }
            return commonAnswers.Count;
        }


    }
}
