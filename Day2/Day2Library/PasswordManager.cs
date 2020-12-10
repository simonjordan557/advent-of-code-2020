using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Day2Library
{
    public class PasswordManager
    {
        // Declare collections to hold input data before and after refining into parsable objects
        public List<string> unrefinedDataList;
        public List<Password> refinedDataList;

        // Declare variables used to build each deconstructed Password object from an unformatted string
        public int minOccurences;
        public int maxOccurences;
        public char keyChar;
        public string passwordToCheck;

        public PasswordManager()
        {
            // Initialise collections on creation
            unrefinedDataList = new List<string>();
            refinedDataList = new List<Password>();
        }

        public void readInData(string fileToOpen)
        {
            // Read in raw data from .txt file, hold in collection
            FileStream fs = File.Open(fileToOpen, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                unrefinedDataList.Add(sr.ReadLine());
            }
            sr.Close();
        }

        public void ExtractMeaningfulData(List<string> rawDataList)
        {
            // Refine raw data into parsable data, use this to create an object, add object to collection 
            foreach (string rawData in rawDataList)
            {
                string[] refinedDataArray = rawData.Split(' ');
                minOccurences = SetMinOccurences(refinedDataArray[0]);
                maxOccurences = SetMaxOccurences(refinedDataArray[0]);
                keyChar = SetKeyChar(refinedDataArray[1]);
                passwordToCheck = refinedDataArray[2];
                refinedDataList.Add(new Password(minOccurences, maxOccurences, keyChar, passwordToCheck));
            }
        }

        public int HowManyPasswordsAreValid(List<Password> passwordList)
        {
            // Check all parsable Password objects in the collection and count how many are valid
            int numberOfValidPasswords = 0;
            foreach (Password password in passwordList)
            {
                if (CheckPasswordIsValid(password))
                {
                    numberOfValidPasswords++;
                }
            }
            return numberOfValidPasswords;
        }

        public bool CheckPasswordIsValid(Password password)
        {
            // Check a single parsable Password object to see if it is valid

           /* Each line gives the password policy and then the password.
           The password policy indicates the lowest and highest number of times a given letter must appear for the password to be valid.
           For example, 1-3 a means that the password must contain a at least 1 time and at most 3 times.
           */

            int keyCharOccurences = password.passwordToCheck.Count(c => c == password.keyChar);
            return keyCharOccurences >= password.minOccurences && keyCharOccurences <= password.maxOccurences;
        }

        public int SetMinOccurences(string refinedData)
        {
            // Format raw data to set minimum occurences variable
            return int.Parse(refinedData.Split('-')[0]);
        }

        public int SetMaxOccurences(string refinedData)
        {
            // Format raw data to set max occurences variable
            return int.Parse(refinedData.Split('-')[1]);
        }

        public char SetKeyChar(string refinedData)
        {
            // Format raw data to set key character variable
            return refinedData.Remove(1).ToCharArray()[0];
        }
    }
}
