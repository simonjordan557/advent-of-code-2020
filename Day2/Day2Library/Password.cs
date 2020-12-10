using System;
using System.Collections.Generic;
using System.Text;

namespace Day2Library
{
    public class Password
    {
        public int minOccurences;
        public int maxOccurences;
        public char keyChar;
        public string passwordToCheck;
        public int firstIndexToCheck;
        public int secondIndexToCheck;

        public Password(int min, int max, char key, string passwordString)
        {
            minOccurences = min;
            maxOccurences = max;
            keyChar = key;
            passwordToCheck = passwordString;
            firstIndexToCheck = min - 1;
            secondIndexToCheck = max - 1;
        }
    }
}
