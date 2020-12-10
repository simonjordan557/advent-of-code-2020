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
            int result = passwordManager.HowManyPasswordsAreValidChallenge1(passwordManager.refinedDataList);
            Console.WriteLine($"Using the first policy, there are {result} valid and {passwordManager.refinedDataList.Count - result} invalid passwords from a total of {passwordManager.refinedDataList.Count} passwords.");
            result = passwordManager.HowManyPasswordsAreValidChallenge2(passwordManager.refinedDataList);
            Console.WriteLine($"\nUsing the second policy, There are {result} valid and {passwordManager.refinedDataList.Count - result} invalid passwords from a total of {passwordManager.refinedDataList.Count} passwords.");
        }
    }
}
