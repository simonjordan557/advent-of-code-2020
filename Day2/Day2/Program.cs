using System;
using Day2Library;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordManager passwordManager = new PasswordManager();
            passwordManager.readInData("data.txt");
            passwordManager.ExtractMeaningfulData(passwordManager.unrefinedDataList);
            int result = passwordManager.HowManyPasswordsAreValid(passwordManager.refinedDataList);
            Console.WriteLine($"There are {result} valid and {passwordManager.refinedDataList.Count - result} invalid passwords from a total of {passwordManager.refinedDataList.Count} passwords.");
        }
    }
}
