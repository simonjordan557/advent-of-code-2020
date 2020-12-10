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

        public Password(int min, int max, char key, string passwordString)
        {
            minOccurences = min;
            maxOccurences = max;
            keyChar = key;
            passwordToCheck = passwordString;
        }


    }
}
