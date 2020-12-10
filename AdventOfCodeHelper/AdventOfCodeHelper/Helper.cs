using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCodeHelper
{
    public static class Helper
    {
        public static List<string> readInData(string fileToOpen)
        {
            // Read in raw data from .txt file, hold in collection
            List<string> rawData = new List<string>();
            FileStream fs = File.Open(fileToOpen, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                rawData.Add(sr.ReadLine());
            }
            sr.Close();
            return rawData;
        }
    }
}
