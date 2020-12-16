using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCodeHelper;

namespace Day4Library
{
    public class Passport
    {
        public Dictionary<string, string> passportInfo;

        public Passport()
        {
            passportInfo = new Dictionary<string, string>();
        }

        public Passport(string rawData) : this()
        {
            PopulatePassportInfo(rawData);
        }

         public object this[string index]
        {
            get { return passportInfo[index]; }
        }

        public void PopulatePassportInfo(string rawData)
        {
            string[] keyValuePairs;
            string[] keyValue;
            
            
                keyValuePairs = rawData.Split(' ');
                foreach (string s in keyValuePairs)
                {
                    keyValue = s.Split(':');
                    passportInfo.Add(keyValue[0], keyValue[1]);
                }
            
        }

        public bool ValidatePassportInfo()
        {
            // Check all required fields are present
            string[] requiredKeys = new string[] { "ecl", "pid", "eyr", "hcl", "byr", "iyr", "hgt" };
            foreach (string key in requiredKeys)
            {
                if (!passportInfo.ContainsKey(key))
                {
                    return false;
                }
            }

            // Validate byr
            // Validate iyr
            // Validate eyr
            // Validate hgt
            // Validate hcl
            // Validate ecl
            // Validate pid
        }

        public bool ValidateByr()
        {
            if (int.Parse(passportInfo["byr"]) < 1920 || int.Parse(passportInfo["byr"]) > 2002) return false;
            return true;
        }

        public bool ValidateIyr()
        {
            if (int.Parse(passportInfo["iyr"]) < 2010 || int.Parse(passportInfo["iyr"]) > 2020) return false;
            return true;
        }

        public bool ValidateEyr()
        {
            if (int.Parse(passportInfo["eyr"]) < 2020 || int.Parse(passportInfo["eyr"]) > 2030) return false;
            return true;
        }

        public bool ValidateHgt()
        {
            string hgtSuffix = passportInfo["hgt"].Substring(passportInfo["hgt"].Length - 2, 2);
            string hgtPrefix = passportInfo["hgt"].Substring(0, passportInfo["hgt"].Length - 2);
            if (hgtSuffix != "in" && hgtSuffix != "cm") return false;
            else if (hgtSuffix == "in")
            {
                if (int.Parse(hgtPrefix) < 59 || int.Parse(hgtPrefix) > 76) return false;
            }
            else
            {
                if (int.Parse(hgtPrefix) < 150 || int.Parse(hgtPrefix) > 193) return false;
            }
            return true;
        }

        public bool ValidateHcl()
        {
            if (passportInfo["hcl"][0] != '#') return false;
            else if (passportInfo["hcl"].Length != 7) return false;
            else
            {
                char[] validHex = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
                foreach (char c in passportInfo["hcl"])
                {
                    if (!validHex.Contains(c)) return false;
                }
            }
            return true;
        }

        public bool ValidateEcl()
        {
            string[] validEyeColours = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            if (!validEyeColours.Contains(passportInfo["ecl"])) return false;
            return true;
        }


        public bool ValidatePid()
        {
            if (passportInfo["pid"].Length != 9) return false;
            else
            {
                if (!int.TryParse(passportInfo["pid"], out _)) return false;
            }
            return true;
        }

        public static int HowManyPassportsAreValid(List<Passport> passports)
        {
            int result = 0;
            foreach (Passport passport in passports)
            {
                if (passport.ValidatePassportInfo())
                {
                    result++;
                }
            }
            return result;
        }
    }
}
