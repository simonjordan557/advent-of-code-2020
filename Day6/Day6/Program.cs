using System;
using Day6Library;
using AdventOfCodeHelper;
using System.Collections.Generic;

namespace Day6
{
    class Program
    {
        
       
        static void Main(string[] args)
        {
            CustomsOfficer customsOfficer = new CustomsOfficer();
            List<string> rawData = Helper.ReadInDataAndSeparateWhenBlankLine("data.txt");
            foreach (string data in rawData)
            {
                List<CustomsForm> singleGroup = customsOfficer.CreateCustomsFormGroup(data);
                customsOfficer.PopulateGroupOfGroups(singleGroup);
            }
            List<string> answeredYes = new List<string>();
            foreach (List<CustomsForm> group in customsOfficer.groupOfGroups)
            {
                answeredYes.Add(customsOfficer.FindAllYesInAGroup(group));
            }
            int result = customsOfficer.HowManyYesInAllGroups(answeredYes);
            Console.WriteLine($"The sum of all unique Yes answers in all groups is {result}.");

            // Challenge 2

            result = 0;
            foreach (List<CustomsForm> group in customsOfficer.groupOfGroups)
            {
                result += customsOfficer.HowManyEveryoneAnsweredYes(group);
            }
            Console.WriteLine($"The number of questions that everyone in a group answered Yes to is {result}.");
        }
    }
}
