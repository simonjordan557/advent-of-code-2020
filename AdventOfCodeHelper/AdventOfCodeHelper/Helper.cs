using System;
using System.Text;
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

        public static List<string> ReadInDataAndSeparateWhenBlankLine(string fileToOpen)
        {
            // Read in raw data from .txt file, separate when a blank line is encountered, hold in collection
            StringBuilder sb = new StringBuilder();
            List<string> rawData = new List<string>();
            FileStream fs = File.Open(fileToOpen, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    sb.Append(line);
                    sb.Append(" ");
                }
                else
                {
                    rawData.Add(sb.ToString());
                    sb.Clear();
                }
            }
            sr.Close();
            return rawData;
        }
    }
}
